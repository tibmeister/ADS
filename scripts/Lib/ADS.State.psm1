<#
.SYNOPSIS
ADS state helpers.
.DESCRIPTION
Handles reading and writing deployment state across reboots.
.EXAMPLES
Get-ADSState -Path "C:\Deploy\state.json"
.NOTES
State schema is minimal and intended to be idempotent.
#>

function Get-ADSState {
    param(
        # Path to the state file
        [Parameter(Mandatory = $true)]
        [string] $Path
    )

    if (-not (Test-Path -Path $Path)) {
        return @{
            Stage = 0
            LastUpdated = (Get-Date)
        }
    }

    try {
        return Get-Content -Path $Path -Raw | ConvertFrom-Json
    }
    catch {
        throw "Unable to read state file at $Path: $($_.Exception.Message)"
    }
}

function Set-ADSState {
    param(
        # Path to the state file
        [Parameter(Mandatory = $true)]
        [string] $Path,
        # State object to write
        [Parameter(Mandatory = $true)]
        [psobject] $State
    )

    $State.LastUpdated = Get-Date
    $dir = Split-Path -Parent $Path
    if (-not [string]::IsNullOrWhiteSpace($dir)) {
        New-Item -ItemType Directory -Path $dir -Force | Out-Null
    }

    $State | ConvertTo-Json -Depth 5 | Set-Content -Path $Path -Encoding UTF8
}

function Set-ADSStateStage {
    param(
        # Path to state file
        [Parameter(Mandatory = $true)]
        [string] $Path,
        # Stage number
        [Parameter(Mandatory = $true)]
        [int] $Stage
    )

    $state = Get-ADSState -Path $Path
    $state.Stage = $Stage
    Set-ADSState -Path $Path -State $state
}

Export-ModuleMember -Function Get-ADSState, Set-ADSState, Set-ADSStateStage
