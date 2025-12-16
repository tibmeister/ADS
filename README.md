# Automated Deployment and Servicing (ADS)

Automated Deployment and Servicing (ADS) provides a WinPE-friendly wizard to capture deployment settings, generate a JSON configuration, and drive a scripted offline deployment plus post-install actions.

- **Wizard (WinForms, .NET Framework 4.8)**: Collects inputs, validates them, writes `deploy.json`, and launches the deployment script.
- **Deployment engine (PowerShell)**: Runs in WinPE to partition disks, apply the WIM, inject optional drivers/packages, stage unattend/post-install assets, and make the image bootable.
- **Post-install runner (PowerShell)**: Executes from `SetupComplete.cmd` to apply the Offline Domain Join (ODJ) blob and continue staged tasks across reboots.

## Components
- `src/ADS.sln` - Visual Studio solution.
- `src/ADS.Wizard` - WinForms wizard (`ADS.Wizard.exe`).
- `scripts` - `Start-Deployment.ps1`, `PostInstall.ps1`, and shared modules.
- `docs` - Architecture, build, usage, ODJ, and release guides.
- `docs/winpe-build.md` - Building WinPE media with ADS payload.
- `.github/workflows` - CI build and tagged release workflows.

## Current status
- Minimal but compiling WinForms wizard targeting .NET Framework 4.8.
- Deployment/Post-install scripts scaffolded with clear logging and safety guards (`-WhatIf` for destructive steps).
- CI builds on Windows runners and uploads zipped wizard output; release workflow publishes tagged artifacts.

## Build and run locally (PowerShell, Windows)
```powershell
nuget restore src/ADS.sln
msbuild src/ADS.sln /t:Build /p:Configuration=Release /p:Platform="Any CPU"
& "src/ADS.Wizard/bin/Release/ADS.Wizard.exe"
```
In WinPE, place the wizard and `scripts` folder on your media (e.g., `X:\ADS`), ensure `X:\Deploy` exists, and run the wizard. Logs default to `X:\Deploy\ADS.Wizard.log` and `X:\Deploy\ADS.Deployment.log`.

## Branching and releases
- GitHub Flow: work in `feature/*` or `issue/*`, merge to `main` via PR.
- Tags on `main` create releases:
  - Stable: `vX.Y.Z`
  - Release candidate: `vX.Y.Z-rc.N` (prerelease flag)
- Optional stabilization: temporary `release/vX.Y` branches if needed, then deleted after release.

## Documentation
- Architecture: `docs/architecture.md`
- Build: `docs/build.md`
- Usage in WinPE: `docs/usage-winpe.md`
- Offline Domain Join: `docs/odj.md`
- Releases and branching: `docs/release.md`
