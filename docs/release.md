# Branching and Releases

## Branching model (GitHub Flow)
- `main` is protected and always releasable.
- New work happens in short-lived `feature/*` or `issue/*` branches.
- Changes merge back to `main` via Pull Requests with CI validation.

## Release tags
- Stable releases: `vX.Y.Z`
- Release candidates: `vX.Y.Z-rc.N` (publish GitHub Release marked as prerelease)
- Tags are created on `main` after PR merge.

## CI/CD
- `ci.yml` builds on pushes/PRs to `main`.
- `release.yml` triggers on semver tags (stable and rc), builds artifacts, zips outputs, and creates a GitHub Release. RC tags set `prerelease=true`.

## Stabilization branches (optional)
- If needed for hardening, create `release/vX.Y` from `main`, protect it while active, and delete it after publishing `vX.Y.Z`.
- Continue regular work on `main`; cherry-pick critical fixes into `release/vX.Y` as required.
