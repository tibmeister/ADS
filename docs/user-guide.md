# ADS User Guide

This guide covers preparing deployment media, configuring deployments, and running ADS in the field. It includes both desktop tooling (ADS Workbench) and the WinPE wizard (ADS Wizard), plus the underlying automation.

## Audience and scope
- **Operators/technicians:** Use Workbench to assemble payloads and build WinPE ISOs; use the Wizard in WinPE to collect deployment settings.
- **Engineers:** Understand architecture, inputs/outputs, and how to extend the scripts.

## Components at a glance
- **ADS.Workbench** (desktop, WinForms): Prepares the ADS payload layout, builds WinPE media, and can front-load assets for offline deployments.
- **ADS.Wizard** (WinPE, WinForms): Collects deployment inputs, stages assets in WinPE, writes `deploy.json`, and kicks off deployment.
- **scripts/Start-Deployment.ps1**: Non-interactive WinPE orchestrator (partition, apply WIM, inject drivers/packages, stage post-install assets, make bootable).
- **scripts/PostInstall.ps1**: Runs after first boot via `SetupComplete.cmd`, applies ODJ if provided, and executes staged hooks.
- **scripts/Lib**: Shared modules (`ADS.Logging`, `ADS.Deploy`, `ADS.State`).
- **docs**: Usage, build, architecture, ODJ, and WinPE build references.

## Workbench (desktop) — Preparing payload and ISO
Workbench uses your current user’s access (no credential prompts).

1) **Build binaries** (if needed):
   ```powershell
   nuget restore src/ADS.sln
   msbuild src/ADS.sln /t:Build /p:Configuration=Release /p:Platform="Any CPU"
   ```
   - Outputs: `src/ADS.Workbench/bin/Release/ADS.Workbench.exe`, `src/ADS.Wizard/bin/Release/ADS.Wizard.exe`.

2) **Launch Workbench** from `src/ADS.Workbench/bin/Release/ADS.Workbench.exe`.

3) **Fill inputs:**
   - **Network Share Path:** UNC where payload lives (wizard/scripts/drivers, etc.).
   - **Payload Layout Dir:** Local folder where the payload will be assembled (e.g., `C:\ADS\payload`).
   - **ADK/WinPE Root Dir:** Working directory for WinPE build (e.g., `C:\WinPE_amd64`).
   - **ISO Output Path:** Target ISO path (e.g., `C:\WinPE_ADS.iso`).
   - **Front-load assets:** Check to copy required content into the ISO for offline deployment (larger ISO; no share dependency in the field).

4) **Save Settings** (stubbed placeholder) and **Build WinPE ISO** (to be wired to `scripts/Build-WinPE.ps1`).

5) **Resulting payload:** ISO containing `ADS.Wizard.exe` + `scripts` under `X:\ADS`, writable `X:\Deploy`, and optionally front-loaded assets.
6) **WinPE auto-start (optional):** Configure `startnet.cmd` on the media to call `X:\ADS\scripts\Bootstrapper.ps1`, which runs `wpeinit`, ensures `X:\Deploy`, and launches the wizard automatically.

## Wizard (WinPE) — Collecting deployment settings
1) Boot from the ADS WinPE ISO/USB (prepared manually or via Workbench).
2) Ensure `X:\Deploy` exists (created by media layout).
3) Launch `X:\ADS\ADS.Wizard.exe`.
4) Enter required fields:
   - Computer Name
   - OS Version (`Server2019|Server2022|Server2025`)
   - Image Path (UNC or local)
   - Image Index
   - Target Disk
   - Platform (VMware, Proxmox)
5) Optional:
   - Driver pack path
   - Unattend template
   - ODJ blob
   - Packages (paths)
   - Static IP (IP, subnet, gateway, DNS)
   - Network share staging (UNC paths are copied locally; credentials not persisted)
6) Save location for `deploy.json` (defaults to `X:\Deploy\deploy.json` when available).
7) Click **Start Deployment** to write config and invoke `Start-Deployment.ps1`.

## Deployment flow (WinPE)
1) Initialize networking (`wpeinit`).
2) Partition target disk (GPT/UEFI), assign `W:` to OS partition.
3) Apply WIM image via DISM.
4) Inject drivers (optional).
5) Add offline packages (optional).
6) Stage unattend (optional).
7) Stage post-install assets and ODJ blob.
8) Make bootable via `bcdboot`.
9) Reboot (unless suppressed).

## Post-install flow (OS)
1) `SetupComplete.cmd` triggers `C:\Deploy\PostInstall.ps1`.
2) Uses `C:\Deploy\state.json` for idempotent stages.
3) Stage 1: Apply ODJ blob if present; reboot.
4) Stage 2/3: Placeholder for updates/software installers (extend as needed).
5) Stage 4+: Write `C:\Deploy\complete.txt`, clear RunOnce continuation.

## Configuration contract (`deploy.json`)
- `ComputerName` (string, required)
- `OsVersion` (string: `Server2019|Server2022|Server2025`, required)
- `ImagePath` (string, required)
- `ImageIndex` (int, required)
- `TargetDisk` (int, required)
- `Platform` (string: `VMware|Proxmox`, required)
- `DriverPackPath` (string, optional)
- `UnattendTemplatePath` (string, optional)
- `OdjBlobPath` (string, optional)
- `UseStaticIp` (bool, optional)
- `StaticIpAddress`, `StaticSubnetMask` (required when static)
- `StaticGateway` (optional)
- `StaticDnsServers` (string array, optional)
- `Packages` (string array, optional)
- `SoftwareInstallers` (string array, optional)

No credentials are stored.

## Build and CI quick reference
- Build: `nuget restore src/ADS.sln` then `msbuild src/ADS.sln /t:Build /p:Configuration=Release /p:Platform="Any CPU"`.
- Artifacts: `ADS.Wizard.exe` (WinPE), `ADS.Workbench.exe` (desktop).
- CI: `ci.yml` builds Release on pushes/PRs; `release.yml` builds on semver tags and zips outputs (include Workbench for desktop distribution).

## WinPE media build (manual)
```cmd
copype amd64 C:\WinPE_amd64
robocopy C:\path\to\ADS\payload C:\WinPE_amd64\media\ADS /E
mkdir C:\WinPE_amd64\media\Deploy
MakeWinPEMedia /ISO C:\WinPE_amd64 C:\WinPE_ADS.iso
```
Payload: `ADS.Wizard.exe`, `scripts\*` (including `Bootstrapper.ps1`), optional docs, plus any front-loaded assets if desired.

## Security notes
- Wizard and Workbench do not persist credentials. Use your current user context or pre-auth `net use`.
- ODJ blobs are sensitive; handle like credentials and remove after use.
- Front-loading assets increases ISO size but enables offline deployments.

## Troubleshooting
- **WinPE networking:** Run `wpeinit` or `ipconfig` to verify; apply static IP via wizard if needed.
- **Disk partition issues:** Confirm disk number; target disk is wiped/repartitioned.
- **Missing assets:** Use front-load option or ensure share access; logs in `X:\Deploy\ADS.Wizard.log` and `X:\Deploy\ADS.Deployment.log`.
- **Post-install stalls:** Check `C:\Deploy\PostInstall.log` and `C:\Deploy\state.json` stage; ensure ODJ blob path is correct.

## Extensibility
- Add post-install hooks in `PostInstall.ps1` stages 2/3.
- Extend `Start-Deployment.ps1` for additional offline tasks.
- Update Workbench to wire buttons to `scripts/Build-WinPE.ps1` with selected paths and the front-load flag.
