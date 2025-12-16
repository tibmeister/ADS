# Build Guide

## Prerequisites
- Windows with Visual Studio Build Tools (MSBuild for .NET Framework 4.8).
- NuGet CLI available on PATH (present on GitHub runners).
- VS Code (recommended) with tasks/launch configs from `.vscode`.

## Local build (PowerShell)
```powershell
nuget restore src/ADS.sln
msbuild src/ADS.sln /t:Build /p:Configuration=Release /p:Platform="Any CPU"
```
Artifacts:
- `src/ADS.Wizard/bin/Release/ADS.Wizard.exe` (WinPE wizard)
- `src/ADS.Workbench/bin/Release/ADS.Workbench.exe` (desktop prep tool)

## VS Code tasks
- `Build Wizard (Debug)` - builds Debug configuration via MSBuild.
- `Build Wizard (Release)` - builds Release configuration via MSBuild.
  - Add analogous tasks for Workbench if needed; both projects build via the solution command above.

## Debugging the wizard
- Use `.vscode/launch.json` configuration `Debug ADS.Wizard` (assumes Debug build output at `src/ADS.Wizard/bin/Debug/ADS.Wizard.exe`).
- Workbench can be run directly from `src/ADS.Workbench/bin/Debug/ADS.Workbench.exe`.

## CI expectations
- `ci.yml` restores NuGet packages, builds Release on `windows-latest`, and uploads `ADS.Wizard.zip` as artifact `ADS.Wizard-drop`.
- `release.yml` builds on semver tags, zips wizard output plus scripts/docs, and publishes a GitHub Release (RC tags are prereleases). Include Workbench when distributing desktop tooling.
