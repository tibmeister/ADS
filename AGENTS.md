# ADS - Agent Notes

## Overview
Automated Deployment and Servicing (ADS) supplies a WinForms wizard for WinPE to collect deployment settings, emit `deploy.json`, and drive PowerShell automation that lays down a WIM image and executes staged post-install actions (including ODJ application).

## Architecture and layout
- `src/ADS.sln` - solution.
- `src/ADS.Wizard` - WinForms app targeting .NET Framework 4.8 (`ADS.Wizard.exe`).
- `scripts/Start-Deployment.ps1` - WinPE deployment orchestrator (non-interactive).
- `scripts/PostInstall.ps1` - OS-phase runner triggered by `SetupComplete.cmd`.
- `scripts/Lib` - shared modules (`ADS.Logging`, `ADS.Deploy`, `ADS.State`).
- `scripts/Build-WinPE.ps1` - automates WinPE ISO creation (requires ADK + WinPE add-on).
- `docs` - usage, architecture, build, ODJ, release, and WinPE build guides.
- `.github/workflows` - `ci.yml` and `release.yml`.

## Prerequisites
- Windows build host with MSBuild for .NET Framework 4.8 (Visual Studio Build Tools) and NuGet CLI on PATH.
- PowerShell available (5.1 in Windows, or 7+ if testing outside WinPE).
- Windows ADK + WinPE add-on installed on the build host to create WinPE media (ensure `copype.cmd` and `MakeWinPEMedia.cmd` are on PATH in the Deployment and Imaging Tools Environment; run elevated).
- Git to clone and manage branches (GitHub Flow).
- VS Code optional but recommended for tasks/launch config.

## Build instructions
- **Local (PowerShell, Windows):**
  ```powershell
  nuget restore src/ADS.sln
  msbuild src/ADS.sln /t:Build /p:Configuration=Release /p:Platform="Any CPU"
  ```
- **VS Code:** Tasks `Build Wizard (Debug)` and `Build Wizard (Release)` in `.vscode/tasks.json`.
- **Debugging:** `.vscode/launch.json` launches `src/ADS.Wizard/bin/Debug/ADS.Wizard.exe`.
- **CI:** `ci.yml` runs on PRs/pushes to `main`, builds Release, and uploads `ADS.Wizard-drop` zip. `release.yml` builds on semver tags and publishes zipped artifacts plus a GitHub Release (prerelease for `-rc.` tags).
- **WinPE ISO build:** In the Deployment and Imaging Tools Environment (elevated) with ADK + WinPE add-on installed, run `.\scripts\Build-WinPE.ps1 -AdsPayloadPath "<payload folder>" -WinPERoot "C:\WinPE_amd64" -IsoPath "C:\WinPE_ADS.iso"`; use `-WhatIf` to dry-run. See `docs/winpe-build.md` for manual steps.

## Coding standards
- **PowerShell:** OTBS/K&R braces; comment-based help with `SYNOPSIS`, `DESCRIPTION`, `EXAMPLES`, `NOTES` only; inline comments above `param()` entries; prefer idempotent functions and explicit exit codes; no C# embedded; structured logging via `ADS.Logging`.
- **C#:** .NET Framework 4.8; namespace `ADS.Wizard`; prefer clear naming (PascalCase types, camelCase locals), guard clauses for validation, minimal dependencies (Newtonsoft.Json via NuGet), and deterministic logging/error handling.

## Tests
- Placeholder: no automated tests yet. Manual verification via `msbuild` and launching `ADS.Wizard.exe`. Future unit tests should live under `tests/` and run via VS Code tasks and CI.

## Releases
- Tags on `main`: stable `vX.Y.Z`, release candidates `vX.Y.Z-rc.N` (prerelease flag).
- Release workflow packages wizard binaries, scripts, docs into `ADS-<tag>.zip` and attaches to GitHub Release.
- If stabilization is required, use temporary `release/vX.Y` branches, protect while active, delete after the final release.

## Branching and protection
- GitHub Flow: short-lived `feature/*` or `issue/*` → PR → `main`.
- `main` must be protected (status checks required, no force-push, require PR reviews).
- If used, `release/vX.Y` should also be protected during stabilization.

## Session recreation
From a new environment:
```powershell
git clone <repo-url> ADS
cd ADS
git status
```
Build and run from repo root:
```powershell
git status
nuget restore src/ADS.sln
msbuild src/ADS.sln /t:Build /p:Configuration=Release /p:Platform="Any CPU"
& "src/ADS.Wizard/bin/Release/ADS.Wizard.exe"
```
Build WinPE ISO (requires ADK + WinPE add-on, run from Deployment and Imaging Tools Environment elevated):
```powershell
.\scripts\Build-WinPE.ps1 -AdsPayloadPath "C:\path\to\ADS\payload" -WinPERoot "C:\WinPE_amd64" -IsoPath "C:\WinPE_ADS.iso"
```
Outputs:
- Wizard binary: `src/ADS.Wizard/bin/<Config>/ADS.Wizard.exe`
- Logs during WinPE/OS runs: `X:\Deploy\ADS.Wizard.log`, `X:\Deploy\ADS.Deployment.log`, `C:\Deploy\PostInstall.log`
- WinPE ISO example: `C:\WinPE_ADS.iso` containing ADS under `X:\ADS` and writable `X:\Deploy`.
- Static IP (optional): enable in the wizard and set IP/mask/gateway/DNS; deployment script applies it via netsh before imaging.
- ODJ (optional): provide an ODJ blob path; if omitted, domain join is skipped and post-install continues safely.

## Quick validation checklist for a fresh session
- `rg "UseStaticIp" src scripts` should return occurrences in `MainForm.*`, `DeploymentConfig`, and `Start-Deployment.ps1`.
- `rg "Set-ADSStaticNetwork" scripts` should show the netsh helper in `scripts/Lib/ADS.Deploy.psm1` and its invocation in `scripts/Start-Deployment.ps1`.
- `rg "ODJ blob" scripts/PostInstall.ps1` to confirm domain join is optional when no blob exists.
- Ensure `.vscode/tasks.json` targets `msbuild src/ADS.sln` (Debug/Release). 
- Verify CI workflows exist: `.github/workflows/ci.yml` and `release.yml`.
