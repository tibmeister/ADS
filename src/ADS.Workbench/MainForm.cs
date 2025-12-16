using System;
using System.IO;
using System.Windows.Forms;

namespace ADS.Workbench
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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
            WriteLog("Profile saving not yet implemented. This will persist share and layout settings for reuse.");
        }

        private void BtnBuildIso_Click(object sender, EventArgs e)
        {
            WriteLog("Build WinPE ISO is not yet implemented. It will orchestrate Build-WinPE.ps1 with the provided settings.");
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
    }
}
