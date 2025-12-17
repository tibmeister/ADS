namespace ADS.Wizard
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.tableGeneral = new System.Windows.Forms.TableLayoutPanel();
            this.lblComputerName = new System.Windows.Forms.Label();
            this.txtComputerName = new System.Windows.Forms.TextBox();
            this.lblOsVersion = new System.Windows.Forms.Label();
            this.cmbOsVersion = new System.Windows.Forms.ComboBox();
            this.lblImagePath = new System.Windows.Forms.Label();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            this.lblImageIndex = new System.Windows.Forms.Label();
            this.numImageIndex = new System.Windows.Forms.NumericUpDown();
            this.lblTargetDisk = new System.Windows.Forms.Label();
            this.numTargetDisk = new System.Windows.Forms.NumericUpDown();
            this.chkFormatAdditionalDisks = new System.Windows.Forms.CheckBox();
            this.lblPlatform = new System.Windows.Forms.Label();
            this.cmbPlatform = new System.Windows.Forms.ComboBox();
            this.lblSavePath = new System.Windows.Forms.Label();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.btnBrowseSave = new System.Windows.Forms.Button();
            this.tabNetwork = new System.Windows.Forms.TabPage();
            this.tableNetwork = new System.Windows.Forms.TableLayoutPanel();
            this.lblNetworkShare = new System.Windows.Forms.Label();
            this.txtNetworkShare = new System.Windows.Forms.TextBox();
            this.lblNetworkUser = new System.Windows.Forms.Label();
            this.txtNetworkUser = new System.Windows.Forms.TextBox();
            this.lblNetworkPassword = new System.Windows.Forms.Label();
            this.txtNetworkPassword = new System.Windows.Forms.TextBox();
            this.chkStaticIp = new System.Windows.Forms.CheckBox();
            this.lblStaticIp = new System.Windows.Forms.Label();
            this.txtStaticIp = new System.Windows.Forms.TextBox();
            this.lblStaticSubnet = new System.Windows.Forms.Label();
            this.cmbStaticSubnet = new System.Windows.Forms.ComboBox();
            this.lblStaticGateway = new System.Windows.Forms.Label();
            this.txtStaticGateway = new System.Windows.Forms.TextBox();
            this.lblStaticDns = new System.Windows.Forms.Label();
            this.txtStaticDns = new System.Windows.Forms.TextBox();
            this.tabAdvanced = new System.Windows.Forms.TabPage();
            this.tableAdvanced = new System.Windows.Forms.TableLayoutPanel();
            this.lblDriverPackPath = new System.Windows.Forms.Label();
            this.txtDriverPackPath = new System.Windows.Forms.TextBox();
            this.btnBrowseDriver = new System.Windows.Forms.Button();
            this.lblUnattendTemplatePath = new System.Windows.Forms.Label();
            this.txtUnattendTemplatePath = new System.Windows.Forms.TextBox();
            this.btnBrowseUnattend = new System.Windows.Forms.Button();
            this.lblOdjBlobPath = new System.Windows.Forms.Label();
            this.txtOdjBlobPath = new System.Windows.Forms.TextBox();
            this.btnBrowseOdj = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnStartDeployment = new System.Windows.Forms.Button();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tableGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImageIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetDisk)).BeginInit();
            this.tabNetwork.SuspendLayout();
            this.tableNetwork.SuspendLayout();
            this.tabAdvanced.SuspendLayout();
            this.tableAdvanced.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.statusStrip.SuspendLayout();
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
            this.panelHeader.Size = new System.Drawing.Size(900, 76);
            this.panelHeader.TabIndex = 3;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSubtitle.Location = new System.Drawing.Point(21, 43);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(278, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Configure deployment inputs and run the automation.";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(18, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(430, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Automated Deployment and Servicing (ADS)";
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(12, 76);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.tabControlMain);
            this.splitContainerMain.Panel1.Controls.Add(this.panelButtons);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.txtLog);
            this.splitContainerMain.Size = new System.Drawing.Size(876, 732);
            this.splitContainerMain.SplitterDistance = 620;
            this.splitContainerMain.SplitterWidth = 6;
            this.splitContainerMain.TabIndex = 4;
            this.splitContainerMain.Panel2MinSize = 110;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(876, 572);
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.Controls.Add(this.tabGeneral);
            this.tabControlMain.Controls.Add(this.tabNetwork);
            this.tabControlMain.Controls.Add(this.tabAdvanced);
            // 
            // tabGeneral
            // 
            this.tabGeneral.AutoScroll = true;
            this.tabGeneral.Controls.Add(this.tableGeneral);
            this.tabGeneral.Location = new System.Drawing.Point(4, 24);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(8);
            this.tabGeneral.Size = new System.Drawing.Size(868, 544);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // tableGeneral
            // 
            this.tableGeneral.AutoSize = true;
            this.tableGeneral.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableGeneral.ColumnCount = 4;
            this.tableGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26F));
            this.tableGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.tableGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableGeneral.Controls.Add(this.lblComputerName, 0, 0);
            this.tableGeneral.Controls.Add(this.txtComputerName, 1, 0);
            this.tableGeneral.Controls.Add(this.lblOsVersion, 2, 0);
            this.tableGeneral.Controls.Add(this.cmbOsVersion, 3, 0);
            this.tableGeneral.Controls.Add(this.lblImagePath, 0, 1);
            this.tableGeneral.Controls.Add(this.txtImagePath, 1, 1);
            this.tableGeneral.Controls.Add(this.btnBrowseImage, 3, 1);
            this.tableGeneral.Controls.Add(this.lblImageIndex, 0, 2);
            this.tableGeneral.Controls.Add(this.numImageIndex, 1, 2);
            this.tableGeneral.Controls.Add(this.lblTargetDisk, 2, 2);
            this.tableGeneral.Controls.Add(this.numTargetDisk, 3, 2);
            this.tableGeneral.Controls.Add(this.chkFormatAdditionalDisks, 1, 3);
            this.tableGeneral.Controls.Add(this.lblPlatform, 0, 4);
            this.tableGeneral.Controls.Add(this.cmbPlatform, 1, 4);
            this.tableGeneral.Controls.Add(this.lblSavePath, 0, 5);
            this.tableGeneral.Controls.Add(this.txtSavePath, 1, 5);
            this.tableGeneral.Controls.Add(this.btnBrowseSave, 3, 5);
            this.tableGeneral.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableGeneral.Location = new System.Drawing.Point(8, 8);
            this.tableGeneral.Name = "tableGeneral";
            this.tableGeneral.RowCount = 6;
            this.tableGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableGeneral.Size = new System.Drawing.Size(852, 204);
            this.tableGeneral.TabIndex = 0;
            // 
            // lblComputerName
            // 
            this.lblComputerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblComputerName.AutoSize = true;
            this.lblComputerName.Location = new System.Drawing.Point(3, 10);
            this.lblComputerName.Name = "lblComputerName";
            this.lblComputerName.Size = new System.Drawing.Size(108, 15);
            this.lblComputerName.TabIndex = 0;
            this.lblComputerName.Text = "Computer Name*";
            // 
            // txtComputerName
            // 
            this.txtComputerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComputerName.Location = new System.Drawing.Point(225, 6);
            this.txtComputerName.MaxLength = 15;
            this.txtComputerName.Name = "txtComputerName";
            this.txtComputerName.Size = new System.Drawing.Size(365, 23);
            this.txtComputerName.TabIndex = 1;
            // 
            // lblOsVersion
            // 
            this.lblOsVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOsVersion.AutoSize = true;
            this.lblOsVersion.Location = new System.Drawing.Point(596, 10);
            this.lblOsVersion.Name = "lblOsVersion";
            this.lblOsVersion.Size = new System.Drawing.Size(68, 15);
            this.lblOsVersion.TabIndex = 2;
            this.lblOsVersion.Text = "OS Version*";
            // 
            // cmbOsVersion
            // 
            this.cmbOsVersion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbOsVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOsVersion.FormattingEnabled = true;
            this.cmbOsVersion.Items.AddRange(new object[] {
            "Server2019",
            "Server2022",
            "Server2025"});
            this.cmbOsVersion.Location = new System.Drawing.Point(724, 6);
            this.cmbOsVersion.Name = "cmbOsVersion";
            this.cmbOsVersion.Size = new System.Drawing.Size(100, 23);
            this.cmbOsVersion.TabIndex = 3;
            // 
            // lblImagePath
            // 
            this.lblImagePath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblImagePath.AutoSize = true;
            this.lblImagePath.Location = new System.Drawing.Point(3, 44);
            this.lblImagePath.Name = "lblImagePath";
            this.lblImagePath.Size = new System.Drawing.Size(76, 15);
            this.lblImagePath.TabIndex = 10;
            this.lblImagePath.Text = "Image Path*";
            // 
            // txtImagePath
            // 
            this.txtImagePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImagePath.Location = new System.Drawing.Point(225, 40);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Size = new System.Drawing.Size(360, 23);
            this.txtImagePath.TabIndex = 11;
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBrowseImage.Location = new System.Drawing.Point(724, 38);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(100, 27);
            this.btnBrowseImage.TabIndex = 12;
            this.btnBrowseImage.Text = "Browse...";
            this.btnBrowseImage.UseVisualStyleBackColor = true;
            this.btnBrowseImage.Click += new System.EventHandler(this.BtnBrowseImage_Click);
            // 
            // lblImageIndex
            // 
            this.lblImageIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImageIndex.AutoSize = true;
            this.lblImageIndex.Location = new System.Drawing.Point(3, 78);
            this.lblImageIndex.Name = "lblImageIndex";
            this.lblImageIndex.Size = new System.Drawing.Size(76, 15);
            this.lblImageIndex.TabIndex = 13;
            this.lblImageIndex.Text = "Image Index*";
            // 
            // numImageIndex
            // 
            this.numImageIndex.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numImageIndex.Location = new System.Drawing.Point(225, 74);
            this.numImageIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numImageIndex.Name = "numImageIndex";
            this.numImageIndex.Size = new System.Drawing.Size(70, 23);
            this.numImageIndex.TabIndex = 14;
            this.numImageIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblTargetDisk
            // 
            this.lblTargetDisk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTargetDisk.AutoSize = true;
            this.lblTargetDisk.Location = new System.Drawing.Point(596, 78);
            this.lblTargetDisk.Name = "lblTargetDisk";
            this.lblTargetDisk.Size = new System.Drawing.Size(70, 15);
            this.lblTargetDisk.TabIndex = 15;
            this.lblTargetDisk.Text = "Target Disk*";
            // 
            // numTargetDisk
            // 
            this.numTargetDisk.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numTargetDisk.Location = new System.Drawing.Point(724, 74);
            this.numTargetDisk.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numTargetDisk.Name = "numTargetDisk";
            this.numTargetDisk.Size = new System.Drawing.Size(70, 23);
            this.numTargetDisk.TabIndex = 16;
            // 
            // chkFormatAdditionalDisks
            // 
            this.chkFormatAdditionalDisks.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkFormatAdditionalDisks.AutoSize = true;
            this.tableGeneral.SetColumnSpan(this.chkFormatAdditionalDisks, 3);
            this.chkFormatAdditionalDisks.Location = new System.Drawing.Point(207, 114);
            this.chkFormatAdditionalDisks.Name = "chkFormatAdditionalDisks";
            this.chkFormatAdditionalDisks.Size = new System.Drawing.Size(248, 19);
            this.chkFormatAdditionalDisks.TabIndex = 18;
            this.chkFormatAdditionalDisks.Text = "Format all non-OS disks (destructive wipe)";
            this.chkFormatAdditionalDisks.UseVisualStyleBackColor = true;
            // 
            // lblPlatform
            // 
            this.lblPlatform.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlatform.AutoSize = true;
            this.lblPlatform.Location = new System.Drawing.Point(3, 148);
            this.lblPlatform.Name = "lblPlatform";
            this.lblPlatform.Size = new System.Drawing.Size(57, 15);
            this.lblPlatform.TabIndex = 19;
            this.lblPlatform.Text = "Platform*";
            // 
            // cmbPlatform
            // 
            this.cmbPlatform.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPlatform.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlatform.FormattingEnabled = true;
            this.cmbPlatform.Items.AddRange(new object[] {
            "VMware",
            "Proxmox"});
            this.cmbPlatform.Location = new System.Drawing.Point(225, 144);
            this.cmbPlatform.Name = "cmbPlatform";
            this.cmbPlatform.Size = new System.Drawing.Size(360, 23);
            this.cmbPlatform.TabIndex = 20;
            // 
            // lblSavePath
            // 
            this.lblSavePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSavePath.AutoSize = true;
            this.lblSavePath.Location = new System.Drawing.Point(3, 182);
            this.lblSavePath.Name = "lblSavePath";
            this.lblSavePath.Size = new System.Drawing.Size(84, 15);
            this.lblSavePath.TabIndex = 33;
            this.lblSavePath.Text = "Config Save To";
            // 
            // txtSavePath
            // 
            this.txtSavePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSavePath.Location = new System.Drawing.Point(225, 178);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(360, 23);
            this.txtSavePath.TabIndex = 34;
            // 
            // btnBrowseSave
            // 
            this.btnBrowseSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBrowseSave.Location = new System.Drawing.Point(724, 176);
            this.btnBrowseSave.Name = "btnBrowseSave";
            this.btnBrowseSave.Size = new System.Drawing.Size(100, 27);
            this.btnBrowseSave.TabIndex = 35;
            this.btnBrowseSave.Text = "Browse...";
            this.btnBrowseSave.UseVisualStyleBackColor = true;
            this.btnBrowseSave.Click += new System.EventHandler(this.BtnBrowseSave_Click);
            // 
            // tabNetwork
            // 
            this.tabNetwork.AutoScroll = true;
            this.tabNetwork.Controls.Add(this.tableNetwork);
            this.tabNetwork.Location = new System.Drawing.Point(4, 24);
            this.tabNetwork.Name = "tabNetwork";
            this.tabNetwork.Padding = new System.Windows.Forms.Padding(8);
            this.tabNetwork.Size = new System.Drawing.Size(868, 544);
            this.tabNetwork.TabIndex = 1;
            this.tabNetwork.Text = "Network";
            this.tabNetwork.UseVisualStyleBackColor = true;
            // 
            // tableNetwork
            // 
            this.tableNetwork.AutoSize = true;
            this.tableNetwork.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableNetwork.ColumnCount = 3;
            this.tableNetwork.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tableNetwork.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52F));
            this.tableNetwork.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableNetwork.Controls.Add(this.lblNetworkShare, 0, 0);
            this.tableNetwork.Controls.Add(this.txtNetworkShare, 1, 0);
            this.tableNetwork.Controls.Add(this.lblNetworkUser, 0, 1);
            this.tableNetwork.Controls.Add(this.txtNetworkUser, 1, 1);
            this.tableNetwork.Controls.Add(this.lblNetworkPassword, 0, 2);
            this.tableNetwork.Controls.Add(this.txtNetworkPassword, 1, 2);
            this.tableNetwork.Controls.Add(this.chkStaticIp, 0, 3);
            this.tableNetwork.Controls.Add(this.lblStaticIp, 0, 4);
            this.tableNetwork.Controls.Add(this.txtStaticIp, 1, 4);
            this.tableNetwork.Controls.Add(this.lblStaticSubnet, 0, 5);
            this.tableNetwork.Controls.Add(this.cmbStaticSubnet, 1, 5);
            this.tableNetwork.Controls.Add(this.lblStaticGateway, 0, 6);
            this.tableNetwork.Controls.Add(this.txtStaticGateway, 1, 6);
            this.tableNetwork.Controls.Add(this.lblStaticDns, 0, 7);
            this.tableNetwork.Controls.Add(this.txtStaticDns, 1, 7);
            this.tableNetwork.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableNetwork.Location = new System.Drawing.Point(8, 8);
            this.tableNetwork.Name = "tableNetwork";
            this.tableNetwork.RowCount = 8;
            this.tableNetwork.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableNetwork.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableNetwork.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableNetwork.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableNetwork.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableNetwork.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableNetwork.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableNetwork.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableNetwork.Size = new System.Drawing.Size(852, 272);
            this.tableNetwork.TabIndex = 0;
            // 
            // lblNetworkShare
            // 
            this.lblNetworkShare.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNetworkShare.AutoSize = true;
            this.lblNetworkShare.Location = new System.Drawing.Point(3, 10);
            this.lblNetworkShare.Name = "lblNetworkShare";
            this.lblNetworkShare.Size = new System.Drawing.Size(138, 15);
            this.lblNetworkShare.TabIndex = 4;
            this.lblNetworkShare.Text = "Network share (optional)";
            // 
            // txtNetworkShare
            // 
            this.txtNetworkShare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNetworkShare.Location = new System.Drawing.Point(241, 6);
            this.txtNetworkShare.Name = "txtNetworkShare";
            this.txtNetworkShare.Size = new System.Drawing.Size(438, 23);
            this.txtNetworkShare.TabIndex = 5;
            // 
            // lblNetworkUser
            // 
            this.lblNetworkUser.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNetworkUser.AutoSize = true;
            this.lblNetworkUser.Location = new System.Drawing.Point(3, 44);
            this.lblNetworkUser.Name = "lblNetworkUser";
            this.lblNetworkUser.Size = new System.Drawing.Size(126, 15);
            this.lblNetworkUser.TabIndex = 6;
            this.lblNetworkUser.Text = "Share username (opt)";
            // 
            // txtNetworkUser
            // 
            this.txtNetworkUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNetworkUser.Location = new System.Drawing.Point(241, 40);
            this.txtNetworkUser.Name = "txtNetworkUser";
            this.txtNetworkUser.Size = new System.Drawing.Size(438, 23);
            this.txtNetworkUser.TabIndex = 7;
            // 
            // lblNetworkPassword
            // 
            this.lblNetworkPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNetworkPassword.AutoSize = true;
            this.lblNetworkPassword.Location = new System.Drawing.Point(3, 78);
            this.lblNetworkPassword.Name = "lblNetworkPassword";
            this.lblNetworkPassword.Size = new System.Drawing.Size(128, 15);
            this.lblNetworkPassword.TabIndex = 8;
            this.lblNetworkPassword.Text = "Share password (opt)";
            // 
            // txtNetworkPassword
            // 
            this.txtNetworkPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNetworkPassword.Location = new System.Drawing.Point(241, 74);
            this.txtNetworkPassword.Name = "txtNetworkPassword";
            this.txtNetworkPassword.Size = new System.Drawing.Size(438, 23);
            this.txtNetworkPassword.TabIndex = 9;
            this.txtNetworkPassword.UseSystemPasswordChar = true;
            // 
            // chkStaticIp
            // 
            this.chkStaticIp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkStaticIp.AutoSize = true;
            this.tableNetwork.SetColumnSpan(this.chkStaticIp, 3);
            this.chkStaticIp.Location = new System.Drawing.Point(3, 115);
            this.chkStaticIp.Name = "chkStaticIp";
            this.chkStaticIp.Size = new System.Drawing.Size(143, 19);
            this.chkStaticIp.TabIndex = 24;
            this.chkStaticIp.Text = "Use Static IP (optional)";
            this.chkStaticIp.UseVisualStyleBackColor = true;
            this.chkStaticIp.CheckedChanged += new System.EventHandler(this.ChkStaticIp_CheckedChanged);
            // 
            // lblStaticIp
            // 
            this.lblStaticIp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStaticIp.AutoSize = true;
            this.lblStaticIp.Location = new System.Drawing.Point(3, 149);
            this.lblStaticIp.Name = "lblStaticIp";
            this.lblStaticIp.Size = new System.Drawing.Size(88, 15);
            this.lblStaticIp.TabIndex = 25;
            this.lblStaticIp.Text = "Static IP Address";
            // 
            // txtStaticIp
            // 
            this.txtStaticIp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStaticIp.Location = new System.Drawing.Point(241, 145);
            this.txtStaticIp.Name = "txtStaticIp";
            this.txtStaticIp.Size = new System.Drawing.Size(438, 23);
            this.txtStaticIp.TabIndex = 26;
            // 
            // lblStaticSubnet
            // 
            this.lblStaticSubnet.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStaticSubnet.AutoSize = true;
            this.lblStaticSubnet.Location = new System.Drawing.Point(3, 183);
            this.lblStaticSubnet.Name = "lblStaticSubnet";
            this.lblStaticSubnet.Size = new System.Drawing.Size(95, 15);
            this.lblStaticSubnet.TabIndex = 27;
            this.lblStaticSubnet.Text = "Static Subnet Mask";
            // 
            // cmbStaticSubnet
            // 
            this.cmbStaticSubnet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStaticSubnet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStaticSubnet.FormattingEnabled = true;
            this.cmbStaticSubnet.Location = new System.Drawing.Point(241, 179);
            this.cmbStaticSubnet.Name = "cmbStaticSubnet";
            this.cmbStaticSubnet.Size = new System.Drawing.Size(438, 23);
            this.cmbStaticSubnet.TabIndex = 28;
            // 
            // lblStaticGateway
            // 
            this.lblStaticGateway.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStaticGateway.AutoSize = true;
            this.lblStaticGateway.Location = new System.Drawing.Point(3, 217);
            this.lblStaticGateway.Name = "lblStaticGateway";
            this.lblStaticGateway.Size = new System.Drawing.Size(83, 15);
            this.lblStaticGateway.TabIndex = 29;
            this.lblStaticGateway.Text = "Static Gateway";
            // 
            // txtStaticGateway
            // 
            this.txtStaticGateway.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStaticGateway.Location = new System.Drawing.Point(241, 213);
            this.txtStaticGateway.Name = "txtStaticGateway";
            this.txtStaticGateway.Size = new System.Drawing.Size(438, 23);
            this.txtStaticGateway.TabIndex = 30;
            // 
            // lblStaticDns
            // 
            this.lblStaticDns.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStaticDns.AutoSize = true;
            this.lblStaticDns.Location = new System.Drawing.Point(3, 251);
            this.lblStaticDns.Name = "lblStaticDns";
            this.lblStaticDns.Size = new System.Drawing.Size(125, 15);
            this.lblStaticDns.TabIndex = 31;
            this.lblStaticDns.Text = "Static DNS (comma list)";
            // 
            // txtStaticDns
            // 
            this.txtStaticDns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStaticDns.Location = new System.Drawing.Point(241, 247);
            this.txtStaticDns.Name = "txtStaticDns";
            this.txtStaticDns.Size = new System.Drawing.Size(438, 23);
            this.txtStaticDns.TabIndex = 32;
            // 
            // tabAdvanced
            // 
            this.tabAdvanced.AutoScroll = true;
            this.tabAdvanced.Controls.Add(this.tableAdvanced);
            this.tabAdvanced.Location = new System.Drawing.Point(4, 24);
            this.tabAdvanced.Name = "tabAdvanced";
            this.tabAdvanced.Padding = new System.Windows.Forms.Padding(8);
            this.tabAdvanced.Size = new System.Drawing.Size(868, 544);
            this.tabAdvanced.TabIndex = 2;
            this.tabAdvanced.Text = "Advanced";
            this.tabAdvanced.UseVisualStyleBackColor = true;
            // 
            // tableAdvanced
            // 
            this.tableAdvanced.AutoSize = true;
            this.tableAdvanced.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableAdvanced.ColumnCount = 3;
            this.tableAdvanced.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tableAdvanced.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52F));
            this.tableAdvanced.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableAdvanced.Controls.Add(this.lblDriverPackPath, 0, 0);
            this.tableAdvanced.Controls.Add(this.txtDriverPackPath, 1, 0);
            this.tableAdvanced.Controls.Add(this.btnBrowseDriver, 2, 0);
            this.tableAdvanced.Controls.Add(this.lblUnattendTemplatePath, 0, 1);
            this.tableAdvanced.Controls.Add(this.txtUnattendTemplatePath, 1, 1);
            this.tableAdvanced.Controls.Add(this.btnBrowseUnattend, 2, 1);
            this.tableAdvanced.Controls.Add(this.lblOdjBlobPath, 0, 2);
            this.tableAdvanced.Controls.Add(this.txtOdjBlobPath, 1, 2);
            this.tableAdvanced.Controls.Add(this.btnBrowseOdj, 2, 2);
            this.tableAdvanced.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableAdvanced.Location = new System.Drawing.Point(8, 8);
            this.tableAdvanced.Name = "tableAdvanced";
            this.tableAdvanced.RowCount = 3;
            this.tableAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableAdvanced.Size = new System.Drawing.Size(852, 102);
            this.tableAdvanced.TabIndex = 0;
            // 
            // lblDriverPackPath
            // 
            this.lblDriverPackPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDriverPackPath.AutoSize = true;
            this.lblDriverPackPath.Location = new System.Drawing.Point(3, 10);
            this.lblDriverPackPath.Name = "lblDriverPackPath";
            this.lblDriverPackPath.Size = new System.Drawing.Size(97, 15);
            this.lblDriverPackPath.TabIndex = 15;
            this.lblDriverPackPath.Text = "Driver Pack Path";
            // 
            // txtDriverPackPath
            // 
            this.txtDriverPackPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDriverPackPath.Location = new System.Drawing.Point(241, 6);
            this.txtDriverPackPath.Name = "txtDriverPackPath";
            this.txtDriverPackPath.Size = new System.Drawing.Size(438, 23);
            this.txtDriverPackPath.TabIndex = 16;
            // 
            // btnBrowseDriver
            // 
            this.btnBrowseDriver.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBrowseDriver.Location = new System.Drawing.Point(685, 4);
            this.btnBrowseDriver.Name = "btnBrowseDriver";
            this.btnBrowseDriver.Size = new System.Drawing.Size(90, 27);
            this.btnBrowseDriver.TabIndex = 17;
            this.btnBrowseDriver.Text = "Browse...";
            this.btnBrowseDriver.UseVisualStyleBackColor = true;
            this.btnBrowseDriver.Click += new System.EventHandler(this.BtnBrowseDriver_Click);
            // 
            // lblUnattendTemplatePath
            // 
            this.lblUnattendTemplatePath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUnattendTemplatePath.AutoSize = true;
            this.lblUnattendTemplatePath.Location = new System.Drawing.Point(3, 44);
            this.lblUnattendTemplatePath.Name = "lblUnattendTemplatePath";
            this.lblUnattendTemplatePath.Size = new System.Drawing.Size(129, 15);
            this.lblUnattendTemplatePath.TabIndex = 18;
            this.lblUnattendTemplatePath.Text = "Unattend Template Path";
            // 
            // txtUnattendTemplatePath
            // 
            this.txtUnattendTemplatePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnattendTemplatePath.Location = new System.Drawing.Point(241, 40);
            this.txtUnattendTemplatePath.Name = "txtUnattendTemplatePath";
            this.txtUnattendTemplatePath.Size = new System.Drawing.Size(438, 23);
            this.txtUnattendTemplatePath.TabIndex = 19;
            // 
            // btnBrowseUnattend
            // 
            this.btnBrowseUnattend.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBrowseUnattend.Location = new System.Drawing.Point(685, 38);
            this.btnBrowseUnattend.Name = "btnBrowseUnattend";
            this.btnBrowseUnattend.Size = new System.Drawing.Size(90, 27);
            this.btnBrowseUnattend.TabIndex = 20;
            this.btnBrowseUnattend.Text = "Browse...";
            this.btnBrowseUnattend.UseVisualStyleBackColor = true;
            this.btnBrowseUnattend.Click += new System.EventHandler(this.BtnBrowseUnattend_Click);
            // 
            // lblOdjBlobPath
            // 
            this.lblOdjBlobPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOdjBlobPath.AutoSize = true;
            this.lblOdjBlobPath.Location = new System.Drawing.Point(3, 78);
            this.lblOdjBlobPath.Name = "lblOdjBlobPath";
            this.lblOdjBlobPath.Size = new System.Drawing.Size(76, 15);
            this.lblOdjBlobPath.TabIndex = 21;
            this.lblOdjBlobPath.Text = "ODJ Blob Path";
            // 
            // txtOdjBlobPath
            // 
            this.txtOdjBlobPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOdjBlobPath.Location = new System.Drawing.Point(241, 74);
            this.txtOdjBlobPath.Name = "txtOdjBlobPath";
            this.txtOdjBlobPath.Size = new System.Drawing.Size(438, 23);
            this.txtOdjBlobPath.TabIndex = 22;
            // 
            // btnBrowseOdj
            // 
            this.btnBrowseOdj.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBrowseOdj.Location = new System.Drawing.Point(685, 72);
            this.btnBrowseOdj.Name = "btnBrowseOdj";
            this.btnBrowseOdj.Size = new System.Drawing.Size(90, 27);
            this.btnBrowseOdj.TabIndex = 23;
            this.btnBrowseOdj.Text = "Browse...";
            this.btnBrowseOdj.UseVisualStyleBackColor = true;
            this.btnBrowseOdj.Click += new System.EventHandler(this.BtnBrowseOdj_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
            this.panelButtons.Controls.Add(this.btnStartDeployment);
            this.panelButtons.Controls.Add(this.btnSaveConfig);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 572);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.panelButtons.Size = new System.Drawing.Size(876, 48);
            this.panelButtons.TabIndex = 1;
            // 
            // btnStartDeployment
            // 
            this.btnStartDeployment.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnStartDeployment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.btnStartDeployment.FlatAppearance.BorderSize = 0;
            this.btnStartDeployment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartDeployment.ForeColor = System.Drawing.Color.White;
            this.btnStartDeployment.Location = new System.Drawing.Point(730, 10);
            this.btnStartDeployment.Name = "btnStartDeployment";
            this.btnStartDeployment.Size = new System.Drawing.Size(134, 28);
            this.btnStartDeployment.TabIndex = 1;
            this.btnStartDeployment.Text = "Start Deployment";
            this.btnStartDeployment.UseVisualStyleBackColor = false;
            this.btnStartDeployment.Click += new System.EventHandler(this.BtnStartDeployment_Click);
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSaveConfig.BackColor = System.Drawing.Color.White;
            this.btnSaveConfig.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.btnSaveConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveConfig.Location = new System.Drawing.Point(15, 10);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(134, 28);
            this.btnSaveConfig.TabIndex = 0;
            this.btnSaveConfig.Text = "Save Configuration";
            this.btnSaveConfig.UseVisualStyleBackColor = false;
            this.btnSaveConfig.Click += new System.EventHandler(this.BtnSaveConfig_Click);
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(876, 106);
            this.txtLog.TabIndex = 2;
            // 
            // statusStrip
            // 
            this.statusStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.statusProgress});
            this.statusStrip.Location = new System.Drawing.Point(12, 808);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip.Size = new System.Drawing.Size(876, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(39, 17);
            this.statusLabel.Text = "Ready";
            // 
            // statusProgress
            // 
            this.statusProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.statusProgress.Name = "statusProgress";
            this.statusProgress.Size = new System.Drawing.Size(200, 16);
            this.statusProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.statusProgress.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(900, 842);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(840, 640);
            this.Padding = new System.Windows.Forms.Padding(12);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Automated Deployment and Servicing (ADS)";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.tableGeneral.ResumeLayout(false);
            this.tableGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImageIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetDisk)).EndInit();
            this.tabNetwork.ResumeLayout(false);
            this.tabNetwork.PerformLayout();
            this.tableNetwork.ResumeLayout(false);
            this.tableNetwork.PerformLayout();
            this.tabAdvanced.ResumeLayout(false);
            this.tabAdvanced.PerformLayout();
            this.tableAdvanced.ResumeLayout(false);
            this.tableAdvanced.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TableLayoutPanel tableGeneral;
        private System.Windows.Forms.Label lblComputerName;
        private System.Windows.Forms.TextBox txtComputerName;
        private System.Windows.Forms.Label lblOsVersion;
        private System.Windows.Forms.ComboBox cmbOsVersion;
        private System.Windows.Forms.Label lblImagePath;
        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.Button btnBrowseImage;
        private System.Windows.Forms.Label lblImageIndex;
        private System.Windows.Forms.NumericUpDown numImageIndex;
        private System.Windows.Forms.Label lblTargetDisk;
        private System.Windows.Forms.NumericUpDown numTargetDisk;
        private System.Windows.Forms.CheckBox chkFormatAdditionalDisks;
        private System.Windows.Forms.Label lblPlatform;
        private System.Windows.Forms.ComboBox cmbPlatform;
        private System.Windows.Forms.Label lblSavePath;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Button btnBrowseSave;
        private System.Windows.Forms.TabPage tabNetwork;
        private System.Windows.Forms.TableLayoutPanel tableNetwork;
        private System.Windows.Forms.Label lblNetworkShare;
        private System.Windows.Forms.TextBox txtNetworkShare;
        private System.Windows.Forms.Label lblNetworkUser;
        private System.Windows.Forms.TextBox txtNetworkUser;
        private System.Windows.Forms.Label lblNetworkPassword;
        private System.Windows.Forms.TextBox txtNetworkPassword;
        private System.Windows.Forms.CheckBox chkStaticIp;
        private System.Windows.Forms.Label lblStaticIp;
        private System.Windows.Forms.TextBox txtStaticIp;
        private System.Windows.Forms.Label lblStaticSubnet;
        private System.Windows.Forms.ComboBox cmbStaticSubnet;
        private System.Windows.Forms.Label lblStaticGateway;
        private System.Windows.Forms.TextBox txtStaticGateway;
        private System.Windows.Forms.Label lblStaticDns;
        private System.Windows.Forms.TextBox txtStaticDns;
        private System.Windows.Forms.TabPage tabAdvanced;
        private System.Windows.Forms.TableLayoutPanel tableAdvanced;
        private System.Windows.Forms.Label lblDriverPackPath;
        private System.Windows.Forms.TextBox txtDriverPackPath;
        private System.Windows.Forms.Button btnBrowseDriver;
        private System.Windows.Forms.Label lblUnattendTemplatePath;
        private System.Windows.Forms.TextBox txtUnattendTemplatePath;
        private System.Windows.Forms.Button btnBrowseUnattend;
        private System.Windows.Forms.Label lblOdjBlobPath;
        private System.Windows.Forms.TextBox txtOdjBlobPath;
        private System.Windows.Forms.Button btnBrowseOdj;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnStartDeployment;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripProgressBar statusProgress;
    }
}
