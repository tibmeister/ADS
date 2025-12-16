using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADS.Wizard.Models;
using Newtonsoft.Json;

namespace ADS.Wizard
{
    public partial class MainForm : Form
    {
        private readonly string defaultConfigPath;
        private readonly string logPath;
        private readonly JsonSerializerSettings jsonSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Ignore
        };

        public MainForm()
        {
            InitializeComponent();
            defaultConfigPath = GetDefaultConfigPath();
            logPath = GetDefaultLogPath();
            cmbOsVersion.SelectedIndex = 0;
            cmbPlatform.SelectedIndex = 0;
            txtSavePath.Text = defaultConfigPath;
            SetStaticFieldsEnabled(false);
            WriteLog("ADS Wizard started.");
        }

        private static string GetDefaultConfigPath()
        {
            if (Directory.Exists(@"X:\Deploy"))
            {
                return @"X:\Deploy\deploy.json";
            }

            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "deploy.json");
        }

        private static string GetDefaultLogPath()
        {
            if (Directory.Exists(@"X:\Deploy"))
            {
                return @"X:\Deploy\ADS.Wizard.log";
            }

            return Path.Combine(Path.GetTempPath(), "ADS.Wizard.log");
        }

        private void WriteLog(string message)
        {
            var line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {message}";
            try
            {
                File.AppendAllLines(logPath, new[] { line });
            }
            catch
            {
                // Best-effort logging; ignore failures.
            }

            AppendUiLog(line);
        }

        private void AppendUiLog(string message)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action<string>(AppendUiLog), message);
                return;
            }

            txtLog.AppendText(message + Environment.NewLine);
        }

        private bool TryBuildConfig(out DeploymentConfig config)
        {
            config = null;

            var errors = new List<string>();

            string computerName = txtComputerName.Text.Trim();
            string osVersion = cmbOsVersion.SelectedItem as string;
            string imagePath = txtImagePath.Text.Trim();
            string networkSharePath = txtNetworkShare.Text.Trim();
            string networkUsername = txtNetworkUser.Text.Trim();
            string networkPassword = txtNetworkPassword.Text;
            string platform = cmbPlatform.SelectedItem as string;

            if (string.IsNullOrWhiteSpace(computerName))
            {
                errors.Add("Computer Name is required.");
            }

            if (string.IsNullOrWhiteSpace(osVersion))
            {
                errors.Add("OS Version is required.");
            }

            if (string.IsNullOrWhiteSpace(imagePath))
            {
                errors.Add("Image Path is required.");
            }

            if (string.IsNullOrWhiteSpace(platform))
            {
                errors.Add("Platform is required.");
            }

            bool shareProvided = !string.IsNullOrWhiteSpace(networkSharePath);
            bool userProvided = !string.IsNullOrWhiteSpace(networkUsername);
            bool passwordProvided = !string.IsNullOrWhiteSpace(networkPassword);

            if (shareProvided && (!userProvided || !passwordProvided))
            {
                errors.Add("Network share credentials (username and password) are required when a network share path is provided.");
            }

            if (!shareProvided && (userProvided || passwordProvided))
            {
                errors.Add("Network share path is required when credentials are supplied.");
            }

            if (chkStaticIp.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtStaticIp.Text))
                {
                    errors.Add("Static IP address is required when Static IP is enabled.");
                }

                if (string.IsNullOrWhiteSpace(txtStaticSubnet.Text))
                {
                    errors.Add("Subnet mask is required when Static IP is enabled.");
                }
            }

            if (errors.Any())
            {
                MessageBox.Show(string.Join(Environment.NewLine, errors), "Validation Errors", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            config = new DeploymentConfig
            {
                ComputerName = computerName,
                OsVersion = osVersion,
                ImagePath = imagePath,
                ImageIndex = Convert.ToInt32(numImageIndex.Value),
                TargetDisk = Convert.ToInt32(numTargetDisk.Value),
                Platform = platform,
                DriverPackPath = string.IsNullOrWhiteSpace(txtDriverPackPath.Text) ? null : txtDriverPackPath.Text.Trim(),
                UnattendTemplatePath = string.IsNullOrWhiteSpace(txtUnattendTemplatePath.Text) ? null : txtUnattendTemplatePath.Text.Trim(),
                OdjBlobPath = string.IsNullOrWhiteSpace(txtOdjBlobPath.Text) ? null : txtOdjBlobPath.Text.Trim(),
                NetworkSharePath = shareProvided ? networkSharePath : null,
                NetworkUsername = userProvided ? networkUsername : null,
                NetworkPassword = passwordProvided ? networkPassword : null,
                FormatAdditionalDisks = chkFormatAdditionalDisks.Checked,
                UseStaticIp = chkStaticIp.Checked,
                StaticIpAddress = string.IsNullOrWhiteSpace(txtStaticIp.Text) ? null : txtStaticIp.Text.Trim(),
                StaticSubnetMask = string.IsNullOrWhiteSpace(txtStaticSubnet.Text) ? null : txtStaticSubnet.Text.Trim(),
                StaticGateway = string.IsNullOrWhiteSpace(txtStaticGateway.Text) ? null : txtStaticGateway.Text.Trim(),
                StaticDnsServers = ParseDnsServers(txtStaticDns.Text)
            };

            return true;
        }

        private List<string> ParseDnsServers(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return new List<string>();
            }

            return input.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Trim())
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .ToList();
        }

        private string SaveConfig(DeploymentConfig config)
        {
            string path = txtSavePath.Text.Trim();
            if (string.IsNullOrWhiteSpace(path))
            {
                path = defaultConfigPath;
                txtSavePath.Text = path;
            }

            try
            {
                var directory = Path.GetDirectoryName(path);
                if (!string.IsNullOrWhiteSpace(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                string json = JsonConvert.SerializeObject(config, jsonSettings);
                File.WriteAllText(path, json, Encoding.UTF8);
                WriteLog($"Configuration saved to {path}");
                return path;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save configuration: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteLog($"Save failed: {ex}");
                return null;
            }
        }

        private string GetAssetStagingRoot()
        {
            if (Directory.Exists(@"X:\Deploy"))
            {
                return @"X:\Deploy\Assets";
            }

            return Path.Combine(Path.GetTempPath(), "ADS.Assets");
        }

        private bool TryStageNetworkAssets(DeploymentConfig config)
        {
            if (string.IsNullOrWhiteSpace(config.NetworkSharePath))
            {
                UpdateStatus("Ready", false);
                return true;
            }

            var sharePath = config.NetworkSharePath;
            UpdateStatus($"Connecting to {sharePath}", true);
            WriteLog($"Connecting to network share {sharePath} to stage assets...");
            if (!MapNetworkShare(sharePath, config.NetworkUsername, config.NetworkPassword))
            {
                UpdateStatus("Connection failed", false);
                MessageBox.Show("Failed to connect to the network share. Verify credentials and connectivity.", "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                string stagingRoot = GetAssetStagingRoot();
                Directory.CreateDirectory(stagingRoot);

                config.ImagePath = StagePathIfRemote(config.ImagePath, stagingRoot, "image");
                config.DriverPackPath = StagePathIfRemote(config.DriverPackPath, Path.Combine(stagingRoot, "Drivers"), "driver pack");
                config.UnattendTemplatePath = StagePathIfRemote(config.UnattendTemplatePath, Path.Combine(stagingRoot, "Unattend"), "unattend template");
                config.OdjBlobPath = StagePathIfRemote(config.OdjBlobPath, Path.Combine(stagingRoot, "ODJ"), "ODJ blob");

                if (config.Packages != null && config.Packages.Any())
                {
                    var stagedPackages = new List<string>();
                    foreach (var package in config.Packages)
                    {
                        stagedPackages.Add(StagePathIfRemote(package, Path.Combine(stagingRoot, "Packages"), "package"));
                    }
                    config.Packages = stagedPackages;
                }

                config.NetworkSharePath = null;
                config.NetworkUsername = null;
                config.NetworkPassword = null;
                WriteLog($"Staging complete. Assets staged under {stagingRoot}.");
                UpdateStatus("Staging complete", false);
                return true;
            }
            catch (Exception ex)
            {
                UpdateStatus("Staging failed", false);
                MessageBox.Show($"Failed to stage assets from the network share: {ex.Message}", "Staging Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteLog($"Staging failed: {ex}");
                return false;
            }
            finally
            {
                UnmapNetworkShare(sharePath);
            }
        }

        private string StagePathIfRemote(string path, string destinationRoot, string friendlyName)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return null;
            }

            if (!path.StartsWith(@"\\", StringComparison.OrdinalIgnoreCase))
            {
                return path;
            }

            try
            {
                Directory.CreateDirectory(destinationRoot);
                string destination;
                if (Directory.Exists(path))
                {
                    destination = Path.Combine(destinationRoot, new DirectoryInfo(path).Name);
                    UpdateStatus($"Copying {friendlyName} folder...", true);
                    CopyDirectory(path, destination);
                }
                else if (File.Exists(path))
                {
                    destination = Path.Combine(destinationRoot, Path.GetFileName(path));
                    UpdateStatus($"Copying {friendlyName} file...", true);
                    File.Copy(path, destination, true);
                }
                else
                {
                    throw new FileNotFoundException($"Path not found: {path}");
                }

                WriteLog($"Staged {friendlyName} from network share to {destination}");
                UpdateStatus($"Staged {friendlyName}", true);
                return destination;
            }
            catch (Exception ex)
            {
                UpdateStatus("Staging failed", false);
                throw new InvalidOperationException($"Failed to stage {friendlyName} from {path}: {ex.Message}", ex);
            }
        }

        private void CopyDirectory(string sourceDir, string destinationDir)
        {
            var dir = new DirectoryInfo(sourceDir);
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException($"Source directory not found: {sourceDir}");
            }

            Directory.CreateDirectory(destinationDir);
            foreach (var file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath, true);
            }

            foreach (var subDir in dir.GetDirectories())
            {
                string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                CopyDirectory(subDir.FullName, newDestinationDir);
            }
        }

        private bool MapNetworkShare(string sharePath, string username, string password)
        {
            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/C net use \"{sharePath}\" {(string.IsNullOrWhiteSpace(password) ? "\"\"" : $"\"{password}\"")} {(string.IsNullOrWhiteSpace(username) ? string.Empty : $"/user:\"{username}\"")} /persistent:no",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                using (var process = Process.Start(psi))
                {
                    var output = process?.StandardOutput.ReadToEnd();
                    var error = process?.StandardError.ReadToEnd();
                    process?.WaitForExit();

                    if (process == null || process.ExitCode != 0)
                    {
                        WriteLog($"Failed to map share {sharePath}. Output: {output} Error: {error}");
                        UpdateStatus("Connection failed", false);
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                WriteLog($"Failed to map share {sharePath}: {ex}");
                UpdateStatus("Connection failed", false);
                return false;
            }
        }

        private void UnmapNetworkShare(string sharePath)
        {
            if (string.IsNullOrWhiteSpace(sharePath))
            {
                return;
            }

            try
            {
                UpdateStatus("Disconnecting share", true);
                var psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/C net use \"{sharePath}\" /delete /y",
                    CreateNoWindow = true,
                    UseShellExecute = false
                };
                Process.Start(psi)?.WaitForExit();
            }
            catch
            {
                // Best effort cleanup
            }
            finally
            {
                UpdateStatus("Ready", false);
            }
        }

        private void UpdateStatus(string message, bool busy)
        {
            if (statusLabel == null || statusProgress == null)
            {
                return;
            }

            if (statusLabel.GetCurrentParent()?.InvokeRequired == true)
            {
                statusLabel.GetCurrentParent().Invoke(new Action(() => UpdateStatus(message, busy)));
                return;
            }

            statusLabel.Text = message;
            statusProgress.Visible = busy;
        }

        private void BtnSaveConfig_Click(object sender, EventArgs e)
        {
            if (!TryBuildConfig(out var config))
            {
                return;
            }

            if (!TryStageNetworkAssets(config))
            {
                return;
            }

            SaveConfig(config);
        }

        private void BtnStartDeployment_Click(object sender, EventArgs e)
        {
            if (!TryBuildConfig(out var config))
            {
                return;
            }

            if (!TryStageNetworkAssets(config))
            {
                return;
            }

            string configPath = SaveConfig(config);
            if (string.IsNullOrWhiteSpace(configPath))
            {
                return;
            }

            string scriptPath = GetDeploymentScriptPath();
            if (string.IsNullOrWhiteSpace(scriptPath))
            {
                MessageBox.Show("Unable to locate Start-Deployment.ps1. Ensure scripts are available next to the wizard.", "Script Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var psi = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy Bypass -File \"{scriptPath}\" -ConfigPath \"{configPath}\" -LogPath \"{GetDeploymentLogPath()}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            WriteLog($"Launching deployment: {psi.Arguments}");
            try
            {
                using (var process = Process.Start(psi))
                {
                    if (process == null)
                    {
                        MessageBox.Show("Failed to start PowerShell.", "Launch Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var output = process.StandardOutput.ReadToEnd();
                    var error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    if (!string.IsNullOrWhiteSpace(output))
                    {
                        WriteLog(output.Trim());
                    }

                    if (!string.IsNullOrWhiteSpace(error))
                    {
                        WriteLog($"ERROR: {error.Trim()}");
                    }

                    string result = process.ExitCode == 0 ? "Deployment started successfully." : $"Deployment process exited with code {process.ExitCode}.";
                    MessageBox.Show(result, "Deployment", MessageBoxButtons.OK, process.ExitCode == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                    WriteLog(result);
                    WriteLog($"Deployment log: {GetDeploymentLogPath()}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to launch deployment: {ex.Message}", "Launch Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteLog($"Launch failed: {ex}");
            }
        }

        private string GetDeploymentLogPath()
        {
            if (Directory.Exists(@"X:\Deploy"))
            {
                return @"X:\Deploy\ADS.Deployment.log";
            }

            if (Directory.Exists(@"C:\Deploy"))
            {
                return @"C:\Deploy\ADS.Deployment.log";
            }

            return Path.Combine(Path.GetTempPath(), "ADS.Deployment.log");
        }

        private string GetDeploymentScriptPath()
        {
            var candidates = new[]
            {
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Start-Deployment.ps1"),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "scripts", "Start-Deployment.ps1"),
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "scripts", "Start-Deployment.ps1"))
            };

            foreach (var candidate in candidates)
            {
                if (File.Exists(candidate))
                {
                    return candidate;
                }
            }

            return null;
        }

        private void BtnBrowseImage_Click(object sender, EventArgs e)
        {
            BrowseForPath(txtImagePath, false);
        }

        private void BtnBrowseDriver_Click(object sender, EventArgs e)
        {
            BrowseForPath(txtDriverPackPath, false);
        }

        private void BtnBrowseUnattend_Click(object sender, EventArgs e)
        {
            BrowseForPath(txtUnattendTemplatePath, false);
        }

        private void BtnBrowseOdj_Click(object sender, EventArgs e)
        {
            BrowseForPath(txtOdjBlobPath, false);
        }

        private void BtnBrowseSave_Click(object sender, EventArgs e)
        {
            BrowseForPath(txtSavePath, true);
        }

        private void ChkStaticIp_CheckedChanged(object sender, EventArgs e)
        {
            SetStaticFieldsEnabled(chkStaticIp.Checked);
        }

        private void SetStaticFieldsEnabled(bool enabled)
        {
            txtStaticIp.Enabled = enabled;
            txtStaticSubnet.Enabled = enabled;
            txtStaticGateway.Enabled = enabled;
            txtStaticDns.Enabled = enabled;
        }

        private void BrowseForPath(TextBox target, bool isSave)
        {
            if (isSave)
            {
                using (var dialog = new SaveFileDialog())
                {
                    dialog.FileName = Path.GetFileName(target.Text);
                    dialog.InitialDirectory = GetInitialDirectory(target.Text);
                    dialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        target.Text = dialog.FileName;
                    }
                }
            }
            else
            {
                using (var dialog = new OpenFileDialog())
                {
                    dialog.FileName = Path.GetFileName(target.Text);
                    dialog.InitialDirectory = GetInitialDirectory(target.Text);
                    dialog.CheckFileExists = false;
                    dialog.Filter = "All files (*.*)|*.*";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        target.Text = dialog.FileName;
                    }
                }
            }
        }

        private static string GetInitialDirectory(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }

            var dir = Path.GetDirectoryName(path);
            return Directory.Exists(dir) ? dir : Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
    }
}
