## Network Share Usage in ADS

The wizard can pull deployment assets from a network share during WinPE, stage them locally, and then drop the credentials. No share mapping or secrets persist into the deployed OS. For desktop prep and media creation, use ADS Workbench, which relies on the user's existing share access and does not prompt for credentials.

### How it works
- **Wizard input:** Fields for `NetworkSharePath`, `NetworkUsername`, and `NetworkPassword` (masked). Validation requires a full set (path + user + password) or nothing.
- **WinPE-only staging:** Before writing `deploy.json` or launching `Start-Deployment.ps1`, the wizard:
  - Runs `net use` to authenticate to the share (non-persistent).
  - Copies referenced assets that are on UNC paths (OS image, driver pack folder, unattend template, ODJ blob, package paths) into a local staging folder (`X:\Deploy\Assets` in WinPE, `%TEMP%\ADS.Assets` elsewhere).
  - Rewrites the config paths to point to the staged copies.
  - Clears the share credentials from the in-memory config so they are **not** written to `deploy.json`.
  - Drops the share connection with `net use <share> /delete`.
- **Deployment run:** `Start-Deployment.ps1` now works only with local paths; it does not map shares or use credentials.
- **Post-install:** No share credentials are stored or reused; post-install runs from the staged assets.

### Security considerations
- **No persisted secrets:** Credentials never hit disk; they live only in memory while staging and are cleared before `deploy.json` is saved.
- **Least privilege:** Use a read-only, scope-limited share account; if compromised it should only access deployment assets.
- **Logging hygiene:** Logs record success/failure but never the password.
- **Dry runs:** `-WhatIf` still works for deployment scripts; staging occurs in the wizard before invoking them.

### Operator guidance
- Provide a dedicated, least-privilege account scoped to the asset share.
- Ensure the share path and credentials are all provided together if you want remote assets pulled; otherwise leave them blank.
- Expect the wizard to copy required files into `X:\Deploy\Assets` during WinPE; thereafter the deployment runs entirely from local media.
