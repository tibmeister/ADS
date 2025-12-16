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
                OdjBlobPath = string.IsNullOrWhiteSpace(txtOdjBlobPath.Text) ? null : txtOdjBlobPath.Text.Trim()
            };

            return true;
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

        private void BtnSaveConfig_Click(object sender, EventArgs e)
        {
            if (!TryBuildConfig(out var config))
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
