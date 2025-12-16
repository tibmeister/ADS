<#
.SYNOPSIS
Executes ADS post-install steps inside the deployed OS.
.DESCRIPTION
Advances through staged actions using a state file so reruns are safe and idempotent.
.EXAMPLES
PowerShell.exe -NoProfile -ExecutionPolicy Bypass -File C:\Deploy\PostInstall.ps1
.NOTES
Invoked by SetupComplete.cmd; stages continue after reboots until completion.
#>

[CmdletBinding()]
param(
    # Override for the state file path
    [string] $StatePath = "C:\Deploy\state.json",
    # Override for the log file path
    [string] $LogPath = "C:\Deploy\PostInstall.log",
    # Dry run to avoid system changes (for dev)
    [switch] $WhatIf
)

$script:Root = Split-Path -Parent $MyInvocation.MyCommand.Path
Import-Module "$Root\Lib\ADS.Logging.psm1" -Force
Import-Module "$Root\Lib\ADS.State.psm1" -Force

try {
    Set-ADSLogPath -Path $LogPath
}
catch {
    Write-Warning "Unable to set log path: $($_.Exception.Message)"
}

$configPath = "C:\Deploy\deploy.json"
$config = $null
if (Test-Path -Path $configPath) {
    try {
        $config = Get-Content -Path $configPath -Raw | ConvertFrom-Json
    }
    catch {
        Write-ADSLog -Message "Failed to parse config at $configPath: $($_.Exception.Message)" -Level "WARN"
    }
}

function Register-ADSContinuation {
    if ($WhatIf) {
        Write-ADSLog -Message "WHATIF: Would register RunOnce for post-install continuation." -Level "INFO"
        return
    }

    $cmd = "PowerShell.exe -NoProfile -ExecutionPolicy Bypass -File `"`"$($MyInvocation.MyCommand.Path)`"`""
    New-Item -Path "HKLM:\Software\Microsoft\Windows\CurrentVersion\RunOnce" -Force | Out-Null
    Set-ItemProperty -Path "HKLM:\Software\Microsoft\Windows\CurrentVersion\RunOnce" -Name "ADSPostInstall" -Value $cmd
    Write-ADSLog -Message "Continuation registered via RunOnce." -Level "INFO"
}

function Clear-ADSContinuation {
    if ($WhatIf) {
        Write-ADSLog -Message "WHATIF: Would clear RunOnce continuation." -Level "INFO"
        return
    }

    Remove-ItemProperty -Path "HKLM:\Software\Microsoft\Windows\CurrentVersion\RunOnce" -Name "ADSPostInstall" -ErrorAction SilentlyContinue
}

function Initialize-ADSDeployRoot {
    $root = "C:\Deploy"
    if (-not (Test-Path -Path $root)) {
        New-Item -ItemType Directory -Path $root -Force | Out-Null
    }
}

function Invoke-ADSOfflineDomainJoin {
    $blob = "C:\Deploy\ODJ\odjblob.txt"
    if (-not (Test-Path -Path $blob)) {
        Write-ADSLog -Message "ODJ blob not found; skipping domain join." -Level "INFO"
        return $true
    }

    if ($WhatIf) {
        Write-ADSLog -Message "WHATIF: Would apply ODJ using blob $blob" -Level "INFO"
        return $true
    }

    $args = "/requestODJ /loadfile `"$blob`" /localos"
    $exitCode = Start-Process -FilePath "djoin.exe" -ArgumentList $args -Wait -PassThru -NoNewWindow -ErrorAction SilentlyContinue | Select-Object -ExpandProperty ExitCode
    if ($exitCode -ne 0) {
        Write-ADSLog -Message "djoin.exe failed with exit code $exitCode" -Level "ERROR"
        return $false
    }

    Remove-Item -Path $blob -Force -ErrorAction SilentlyContinue
    Write-ADSLog -Message "Offline domain join applied and blob removed." -Level "INFO"
    return $true
}

Initialize-ADSDeployRoot
$state = Get-ADSState -Path $StatePath
Write-ADSLog -Message "Post-install starting at stage $($state.Stage)" -Level "INFO"

switch ($state.Stage) {
    0 {
        Register-ADSContinuation
        Set-ADSStateStage -Path $StatePath -Stage 1
        $state.Stage = 1
        Write-ADSLog -Message "Bootstrap complete; advancing to stage 1." -Level "INFO"
    }
    default { }
}

if ($state.Stage -eq 1) {
    $odjResult = Invoke-ADSOfflineDomainJoin
    if ($odjResult) {
        Set-ADSStateStage -Path $StatePath -Stage 2
        Write-ADSLog -Message "Stage 1 complete. Rebooting to continue." -Level "INFO"
        if (-not $WhatIf) {
            Restart-Computer -Force
            exit
        }
    }
    else {
        Write-ADSLog -Message "Stage 1 failed; halting post-install." -Level "ERROR"
        exit 10
    }
}

if ($state.Stage -eq 2) {
    Write-ADSLog -Message "Stage 2 placeholder: apply updates/patches." -Level "INFO"
    Set-ADSStateStage -Path $StatePath -Stage 3
    $state.Stage = 3
}

if ($state.Stage -eq 3) {
    Write-ADSLog -Message "Stage 3 placeholder: installing software packages." -Level "INFO"
    if ($config -and $config.SoftwareInstallers) {
        foreach ($installer in $config.SoftwareInstallers) {
            Write-ADSLog -Message "Install hook placeholder for $installer" -Level "INFO"
        }
    }
    Set-ADSStateStage -Path $StatePath -Stage 4
    $state.Stage = 4
}

if ($state.Stage -ge 4) {
    $completePath = "C:\Deploy\complete.txt"
    "Deployment complete $(Get-Date)" | Set-Content -Path $completePath -Encoding UTF8
    Clear-ADSContinuation
    Write-ADSLog -Message "Post-install complete. Marker written to $completePath" -Level "INFO"
}
