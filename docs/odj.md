# Offline Domain Join (ODJ)

## Generating an ODJ blob
Run from a domain-joined management host with appropriate privileges:
```powershell
djoin.exe /provision /domain CONTOSO /machine ADS-TEST /savefile C:\temp\odjblob.txt /reuse
```
Adjust `CONTOSO` and machine name accordingly. The blob file is sensitive and should be protected in transit and at rest.

## Using with ADS
- Provide the blob path to the wizard (or copy it into `X:\Deploy\ODJ\odjblob.txt` before running WinPE).
- `Start-Deployment.ps1` copies the blob into `W:\Deploy\ODJ\odjblob.txt` (later `C:\Deploy\ODJ\odjblob.txt`).
- `PostInstall.ps1` applies the blob in Stage 1 using `djoin.exe /localos`, then deletes the blob on success.

## Security considerations
- Handle the blob as a credential artifact; limit access and clean up after application.
- Do not embed credentials in `deploy.json`.
- Prefer isolated staging shares or removable media for the blob when working in WinPE.
