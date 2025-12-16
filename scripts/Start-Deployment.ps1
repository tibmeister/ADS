<#
.SYNOPSIS
Starts ADS deployment in WinPE.
.DESCRIPTION
Reads deployment JSON, validates inputs, and orchestrates offline deployment steps.
.EXAMPLES
.\Start-Deployment.ps1 -ConfigPath X:\Deploy\deploy.json -LogPath X:\Deploy\ADS.Deployment.log
.NOTES
Intended to run non-interactively from the ADS wizard.
#>

[CmdletBinding(SupportsShouldProcess = $true)]
param(
    # Path to deployment configuration JSON
    [Parameter(Mandatory = $true)]
    [string] $ConfigPath,
    # Optional log path override
    [string] $LogPath,
    # When set, skip reboot
    [switch] $NoReboot,
    # Dry run without destructive actions
    [switch] $WhatIf
)

$ErrorActionPreference = "Stop"

$Root = Split-Path -Parent $MyInvocation.MyCommand.Path
Import-Module "$Root/Lib/ADS.Logging.psm1" -Force
Import-Module "$Root/Lib/ADS.Deploy.psm1" -Force

function Get-DefaultLogPath {
    if (Test-Path -Path "X:\Deploy") {
        return "X:\Deploy\ADS.Deployment.log"
    }
    if (Test-Path -Path "C:\Deploy") {
        return "C:\Deploy\ADS.Deployment.log"
    }
    return Join-Path -Path $env:TEMP -ChildPath "ADS.Deployment.log"
}

function Stop-ADSDeployment {
    param(
        # Exit code
        [Parameter(Mandatory = $true)]
        [int] $Code
    )

    Write-ADSLog -Message "Exiting with code $Code" -Level "INFO"
    exit $Code
}

try {
    if (-not $LogPath) {
        $LogPath = Get-DefaultLogPath
    }
    Set-ADSLogPath -Path $LogPath
}
catch {
    Write-Warning "Unable to set log path: $($_.Exception.Message)"
}

Write-ADSLog -Message "ADS deployment starting. Config: $ConfigPath" -Level "INFO"

if (-not (Test-Path -Path $ConfigPath)) {
    Write-ADSLog -Message "Config file not found at $ConfigPath" -Level "ERROR"
    Stop-ADSDeployment -Code 2
}

try {
    $config = Get-Content -Path $ConfigPath -Raw | ConvertFrom-Json
}
catch {
    Write-ADSLog -Message "Failed to read config: $($_.Exception.Message)" -Level "ERROR"
    Stop-ADSDeployment -Code 3
}

$required = @("ComputerName", "OsVersion", "ImagePath", "ImageIndex", "TargetDisk", "Platform")
$missing = @()
foreach ($key in $required) {
    if (-not $config.$key) {
        $missing += $key
    }
}

if ($missing.Count -gt 0) {
    Write-ADSLog -Message "Missing required config values: $($missing -join ', ')" -Level "ERROR"
    Stop-ADSDeployment -Code 4
}

Write-ADSLog -Message "Deployment for $($config.ComputerName) targeting disk $($config.TargetDisk)" -Level "INFO"

try {
    Invoke-ADSNetworkingInit -WhatIf:$WhatIf
    Invoke-ADSDiskPartition -DiskNumber $config.TargetDisk -WhatIf:$WhatIf
    Invoke-ADSApplyImage -ImagePath $config.ImagePath -ImageIndex $config.ImageIndex -TargetDrive "W:" -WhatIf:$WhatIf
    Invoke-ADSInjectDrivers -TargetDrive "W:" -DriverPath $config.DriverPackPath -WhatIf:$WhatIf
    Invoke-ADSOfflinePackages -TargetDrive "W:" -Packages $config.Packages -WhatIf:$WhatIf
    Set-ADSUnattendFile -TargetDrive "W:" -UnattendPath $config.UnattendTemplatePath
    Set-ADSPostInstallAssets -TargetDrive "W:" -ScriptSource $Root -ConfigPath $ConfigPath -OdjBlobPath $config.OdjBlobPath
    Invoke-ADSMakeBootable -TargetDrive "W:" -WhatIf:$WhatIf

    if (-not $NoReboot) {
        Invoke-ADSReboot -WhatIf:$WhatIf
    }
    else {
        Write-ADSLog -Message "NoReboot flag set; skipping reboot." -Level "INFO"
    }
}
catch {
    Write-ADSLog -Message "Deployment failed: $($_.Exception.Message)" -Level "ERROR"
    Stop-ADSDeployment -Code 5
}

Stop-ADSDeployment -Code 0
