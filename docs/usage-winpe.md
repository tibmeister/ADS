# Using ADS in WinPE

## Expected layout in WinPE media
- Place `ADS.Wizard.exe` and the `scripts` folder on the WinPE ISO (for example under `X:\ADS\`).
- Ensure `X:\Deploy\` exists to collect `deploy.json` and log files.
- For building custom media, see `docs/winpe-build.md` or run `scripts/Build-WinPE.ps1` after installing the Windows ADK + WinPE add-on.

## Running the wizard
1) Boot WinPE with network access to the deployment share hosting the WIM.
2) Launch `ADS.Wizard.exe`.
3) Enter required fields:
   - Computer Name
   - OS Version (Server2019/2022/2025)
   - Image Path (UNC recommended)
   - Image Index
   - Target Disk (default 0)
   - Platform (VMware or Proxmox)
4) Optional fields:
   - Driver pack path
   - Unattend template path
   - ODJ blob path (recommended for domain join)
5) Choose save location for `deploy.json` (defaults to `X:\Deploy\deploy.json` when available).
6) Click **Start Deployment** to write `deploy.json` and call `scripts/Start-Deployment.ps1`.

## Permissions and credentials
- The wizard does not persist credentials. Access to UNC paths should be pre-authenticated or handled via WinPE `net use` before launching the wizard.

## Logs
- Wizard log: `X:\Deploy\ADS.Wizard.log` (fallback to `%TEMP%`).
- Deployment log: `X:\Deploy\ADS.Deployment.log` (or `%TEMP%`).

## Deployment flow in WinPE
1) Initialize networking (`wpeinit` when present).
2) Partition target disk as GPT/UEFI and assign `W:` to the OS partition.
3) Apply the WIM image via DISM.
4) Optionally inject drivers and offline packages.
5) Stage unattend template if provided.
6) Stage post-install assets and ODJ blob.
7) Make bootable via `bcdboot`.
8) Reboot unless suppressed.
