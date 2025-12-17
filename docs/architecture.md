# ADS Architecture

## Phases
- **WinPE phase**: The ADS Wizard collects deployment inputs and writes `deploy.json`. `Start-Deployment.ps1` runs in WinPE to partition disks, apply the image, inject optional drivers/packages, stage unattend and post-install assets, and make the OS bootable.
- **OS phase**: `SetupComplete.cmd` runs `PostInstall.ps1` inside the newly deployed OS. The script uses a state file (`C:\Deploy\state.json`) to continue across reboots, apply the Offline Domain Join (ODJ) blob, and execute post-install hooks.

## Components
- **ADS.Wizard (WinForms, .NET Framework 4.8)**: Gathers inputs, validates them, writes `deploy.json`, and launches the deployment engine in WinPE.
- **ADS.Workbench (WinForms, .NET Framework 4.8)**: Desktop prep tool for operators; assembles the payload/layout, collects media build inputs (ADK/WinPE roots, ISO path), and stages assets from shares using the current user’s access. It can front-load payload content into the ISO for offline deployments.
- **Start-Deployment.ps1**: Non-interactive WinPE deployment orchestrator. Uses DISM, diskpart, and bcdboot. Supports `-WhatIf` for safe dry runs.
- **PostInstall.ps1**: Runs after first boot via `SetupComplete.cmd`. Idempotent staged runner that applies the ODJ blob and executes placeholder hooks for patching and software installs.
- **PowerShell modules**: `ADS.Logging` (structured logging), `ADS.Deploy` (WinPE helpers), `ADS.State` (state persistence).

## JSON contract
Wizard output `deploy.json` schema:
- `ComputerName` (string, required)
- `OsVersion` (string: `Server2019|Server2022|Server2025`, required)
- `ImagePath` (string UNC or local path, required)
- `ImageIndex` (int, required)
- `TargetDisk` (int, required)
- `Platform` (string: `VMware|Proxmox`, required)
- `DriverPackPath` (string, optional)
- `UnattendTemplatePath` (string, optional)
- `OdjBlobPath` (string, optional)
- `UseStaticIp` (bool, optional; default DHCP)
- `StaticIpAddress` (string, required when `UseStaticIp` is true)
- `StaticSubnetMask` (string, required when `UseStaticIp` is true)
- `StaticGateway` (string, optional)
- `StaticDnsServers` (array of strings, optional)
- `Packages` (array of strings, optional)
- `SoftwareInstallers` (array of strings, optional)

The same file is copied into `C:\Deploy\deploy.json` for post-install use. No credentials are stored.

## Logging
- Wizard log: `X:\Deploy\ADS.Wizard.log` when available, else `%TEMP%`.
- WinPE deployment log: defaults to `X:\Deploy\ADS.Deployment.log` (or `%TEMP%` fallback).
- Post-install log: `C:\Deploy\PostInstall.log`.

## File layout
- `src/ADS.sln` - Visual Studio solution.
- `src/ADS.Wizard` - WinForms project (ADS.Wizard.exe).
- `src/ADS.Workbench` - WinForms project (ADS.Workbench.exe) for desktop prep and media build inputs.
- `scripts` - Deployment and post-install scripts plus shared modules.
- `docs` - Usage and architecture documentation.
- `.github/workflows` - CI and release pipelines.
