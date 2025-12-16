<#
.SYNOPSIS
Starts the ADS WinPE experience.
.DESCRIPTION
Initializes networking, sets working directories, and launches ADS.Wizard.exe. Intended to run at WinPE startup (e.g., from startnet.cmd).
.NOTES
Optional helper; safe to call manually from WinPE.
#>

[CmdletBinding()]
param(
    # Path to ADS root containing ADS.Wizard.exe and scripts\
    [string] $AdsRoot = "X:\ADS",
    # Path to deploy working directory
    [string] $DeployRoot = "X:\Deploy",
    # When set, only logs intended actions
    [switch] $WhatIf
)

$ErrorActionPreference = "Stop"

function Write-BootstrapLog {
    param([string] $Message, [string] $Level = "INFO")
    $timestamp = Get-Date -Format "yyyy-MM-dd HH:mm:ss"
    $line = "$timestamp [$Level] $Message"
    $logPath = Join-Path -Path $DeployRoot -ChildPath "ADS.Bootstrapper.log"
    try {
        Add-Content -Path $logPath -Value $line -Force
    }
    catch {
        # best effort
    }
    Write-Host $line
}

try {
    if (-not (Test-Path -Path $DeployRoot)) {
        if (-not $WhatIf) {
            New-Item -ItemType Directory -Path $DeployRoot -Force | Out-Null
        }
        Write-BootstrapLog "Created deploy root at $DeployRoot"
    }

    # Initialize networking (wpeinit)
    $wpeinit = (Get-Command "wpeinit.exe" -ErrorAction SilentlyContinue)?.Source
    if ($wpeinit) {
        if ($WhatIf) {
            Write-BootstrapLog "WHATIF: wpeinit.exe"
        }
        else {
            Write-BootstrapLog "Running wpeinit..."
            & $wpeinit | Out-Null
        }
    }
    else {
        Write-BootstrapLog "wpeinit.exe not found; continuing without it." "WARN"
    }

    # Launch wizard
    $wizardPath = Join-Path -Path $AdsRoot -ChildPath "ADS.Wizard.exe"
    if (-not (Test-Path -Path $wizardPath)) {
        Write-BootstrapLog "ADS.Wizard.exe not found at $wizardPath" "ERROR"
        exit 2
    }

    if ($WhatIf) {
        Write-BootstrapLog "WHATIF: Would start $wizardPath"
        exit 0
    }

    Write-BootstrapLog "Starting ADS Wizard from $wizardPath"
    Start-Process -FilePath $wizardPath -WorkingDirectory $AdsRoot
}
catch {
    Write-BootstrapLog "Bootstrap failed: $($_.Exception.Message)" "ERROR"
    exit 1
}
