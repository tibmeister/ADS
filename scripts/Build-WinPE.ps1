<#
.SYNOPSIS
Creates a WinPE image with ADS payload.
.DESCRIPTION
Automates WinPE media creation using ADK tools (copype, MakeWinPEMedia) and copies ADS wizard/scripts into the ISO.
.EXAMPLES
.\Build-WinPE.ps1 -AdsPayloadPath C:\ADS\out -IsoPath C:\WinPE_ADS.iso
.NOTES
Requires Windows ADK + WinPE add-on installed and an elevated PowerShell session.
#>

[CmdletBinding(SupportsShouldProcess = $true)]
param(
    # WinPE architecture (amd64 or x86)
    [string] $Architecture = "amd64",
    # Working directory for WinPE build output
    [string] $WinPERoot = "C:\WinPE_amd64",
    # Folder containing ADS payload (ADS.Wizard.exe and scripts/)
    [Parameter(Mandatory = $true)]
    [string] $AdsPayloadPath,
    # Output ISO path
    [string] $IsoPath = "C:\WinPE_ADS.iso",
    # When set, only logs intended actions
    [switch] $WhatIf
)

$ErrorActionPreference = "Stop"

function Invoke-ADSExternalProcess {
    param(
        # Command to run
        [Parameter(Mandatory = $true)]
        [string] $FilePath,
        # Arguments
        [string] $Arguments
    )

    if ($WhatIf) {
        Write-Host "WHATIF: $FilePath $Arguments"
        return
    }

    Write-Host "Running: $FilePath $Arguments"
    $process = Start-Process -FilePath $FilePath -ArgumentList $Arguments -PassThru -Wait -NoNewWindow
    if ($process.ExitCode -ne 0) {
        throw "$FilePath exited with code $($process.ExitCode)"
    }
}

function Test-ADSToolAvailable {
    param(
        # Tool name to locate
        [Parameter(Mandatory = $true)]
        [string] $Name
    )

    $cmd = Get-Command $Name -ErrorAction SilentlyContinue
    if (-not $cmd) {
        throw "$Name not found. Install Windows ADK with WinPE add-on and run from the Deployment and Imaging Tools Environment."
    }
}

Test-ADSToolAvailable -Name "copype.cmd"
Test-ADSToolAvailable -Name "MakeWinPEMedia.cmd"

if (-not (Test-Path -Path $AdsPayloadPath)) {
    throw "AdsPayloadPath '$AdsPayloadPath' not found."
}

if ($PSCmdlet.ShouldProcess($WinPERoot, "Create WinPE working directory")) {
    if (Test-Path -Path $WinPERoot -PathType Container) {
        if (-not $WhatIf) {
            Remove-Item -Path $WinPERoot -Recurse -Force
        }
        else {
            Write-Host "WHATIF: Would remove existing $WinPERoot"
        }
    }

    Invoke-ADSExternalProcess -FilePath "copype.cmd" -Arguments "$Architecture `"$WinPERoot`""
}

$mediaRoot = Join-Path -Path $WinPERoot -ChildPath "media"
$destPayload = Join-Path -Path $mediaRoot -ChildPath "ADS"
$deployDir = Join-Path -Path $mediaRoot -ChildPath "Deploy"
$startNetPath = Join-Path -Path $mediaRoot -ChildPath "Windows\System32\startnet.cmd"

if ($PSCmdlet.ShouldProcess($destPayload, "Copy ADS payload")) {
    if (-not $WhatIf) {
        New-Item -ItemType Directory -Path $destPayload -Force | Out-Null
        New-Item -ItemType Directory -Path $deployDir -Force | Out-Null
        Copy-Item -Path (Join-Path $AdsPayloadPath "*") -Destination $destPayload -Recurse -Force
    }
    else {
        Write-Host "WHATIF: Would copy ADS payload from $AdsPayloadPath to $destPayload"
    }
}

if ($PSCmdlet.ShouldProcess($startNetPath, "Configure startnet.cmd to launch ADS bootstrapper")) {
    $startNetContent = @"
@echo off
set ADSROOT=X:\ADS
powershell.exe -NoProfile -ExecutionPolicy Bypass -File "%ADSROOT%\scripts\Bootstrapper.ps1"
"@
    if (-not $WhatIf) {
        $startNetContent | Set-Content -Path $startNetPath -Encoding ASCII
    }
    else {
        Write-Host "WHATIF: Would write bootstrapper startnet.cmd to $startNetPath"
    }
}

if ($PSCmdlet.ShouldProcess($IsoPath, "Create ISO")) {
    Invoke-ADSExternalProcess -FilePath "MakeWinPEMedia.cmd" -Arguments "/ISO `"$WinPERoot`" `"$IsoPath`""
}

Write-Host "WinPE ISO ready at $IsoPath (payload under \\sources\\boot.wim with ADS in X:\\ADS)."
