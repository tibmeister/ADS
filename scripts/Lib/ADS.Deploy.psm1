<#
.SYNOPSIS
ADS deployment helpers.
.DESCRIPTION
Provides primitives to run offline deployment steps in WinPE.
.EXAMPLES
Invoke-ADSApplyImage -ImagePath "\\server\share\image.wim" -ImageIndex 1 -TargetDrive "W:"
.NOTES
Supports -WhatIf and uses structured logging.
#>

Import-Module "$PSScriptRoot/ADS.Logging.psm1" -Force

function Invoke-ADSExternalCommand {
    param(
        # Command to execute
        [Parameter(Mandatory = $true)]
        [string] $FilePath,
        # Command arguments
        [string] $Arguments,
        # When true, skip execution
        [switch] $WhatIf
    )

    if ($WhatIf) {
        Write-ADSLog -Message "WHATIF: $FilePath $Arguments" -Level "INFO"
        return 0
    }

    Write-ADSLog -Message "Running: $FilePath $Arguments" -Level "INFO"
    $process = Start-Process -FilePath $FilePath -ArgumentList $Arguments -PassThru -Wait -NoNewWindow -ErrorAction Stop
    return $process.ExitCode
}

function Invoke-ADSNetworkingInit {
    <#
    .SYNOPSIS
    Initializes WinPE networking.
    .DESCRIPTION
    Runs wpeinit if present to bring up networking in WinPE.
    .EXAMPLES
    Invoke-ADSNetworkingInit
    .NOTES
    Safe to re-run; ignores missing binaries.
    #>
    param(
        # When set, only logs intended actions
        [switch] $WhatIf
    )

    $wpeinit = (Get-Command "wpeinit.exe" -ErrorAction SilentlyContinue)?.Source
    if (-not $wpeinit) {
        Write-ADSLog -Message "wpeinit not found; skipping networking init." -Level "WARN"
        return
    }

    Invoke-ADSExternalCommand -FilePath $wpeinit -Arguments "" -WhatIf:$WhatIf | Out-Null
}

function Invoke-ADSDiskPartition {
    <#
    .SYNOPSIS
    Partitions the target disk.
    .DESCRIPTION
    Creates UEFI/GPT partitions and assigns W: to the Windows volume.
    .EXAMPLES
    Invoke-ADSDiskPartition -DiskNumber 0
    .NOTES
    Uses diskpart with a generated script; destructive operation.
    #>
    param(
        # Disk number to wipe and partition
        [Parameter(Mandatory = $true)]
        [int] $DiskNumber,
        # When set, only logs intended actions
        [switch] $WhatIf
    )

    $script = @"
select disk $DiskNumber
clean
convert gpt
create partition efi size=260
format quick fs=fat32 label="System"
assign letter=S
create partition msr size=16
create partition primary
format quick fs=ntfs label="Windows"
assign letter=W
list volume
exit
"@

    $scriptPath = Join-Path -Path $env:TEMP -ChildPath "ads-diskpart.txt"
    $script | Set-Content -Path $scriptPath -Encoding ASCII

    if ($WhatIf) {
        Write-ADSLog -Message "WHATIF: diskpart /s $scriptPath" -Level "INFO"
        return
    }

    Invoke-ADSExternalCommand -FilePath "diskpart.exe" -Arguments "/s `"$scriptPath`"" | Out-Null
}

function Set-ADSStaticNetwork {
    <#
    .SYNOPSIS
    Applies static IP settings in WinPE.
    .DESCRIPTION
    Configures IP, subnet, gateway, and DNS on the first up adapter when static settings are provided.
    .EXAMPLES
    Set-ADSStaticNetwork -IpAddress "192.168.1.50" -SubnetMask "255.255.255.0" -Gateway "192.168.1.1" -DnsServers @("8.8.8.8","1.1.1.1")
    .NOTES
    Uses netsh for compatibility in WinPE. Gateway and DNS are optional.
    #>
    param(
        # Static IP address
        [Parameter(Mandatory = $true)]
        [string] $IpAddress,
        # Subnet mask
        [Parameter(Mandatory = $true)]
        [string] $SubnetMask,
        # Default gateway
        [string] $Gateway,
        # DNS servers
        [string[]] $DnsServers,
        # When set, only logs intended actions
        [switch] $WhatIf
    )

    $adapter = Get-NetAdapter -Physical | Where-Object { $_.Status -eq "Up" } | Sort-Object -Property InterfaceMetric | Select-Object -First 1
    if (-not $adapter) {
        $adapter = Get-NetAdapter | Where-Object { $_.Status -eq "Up" } | Sort-Object -Property InterfaceMetric | Select-Object -First 1
    }

    $name = $adapter?.InterfaceAlias
    if (-not $name) {
        $name = "Ethernet"
        Write-ADSLog -Message "No active adapter found; falling back to interface name '$name' for static IP." -Level "WARN"
    }
    $gatewayPart = [string]::IsNullOrWhiteSpace($Gateway) ? "" : " $Gateway 1"
    $ipArgs = "interface ip set address name=`"$name`" static $IpAddress $SubnetMask$gatewayPart"
    Invoke-ADSExternalCommand -FilePath "netsh.exe" -Arguments $ipArgs -WhatIf:$WhatIf | Out-Null

    if ($DnsServers -and $DnsServers.Count -gt 0) {
        $index = 1
        foreach ($dns in $DnsServers) {
            $dnsArgs = "interface ip add dns name=`"$name`" addr=$dns index=$index"
            Invoke-ADSExternalCommand -FilePath "netsh.exe" -Arguments $dnsArgs -WhatIf:$WhatIf | Out-Null
            $index++
        }
    }

    Write-ADSLog -Message "Static IP applied to adapter '$name' (IP $IpAddress/$SubnetMask, Gateway $Gateway, DNS [$($DnsServers -join ', ')])" -Level "INFO"
}

function Invoke-ADSApplyImage {
    <#
    .SYNOPSIS
    Applies the operating system image.
    .DESCRIPTION
    Uses DISM to apply the specified image index to the Windows partition.
    .EXAMPLES
    Invoke-ADSApplyImage -ImagePath "\\server\share\os.wim" -ImageIndex 1 -TargetDrive "W:"
    .NOTES
    Expects DISM to be available in WinPE.
    #>
    param(
        # Path to the WIM file
        [Parameter(Mandatory = $true)]
        [string] $ImagePath,
        # Image index within the WIM
        [Parameter(Mandatory = $true)]
        [int] $ImageIndex,
        # Target drive letter for Windows volume
        [Parameter(Mandatory = $true)]
        [string] $TargetDrive,
        # When set, only logs intended actions
        [switch] $WhatIf
    )

    $args = "/Apply-Image /ImageFile:`"$ImagePath`" /Index:$ImageIndex /ApplyDir:$TargetDrive\"
    Invoke-ADSExternalCommand -FilePath "dism.exe" -Arguments $args -WhatIf:$WhatIf | Out-Null
}

function Invoke-ADSInjectDrivers {
    <#
    .SYNOPSIS
    Injects drivers into the offline image.
    .DESCRIPTION
    Uses DISM /Add-Driver recursively when a driver path is provided.
    .EXAMPLES
    Invoke-ADSInjectDrivers -TargetDrive "W:" -DriverPath "X:\Drivers"
    .NOTES
    Skips when no driver path is given.
    #>
    param(
        # Offline Windows drive letter
        [Parameter(Mandatory = $true)]
        [string] $TargetDrive,
        # Driver folder path
        [string] $DriverPath,
        # When set, only logs intended actions
        [switch] $WhatIf
    )

    if ([string]::IsNullOrWhiteSpace($DriverPath)) {
        Write-ADSLog -Message "No driver path provided; skipping driver injection." -Level "INFO"
        return
    }

    $args = "/Image:$TargetDrive\ /Add-Driver /Driver:`"$DriverPath`" /Recurse"
    Invoke-ADSExternalCommand -FilePath "dism.exe" -Arguments $args -WhatIf:$WhatIf | Out-Null
}

function Invoke-ADSOfflinePackages {
    <#
    .SYNOPSIS
    Adds optional offline packages.
    .DESCRIPTION
    Iterates through provided package paths and calls DISM /Add-Package.
    .EXAMPLES
    Invoke-ADSOfflinePackages -TargetDrive "W:" -Packages @("X:\packs\one.cab")
    .NOTES
    Packages are optional and skipped when empty.
    #>
    param(
        # Offline Windows drive letter
        [Parameter(Mandatory = $true)]
        [string] $TargetDrive,
        # Package paths to add
        [string[]] $Packages,
        # When set, only logs intended actions
        [switch] $WhatIf
    )

    if (-not $Packages -or $Packages.Count -eq 0) {
        Write-ADSLog -Message "No offline packages provided; skipping." -Level "INFO"
        return
    }

    foreach ($package in $Packages) {
        $args = "/Image:$TargetDrive\ /Add-Package /PackagePath:`"$package`""
        Invoke-ADSExternalCommand -FilePath "dism.exe" -Arguments $args -WhatIf:$WhatIf | Out-Null
    }
}

function Set-ADSUnattendFile {
    <#
    .SYNOPSIS
    Stages unattend.xml if provided.
    .DESCRIPTION
    Copies the unattend template into Panther\Unattend.
    .EXAMPLES
    Set-ADSUnattendFile -TargetDrive "W:" -UnattendPath "X:\unattend.xml"
    .NOTES
    Skips when no path is provided.
    #>
    param(
        # Offline Windows drive letter
        [Parameter(Mandatory = $true)]
        [string] $TargetDrive,
        # Path to unattend template
        [string] $UnattendPath
    )

    if ([string]::IsNullOrWhiteSpace($UnattendPath)) {
        Write-ADSLog -Message "No unattend template provided; skipping." -Level "INFO"
        return
    }

    $dest = Join-Path -Path "$TargetDrive\" -ChildPath "Windows\Panther\Unattend"
    New-Item -ItemType Directory -Path $dest -Force | Out-Null
    Copy-Item -Path $UnattendPath -Destination (Join-Path $dest "Unattend.xml") -Force
    Write-ADSLog -Message "Unattend staged to $dest" -Level "INFO"
}

function Set-ADSPostInstallAssets {
    <#
    .SYNOPSIS
    Stages post-install assets.
    .DESCRIPTION
    Copies PostInstall.ps1, config, and optional ODJ blob into the offline image and creates SetupComplete.cmd.
    .EXAMPLES
    Set-ADSPostInstallAssets -TargetDrive "W:" -ScriptSource "X:\scripts" -ConfigPath "X:\Deploy\deploy.json"
    .NOTES
    Idempotent; overwrites existing files safely.
    #>
    param(
        # Offline Windows drive letter
        [Parameter(Mandatory = $true)]
        [string] $TargetDrive,
        # Path to scripts folder containing PostInstall.ps1
        [Parameter(Mandatory = $true)]
        [string] $ScriptSource,
        # Path to deployment config JSON
        [Parameter(Mandatory = $true)]
        [string] $ConfigPath,
        # Optional ODJ blob
        [string] $OdjBlobPath
    )

    $deployRoot = Join-Path -Path "$TargetDrive\" -ChildPath "Deploy"
    New-Item -ItemType Directory -Path $deployRoot -Force | Out-Null
    Copy-Item -Path $ConfigPath -Destination (Join-Path $deployRoot "deploy.json") -Force

    $postInstallSource = Join-Path -Path $ScriptSource -ChildPath "PostInstall.ps1"
    Copy-Item -Path $postInstallSource -Destination (Join-Path $deployRoot "PostInstall.ps1") -Force

    $libSource = Join-Path -Path $ScriptSource -ChildPath "Lib"
    if (Test-Path -Path $libSource) {
        Copy-Item -Path $libSource -Destination (Join-Path $deployRoot "Lib") -Recurse -Force
    }

    if (-not [string]::IsNullOrWhiteSpace($OdjBlobPath) -and (Test-Path -Path $OdjBlobPath)) {
        $odjDest = Join-Path -Path $deployRoot -ChildPath "ODJ"
        New-Item -ItemType Directory -Path $odjDest -Force | Out-Null
        Copy-Item -Path $OdjBlobPath -Destination (Join-Path $odjDest "odjblob.txt") -Force
    }

    $setupScripts = Join-Path -Path "$TargetDrive\" -ChildPath "Windows\Setup\Scripts"
    New-Item -ItemType Directory -Path $setupScripts -Force | Out-Null
    $cmdPath = Join-Path -Path $setupScripts -ChildPath "SetupComplete.cmd"
    $cmdContent = "@echo off`r`nPowerShell.exe -NoProfile -ExecutionPolicy Bypass -File ""C:\\Deploy\\PostInstall.ps1"" >> C:\\Deploy\\PostInstall.cmd.log 2>&1"
    $cmdContent | Set-Content -Path $cmdPath -Encoding ASCII
    Write-ADSLog -Message "Post-install assets staged to $deployRoot" -Level "INFO"
}

function Invoke-ADSMakeBootable {
    <#
    .SYNOPSIS
    Makes the applied image bootable.
    .DESCRIPTION
    Calls bcdboot against the offline Windows directory.
    .EXAMPLES
    Invoke-ADSMakeBootable -TargetDrive "W:"
    .NOTES
    Requires bcdboot to be available in WinPE.
    #>
    param(
        # Offline Windows drive letter
        [Parameter(Mandatory = $true)]
        [string] $TargetDrive,
        # When set, only logs intended actions
        [switch] $WhatIf
    )

    $args = "$TargetDrive\Windows /s S: /f UEFI"
    Invoke-ADSExternalCommand -FilePath "bcdboot.exe" -Arguments $args -WhatIf:$WhatIf | Out-Null
}

function Invoke-ADSReboot {
    <#
    .SYNOPSIS
    Triggers a reboot in WinPE.
    .DESCRIPTION
    Calls wpeutil reboot when available.
    .EXAMPLES
    Invoke-ADSReboot
    .NOTES
    Skips when wpeutil is missing.
    #>
    param(
        # When set, only logs intended actions
        [switch] $WhatIf
    )

    $wpeutil = (Get-Command "wpeutil.exe" -ErrorAction SilentlyContinue)?.Source
    if (-not $wpeutil) {
        Write-ADSLog -Message "wpeutil not found; skipping reboot call." -Level "WARN"
        return
    }

    Invoke-ADSExternalCommand -FilePath $wpeutil -Arguments "reboot" -WhatIf:$WhatIf | Out-Null
}

function Invoke-ADSFormatAdditionalDisks {
    <#
    .SYNOPSIS
    Formats all non-OS disks.
    .DESCRIPTION
    Cleans and formats every disk except the target OS disk, creating a single NTFS partition per disk.
    .EXAMPLES
    Invoke-ADSFormatAdditionalDisks -OsDiskNumber 0
    .NOTES
    Destructive; intended for opt-in use.
    #>
    param(
        # Disk number that contains the OS
        [Parameter(Mandatory = $true)]
        [int] $OsDiskNumber,
        # When set, only logs intended actions
        [switch] $WhatIf
    )

    $disks = Get-Disk | Where-Object { $_.Number -ne $OsDiskNumber }
    if (-not $disks -or $disks.Count -eq 0) {
        Write-ADSLog -Message "No additional disks detected; skipping format." -Level "INFO"
        return
    }

    $scriptBuilder = New-Object System.Text.StringBuilder
    foreach ($disk in $disks) {
        $null = $scriptBuilder.AppendLine("select disk $($disk.Number)")
        $null = $scriptBuilder.AppendLine("online disk noerr")
        $null = $scriptBuilder.AppendLine("attributes disk clear readonly noerr")
        $null = $scriptBuilder.AppendLine("clean")
        $null = $scriptBuilder.AppendLine("convert gpt")
        $null = $scriptBuilder.AppendLine("create partition primary")
        $null = $scriptBuilder.AppendLine("format quick fs=ntfs label=`"Data$($disk.Number)`"")
        $null = $scriptBuilder.AppendLine("assign")
    }
    $null = $scriptBuilder.AppendLine("exit")

    $scriptPath = Join-Path -Path $env:TEMP -ChildPath "ads-extra-diskpart.txt"
    $scriptBuilder.ToString() | Set-Content -Path $scriptPath -Encoding ASCII

    if ($WhatIf) {
        Write-ADSLog -Message "WHATIF: diskpart /s $scriptPath" -Level "INFO"
        return
    }

    Write-ADSLog -Message "Formatting non-OS disks: $($disks.Number -join ', ')" -Level "INFO"
    Invoke-ADSExternalCommand -FilePath "diskpart.exe" -Arguments "/s `"$scriptPath`"" | Out-Null
}

Export-ModuleMember -Function Invoke-ADSNetworkingInit, Invoke-ADSDiskPartition, Set-ADSStaticNetwork, Invoke-ADSApplyImage, Invoke-ADSInjectDrivers, Invoke-ADSOfflinePackages, Set-ADSUnattendFile, Set-ADSPostInstallAssets, Invoke-ADSMakeBootable, Invoke-ADSReboot, Invoke-ADSFormatAdditionalDisks
