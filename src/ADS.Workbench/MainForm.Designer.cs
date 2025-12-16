namespace ADS.Workbench
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblSharePath = new System.Windows.Forms.Label();
            this.txtSharePath = new System.Windows.Forms.TextBox();
            this.btnBrowseShare = new System.Windows.Forms.Button();
            this.lblLayout = new System.Windows.Forms.Label();
            this.txtLayoutRoot = new System.Windows.Forms.TextBox();
            this.btnBrowseLayout = new System.Windows.Forms.Button();
            this.lblAdkRoot = new System.Windows.Forms.Label();
            this.txtAdkRoot = new System.Windows.Forms.TextBox();
            this.btnBrowseAdk = new System.Windows.Forms.Button();
            this.lblIsoPath = new System.Windows.Forms.Label();
            this.txtIsoPath = new System.Windows.Forms.TextBox();
            this.btnBrowseIso = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnBuildIso = new System.Windows.Forms.Button();
            this.btnSaveProfile = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.panelHeader.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(72)))), ((int)(((byte)(117)))));
            this.panelHeader.Controls.Add(this.lblSubtitle);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(18, 14, 18, 14);
            this.panelHeader.Size = new System.Drawing.Size(784, 72);
            this.panelHeader.TabIndex = 3;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSubtitle.Location = new System.Drawing.Point(21, 42);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(220, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Prepare ADS payload and build WinPE.";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(18, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(162, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ADS Workbench";
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.Controls.Add(this.lblSharePath, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.txtSharePath, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.btnBrowseShare, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.lblLayout, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.txtLayoutRoot, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.btnBrowseLayout, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.lblAdkRoot, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.txtAdkRoot, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.btnBrowseAdk, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.lblIsoPath, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.txtIsoPath, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.btnBrowseIso, 2, 3);
            this.tableLayoutPanel.Location = new System.Drawing.Point(12, 88);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(760, 128);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // lblSharePath
            // 
            this.lblSharePath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSharePath.AutoSize = true;
            this.lblSharePath.Location = new System.Drawing.Point(3, 9);
            this.lblSharePath.Name = "lblSharePath";
            this.lblSharePath.Size = new System.Drawing.Size(105, 13);
            this.lblSharePath.TabIndex = 0;
            this.lblSharePath.Text = "Network Share Path";
            // 
            // txtSharePath
            // 
            this.txtSharePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSharePath.Location = new System.Drawing.Point(193, 6);
            this.txtSharePath.Name = "txtSharePath";
            this.txtSharePath.Size = new System.Drawing.Size(412, 20);
            this.txtSharePath.TabIndex = 1;
            // 
            // btnBrowseShare
            // 
            this.btnBrowseShare.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBrowseShare.Location = new System.Drawing.Point(611, 4);
            this.btnBrowseShare.Name = "btnBrowseShare";
            this.btnBrowseShare.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseShare.TabIndex = 2;
            this.btnBrowseShare.Text = "Browse...";
            this.btnBrowseShare.UseVisualStyleBackColor = true;
            this.btnBrowseShare.Click += new System.EventHandler(this.BtnBrowseShare_Click);
            // 
            // lblLayout
            // 
            this.lblLayout.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLayout.AutoSize = true;
            this.lblLayout.Location = new System.Drawing.Point(3, 41);
            this.lblLayout.Name = "lblLayout";
            this.lblLayout.Size = new System.Drawing.Size(96, 13);
            this.lblLayout.TabIndex = 3;
            this.lblLayout.Text = "Payload Layout Dir";
            // 
            // txtLayoutRoot
            // 
            this.txtLayoutRoot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLayoutRoot.Location = new System.Drawing.Point(193, 38);
            this.txtLayoutRoot.Name = "txtLayoutRoot";
            this.txtLayoutRoot.Size = new System.Drawing.Size(412, 20);
            this.txtLayoutRoot.TabIndex = 4;
            // 
            // btnBrowseLayout
            // 
            this.btnBrowseLayout.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBrowseLayout.Location = new System.Drawing.Point(611, 35);
            this.btnBrowseLayout.Name = "btnBrowseLayout";
            this.btnBrowseLayout.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseLayout.TabIndex = 5;
            this.btnBrowseLayout.Text = "Browse...";
            this.btnBrowseLayout.UseVisualStyleBackColor = true;
            this.btnBrowseLayout.Click += new System.EventHandler(this.BtnBrowseLayout_Click);
            // 
            // lblAdkRoot
            // 
            this.lblAdkRoot.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAdkRoot.AutoSize = true;
            this.lblAdkRoot.Location = new System.Drawing.Point(3, 73);
            this.lblAdkRoot.Name = "lblAdkRoot";
            this.lblAdkRoot.Size = new System.Drawing.Size(111, 13);
            this.lblAdkRoot.TabIndex = 6;
            this.lblAdkRoot.Text = "ADK/WinPE Root Dir";
            // 
            // txtAdkRoot
            // 
            this.txtAdkRoot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdkRoot.Location = new System.Drawing.Point(193, 70);
            this.txtAdkRoot.Name = "txtAdkRoot";
            this.txtAdkRoot.Size = new System.Drawing.Size(412, 20);
            this.txtAdkRoot.TabIndex = 7;
            // 
            // btnBrowseAdk
            // 
            this.btnBrowseAdk.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBrowseAdk.Location = new System.Drawing.Point(611, 68);
            this.btnBrowseAdk.Name = "btnBrowseAdk";
            this.btnBrowseAdk.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseAdk.TabIndex = 8;
            this.btnBrowseAdk.Text = "Browse...";
            this.btnBrowseAdk.UseVisualStyleBackColor = true;
            this.btnBrowseAdk.Click += new System.EventHandler(this.BtnBrowseAdk_Click);
            // 
            // lblIsoPath
            // 
            this.lblIsoPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblIsoPath.AutoSize = true;
            this.lblIsoPath.Location = new System.Drawing.Point(3, 105);
            this.lblIsoPath.Name = "lblIsoPath";
            this.lblIsoPath.Size = new System.Drawing.Size(91, 13);
            this.lblIsoPath.TabIndex = 9;
            this.lblIsoPath.Text = "ISO Output Path";
            // 
            // txtIsoPath
            // 
            this.txtIsoPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIsoPath.Location = new System.Drawing.Point(193, 102);
            this.txtIsoPath.Name = "txtIsoPath";
            this.txtIsoPath.Size = new System.Drawing.Size(412, 20);
            this.txtIsoPath.TabIndex = 10;
            // 
            // btnBrowseIso
            // 
            this.btnBrowseIso.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBrowseIso.Location = new System.Drawing.Point(611, 99);
            this.btnBrowseIso.Name = "btnBrowseIso";
            this.btnBrowseIso.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseIso.TabIndex = 11;
            this.btnBrowseIso.Text = "Browse...";
            this.btnBrowseIso.UseVisualStyleBackColor = true;
            this.btnBrowseIso.Click += new System.EventHandler(this.BtnBrowseIso_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
            this.panelButtons.Controls.Add(this.btnBuildIso);
            this.panelButtons.Controls.Add(this.btnSaveProfile);
            this.panelButtons.Location = new System.Drawing.Point(12, 222);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(760, 40);
            this.panelButtons.TabIndex = 1;
            // 
            // btnBuildIso
            // 
            this.btnBuildIso.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnBuildIso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.btnBuildIso.FlatAppearance.BorderSize = 0;
            this.btnBuildIso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuildIso.ForeColor = System.Drawing.Color.White;
            this.btnBuildIso.Location = new System.Drawing.Point(616, 8);
            this.btnBuildIso.Name = "btnBuildIso";
            this.btnBuildIso.Size = new System.Drawing.Size(130, 23);
            this.btnBuildIso.TabIndex = 1;
            this.btnBuildIso.Text = "Build WinPE ISO";
            this.btnBuildIso.UseVisualStyleBackColor = false;
            this.btnBuildIso.Click += new System.EventHandler(this.BtnBuildIso_Click);
            // 
            // btnSaveProfile
            // 
            this.btnSaveProfile.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSaveProfile.BackColor = System.Drawing.Color.White;
            this.btnSaveProfile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.btnSaveProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveProfile.Location = new System.Drawing.Point(3, 8);
            this.btnSaveProfile.Name = "btnSaveProfile";
            this.btnSaveProfile.Size = new System.Drawing.Size(130, 23);
            this.btnSaveProfile.TabIndex = 0;
            this.btnSaveProfile.Text = "Save Settings";
            this.btnSaveProfile.UseVisualStyleBackColor = false;
            this.btnSaveProfile.Click += new System.EventHandler(this.BtnSaveProfile_Click);
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtLog.Location = new System.Drawing.Point(12, 268);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(760, 249);
            this.txtLog.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(784, 529);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADS Workbench";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label lblSharePath;
        private System.Windows.Forms.TextBox txtSharePath;
        private System.Windows.Forms.Button btnBrowseShare;
            private System.Windows.Forms.Label lblLayout;
            private System.Windows.Forms.TextBox txtLayoutRoot;
            private System.Windows.Forms.Button btnBrowseLayout;
            private System.Windows.Forms.Label lblAdkRoot;
            private System.Windows.Forms.TextBox txtAdkRoot;
        private System.Windows.Forms.Button btnBrowseAdk;
        private System.Windows.Forms.Label lblIsoPath;
        private System.Windows.Forms.TextBox txtIsoPath;
        private System.Windows.Forms.Button btnBrowseIso;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnBuildIso;
        private System.Windows.Forms.Button btnSaveProfile;
        private System.Windows.Forms.TextBox txtLog;
    }
}
