# Building WinPE Media with ADS

## Prerequisites
- Windows host with administrator rights.
- Windows ADK installed (Deployment Tools) and the **WinPE add-on** for the same ADK version.
- Use the **Deployment and Imaging Tools Environment** (elevated) so `copype.cmd`, `MakeWinPEMedia.cmd`, `dism.exe`, and `oscdimg.exe` are on PATH.
- MSBuild for .NET Framework 4.8 if you need to rebuild the wizard or Workbench.
- ADS payload folder containing `ADS.Wizard.exe` and the `scripts` directory (Workbench can help assemble this locally).
  - `Build-WinPE.ps1` writes `startnet.cmd` to call `X:\ADS\scripts\Bootstrapper.ps1`, which runs `wpeinit`, ensures `X:\Deploy`, and launches `ADS.Wizard.exe` automatically at boot.

## Quick steps (Deployment and Imaging Tools Environment)
```cmd
copype amd64 C:\WinPE_amd64
robocopy C:\path\to\ADS\payload C:\WinPE_amd64\media\ADS /E
mkdir C:\WinPE_amd64\media\Deploy
MakeWinPEMedia /ISO C:\WinPE_amd64 C:\WinPE_ADS.iso
```
- The payload folder should include `ADS.Wizard.exe` and `scripts\*`.
- `MakeWinPEMedia` generates `C:\WinPE_ADS.iso` with ADS under `X:\ADS` and a writable `X:\Deploy` folder on boot.

## Automated script
Run from the Deployment and Imaging Tools Environment (elevated):
```powershell
cd C:\path\to\ADS\repo
.\scripts\Build-WinPE.ps1 `
  -AdsPayloadPath "C:\path\to\ADS\payload" `
  -WinPERoot "C:\WinPE_amd64" `
  -IsoPath "C:\WinPE_ADS.iso"
```
Notes:
- Requires ADK + WinPE add-on installed; the script checks for `copype.cmd` and `MakeWinPEMedia.cmd`.
- `-WhatIf` shows actions without modifying disk.
- The script rebuilds the WinPE working directory each run.
- `ADS.Workbench` is a desktop GUI that can collect the payload layout and kick off ISO creation using these same inputs. Its **Front-load assets** option stages a temp copy of the payload and embeds it into the ISO for offline use.

## Payload preparation
- Build the apps: `nuget restore src/ADS.sln` then `msbuild src/ADS.sln /t:Build /p:Configuration=Release /p:Platform="Any CPU"`.
- Collect payload into a folder, for example:
  - `ADS.Wizard.exe` (and its Release dependencies) from `src/ADS.Wizard/bin/Release/`
  - `scripts\` directory
  - Optional docs for field reference.
  - `ADS.Workbench.exe` lives in `src/ADS.Workbench/bin/Release/` for desktop prep (not needed on the ISO).

## Booting and usage
- Boot target from `C:\WinPE_ADS.iso` (burn to USB/ISO mount).
- WinPE can auto-start via `startnet.cmd` calling `scripts\Bootstrapper.ps1` to run `wpeinit`, ensure `X:\Deploy`, and launch `X:\ADS\ADS.Wizard.exe`.
- If launching manually, run `X:\ADS\scripts\Bootstrapper.ps1` or start `X:\ADS\ADS.Wizard.exe`; logs and `deploy.json` default to `X:\Deploy`.

