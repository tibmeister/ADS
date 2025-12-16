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
Artifacts are written to `src/ADS.Wizard/bin/Release/ADS.Wizard.exe`.

## VS Code tasks
- `Build Wizard (Debug)` - builds Debug configuration via MSBuild.
- `Build Wizard (Release)` - builds Release configuration via MSBuild.

## Debugging the wizard
- Use `.vscode/launch.json` configuration `Debug ADS.Wizard` (assumes Debug build output at `src/ADS.Wizard/bin/Debug/ADS.Wizard.exe`).

## CI expectations
- `ci.yml` restores NuGet packages, builds Release on `windows-latest`, and uploads `ADS.Wizard.zip` as artifact `ADS.Wizard-drop`.
- `release.yml` builds on semver tags, zips wizard output plus scripts/docs, and publishes a GitHub Release (RC tags are prereleases).
