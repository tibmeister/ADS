using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ADS.Workbench
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            txtIsoPath.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ADS-WinPE.iso");
        }

        private void BtnBrowseShare_Click(object sender, EventArgs e)
        {
            BrowseForFolder(txtSharePath);
        }

        private void BtnBrowseLayout_Click(object sender, EventArgs e)
        {
            BrowseForFolder(txtLayoutRoot);
        }

        private void BtnBrowseAdk_Click(object sender, EventArgs e)
        {
            BrowseForFolder(txtAdkRoot);
        }

        private void BtnBrowseIso_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "ISO file (*.iso)|*.iso|All files (*.*)|*.*";
                dialog.FileName = txtIsoPath.Text;
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    txtIsoPath.Text = dialog.FileName;
                }
            }
        }

        private void BtnSaveProfile_Click(object sender, EventArgs e)
        {
            try
            {
                var suggested = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ADS.Workbench.profile.json");
                using (var dialog = new SaveFileDialog())
                {
                    dialog.Filter = "JSON file (*.json)|*.json|All files (*.*)|*.*";
                    dialog.FileName = suggested;
                    if (dialog.ShowDialog(this) != DialogResult.OK)
                    {
                        return;
                    }

                    var profileJson = BuildProfileJson();
                    File.WriteAllText(dialog.FileName, profileJson);
                    WriteLog($"Profile saved to {dialog.FileName}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Failed to save profile: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteLog($"Profile save failed: {ex.Message}");
            }
        }

        private void BtnBuildIso_Click(object sender, EventArgs e)
        {
            var payloadRoot = txtLayoutRoot.Text.Trim();
            var winpeRoot = txtAdkRoot.Text.Trim();
            var isoPath = txtIsoPath.Text.Trim();
            var sharePath = txtSharePath.Text.Trim();
            var frontLoad = chkFrontLoadAssets.Checked;

            if (string.IsNullOrWhiteSpace(payloadRoot) || !Directory.Exists(payloadRoot))
            {
                MessageBox.Show(this, "Payload layout directory is required and must exist.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(isoPath))
            {
                MessageBox.Show(this, "Please specify an ISO output path.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string scriptPath = ResolveBuildScriptPath(sharePath);
            if (string.IsNullOrWhiteSpace(scriptPath) || !File.Exists(scriptPath))
            {
                MessageBox.Show(this, "Could not locate scripts/Build-WinPE.ps1. Ensure the scripts folder is present (either beside this app or under the share).", "Script Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            WriteLog($"Starting Build-WinPE.ps1 using payload '{payloadRoot}' -> ISO '{isoPath}'. Front-load assets: {chkFrontLoadAssets.Checked}");

            string workingPayload = payloadRoot;
            string stagingPath = null;

            try
            {
                if (frontLoad)
                {
                    stagingPath = CreateStagingCopy(payloadRoot);
                    workingPayload = stagingPath;
                    WriteLog($"Front-load staging created at '{stagingPath}'. This content will be embedded into the ISO.");
                }

                var psArgs = BuildPowerShellArguments(scriptPath, workingPayload, isoPath, winpeRoot, frontLoad);
                RunPowerShell(psArgs);
                WriteLog("Build-WinPE.ps1 completed.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Build failed: {ex.Message}", "Build Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteLog($"Build failed: {ex}");
            }
            finally
            {
                if (frontLoad && stagingPath != null && Directory.Exists(stagingPath))
                {
                    try
                    {
                        Directory.Delete(stagingPath, true);
                        WriteLog($"Cleaned up staging directory '{stagingPath}'.");
                    }
                    catch
                    {
                        WriteLog($"Could not remove staging directory '{stagingPath}'. You may delete it manually.");
                    }
                }
            }
        }

        private void BrowseForFolder(TextBox target)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.SelectedPath = target.Text;
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    target.Text = dialog.SelectedPath;
                }
            }
        }

        private void WriteLog(string message)
        {
            var line = $"{DateTime.Now:HH:mm:ss} {message}";
            txtLog.AppendText(line + Environment.NewLine);
        }

        private string BuildPowerShellArguments(string scriptPath, string payloadRoot, string isoPath, string winpeRoot, bool frontLoad)
        {
            string args = $"-NoProfile -ExecutionPolicy Bypass -File \"{scriptPath}\" -AdsPayloadPath \"{payloadRoot}\" -IsoPath \"{isoPath}\"";
            if (!string.IsNullOrWhiteSpace(winpeRoot))
            {
                args += $" -WinPERoot \"{winpeRoot}\"";
            }

            // Front-load option is tracked for future script support; log only to avoid breaking the script interface.
            if (frontLoad)
            {
                WriteLog("Front-load assets selected: payload will be staged and embedded into the ISO.");
            }

            return args;
        }

        private void RunPowerShell(string arguments)
        {
            var startInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            using (var process = System.Diagnostics.Process.Start(startInfo))
            {
                if (process == null)
                {
                    throw new InvalidOperationException("Failed to start PowerShell.");
                }

                string stdout = process.StandardOutput.ReadToEnd();
                string stderr = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (!string.IsNullOrWhiteSpace(stdout))
                {
                    WriteLog(stdout.TrimEnd());
                }

                if (!string.IsNullOrWhiteSpace(stderr))
                {
                    WriteLog("ERROR: " + stderr.TrimEnd());
                }

                if (process.ExitCode != 0)
                {
                    throw new InvalidOperationException($"Build-WinPE.ps1 exited with code {process.ExitCode}.");
                }
            }
        }

        private string ResolveBuildScriptPath(string sharePath)
        {
            // Prefer scripts next to the application
            var localScript = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "scripts", "Build-WinPE.ps1");
            if (File.Exists(localScript))
            {
                return localScript;
            }

            // Fall back to scripts under the provided share
            if (!string.IsNullOrWhiteSpace(sharePath))
            {
                var shareScript = Path.Combine(sharePath, "scripts", "Build-WinPE.ps1");
                if (File.Exists(shareScript))
                {
                    return shareScript;
                }
            }

            // Last chance: relative to current working directory
            var cwdScript = Path.Combine(Environment.CurrentDirectory, "scripts", "Build-WinPE.ps1");
            if (File.Exists(cwdScript))
            {
                return cwdScript;
            }

            return null;
        }

        private string CreateStagingCopy(string sourceRoot)
        {
            var stagingRoot = Path.Combine(Path.GetTempPath(), "ADS.Workbench", "Payload-" + DateTime.Now.Ticks);
            CopyDirectory(sourceRoot, stagingRoot);
            return stagingRoot;
        }

        private void CopyDirectory(string sourceDir, string destDir)
        {
            var sourceInfo = new DirectoryInfo(sourceDir);
            if (!sourceInfo.Exists)
            {
                throw new DirectoryNotFoundException($"Source directory not found: {sourceDir}");
            }

            Directory.CreateDirectory(destDir);

            foreach (var file in sourceInfo.GetFiles())
            {
                string targetFilePath = Path.Combine(destDir, file.Name);
                file.CopyTo(targetFilePath, true);
            }

            foreach (var subDir in sourceInfo.GetDirectories())
            {
                string newDest = Path.Combine(destDir, subDir.Name);
                CopyDirectory(subDir.FullName, newDest);
            }
        }

        private string BuildProfileJson()
        {
            var profile = new
            {
                SharePath = txtSharePath.Text.Trim(),
                LayoutRoot = txtLayoutRoot.Text.Trim(),
                AdkRoot = txtAdkRoot.Text.Trim(),
                IsoPath = txtIsoPath.Text.Trim(),
                FrontLoadAssets = chkFrontLoadAssets.Checked
            };

            return JsonConvert.SerializeObject(profile, Formatting.Indented);
        }
    }
}
