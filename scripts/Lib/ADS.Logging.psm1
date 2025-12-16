<#
.SYNOPSIS
ADS logging helpers.
.DESCRIPTION
Provides lightweight structured logging helpers for ADS.
.EXAMPLES
Write-ADSLog -Message "hello"
.NOTES
Log path is set once per session; functions are idempotent.
#>

$script:LogPath = $null

function Set-ADSLogPath {
    param(
        # Path to the log file to write
        [Parameter(Mandatory = $true)]
        [string] $Path
    )

    $script:LogPath = $Path
    $dir = Split-Path -Parent $Path
    if (-not [string]::IsNullOrWhiteSpace($dir)) {
        New-Item -ItemType Directory -Path $dir -Force | Out-Null
    }
}

function Get-ADSLogPath {
    <#
    .SYNOPSIS
    Returns the current log path.
    .DESCRIPTION
    Returns the path set by Set-ADSLogPath.
    .EXAMPLES
    Get-ADSLogPath
    .NOTES
    Returns $null if unset.
    #>
    return $script:LogPath
}

function Write-ADSLog {
    <#
    .SYNOPSIS
    Writes a structured log line.
    .DESCRIPTION
    Prepends a timestamp and level to the log message.
    .EXAMPLES
    Write-ADSLog -Message "starting" -Level "INFO"
    .NOTES
    Writes to host as well as the log file if available.
    #>
    param(
        # Message to log
        [Parameter(Mandatory = $true)]
        [string] $Message,
        # Log level name
        [string] $Level = "INFO"
    )

    $timestamp = (Get-Date).ToString("yyyy-MM-dd HH:mm:ss")
    $line = "$timestamp [$Level] $Message"
    Write-Host $line

    if ([string]::IsNullOrWhiteSpace($script:LogPath)) {
        return
    }

    try {
        Add-Content -Path $script:LogPath -Value $line -Encoding UTF8 -ErrorAction SilentlyContinue
    }
    catch {
        Write-Warning "Failed to write to log file $($script:LogPath): $($_.Exception.Message)"
    }
}

Export-ModuleMember -Function Write-ADSLog, Set-ADSLogPath, Get-ADSLogPath
