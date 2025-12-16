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
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
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
            this.lblFormatAdditionalDisks = new System.Windows.Forms.Label();
            this.chkFormatAdditionalDisks = new System.Windows.Forms.CheckBox();
            this.lblPlatform = new System.Windows.Forms.Label();
            this.cmbPlatform = new System.Windows.Forms.ComboBox();
            this.lblDriverPackPath = new System.Windows.Forms.Label();
            this.txtDriverPackPath = new System.Windows.Forms.TextBox();
            this.btnBrowseDriver = new System.Windows.Forms.Button();
            this.lblUnattendTemplatePath = new System.Windows.Forms.Label();
            this.txtUnattendTemplatePath = new System.Windows.Forms.TextBox();
            this.btnBrowseUnattend = new System.Windows.Forms.Button();
            this.lblOdjBlobPath = new System.Windows.Forms.Label();
            this.txtOdjBlobPath = new System.Windows.Forms.TextBox();
            this.btnBrowseOdj = new System.Windows.Forms.Button();
            this.lblSavePath = new System.Windows.Forms.Label();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.btnBrowseSave = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnStartDeployment = new System.Windows.Forms.Button();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.chkStaticIp = new System.Windows.Forms.CheckBox();
            this.lblStaticIp = new System.Windows.Forms.Label();
            this.txtStaticIp = new System.Windows.Forms.TextBox();
            this.lblStaticSubnet = new System.Windows.Forms.Label();
            this.txtStaticSubnet = new System.Windows.Forms.TextBox();
            this.lblStaticGateway = new System.Windows.Forms.Label();
            this.txtStaticGateway = new System.Windows.Forms.TextBox();
            this.lblStaticDns = new System.Windows.Forms.Label();
            this.txtStaticDns = new System.Windows.Forms.TextBox();
            this.panelHeader.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImageIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetDisk)).BeginInit();
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
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.ColumnCount = 3;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelMain.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanelMain.Controls.Add(this.lblComputerName, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.txtComputerName, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.lblOsVersion, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.cmbOsVersion, 1, 1);
            this.tableLayoutPanelMain.Controls.Add(this.lblImagePath, 0, 2);
            this.tableLayoutPanelMain.Controls.Add(this.txtImagePath, 1, 2);
            this.tableLayoutPanelMain.Controls.Add(this.btnBrowseImage, 2, 2);
            this.tableLayoutPanelMain.Controls.Add(this.lblImageIndex, 0, 3);
            this.tableLayoutPanelMain.Controls.Add(this.numImageIndex, 1, 3);
            this.tableLayoutPanelMain.Controls.Add(this.lblTargetDisk, 0, 4);
            this.tableLayoutPanelMain.Controls.Add(this.numTargetDisk, 1, 4);
            this.tableLayoutPanelMain.Controls.Add(this.lblFormatAdditionalDisks, 0, 5);
            this.tableLayoutPanelMain.Controls.Add(this.chkFormatAdditionalDisks, 1, 5);
            this.tableLayoutPanelMain.Controls.Add(this.lblPlatform, 0, 6);
            this.tableLayoutPanelMain.Controls.Add(this.cmbPlatform, 1, 6);
            this.tableLayoutPanelMain.Controls.Add(this.lblDriverPackPath, 0, 7);
            this.tableLayoutPanelMain.Controls.Add(this.txtDriverPackPath, 1, 7);
            this.tableLayoutPanelMain.Controls.Add(this.btnBrowseDriver, 2, 7);
            this.tableLayoutPanelMain.Controls.Add(this.lblUnattendTemplatePath, 0, 8);
            this.tableLayoutPanelMain.Controls.Add(this.txtUnattendTemplatePath, 1, 8);
            this.tableLayoutPanelMain.Controls.Add(this.btnBrowseUnattend, 2, 8);
            this.tableLayoutPanelMain.Controls.Add(this.lblOdjBlobPath, 0, 9);
            this.tableLayoutPanelMain.Controls.Add(this.txtOdjBlobPath, 1, 9);
            this.tableLayoutPanelMain.Controls.Add(this.btnBrowseOdj, 2, 9);
            this.tableLayoutPanelMain.Controls.Add(this.chkStaticIp, 0, 10);
            this.tableLayoutPanelMain.Controls.Add(this.lblStaticIp, 0, 11);
            this.tableLayoutPanelMain.Controls.Add(this.txtStaticIp, 1, 11);
            this.tableLayoutPanelMain.Controls.Add(this.lblStaticSubnet, 0, 12);
            this.tableLayoutPanelMain.Controls.Add(this.txtStaticSubnet, 1, 12);
            this.tableLayoutPanelMain.Controls.Add(this.lblStaticGateway, 0, 13);
            this.tableLayoutPanelMain.Controls.Add(this.txtStaticGateway, 1, 13);
            this.tableLayoutPanelMain.Controls.Add(this.lblStaticDns, 0, 14);
            this.tableLayoutPanelMain.Controls.Add(this.txtStaticDns, 1, 14);
            this.tableLayoutPanelMain.Controls.Add(this.lblSavePath, 0, 15);
            this.tableLayoutPanelMain.Controls.Add(this.txtSavePath, 1, 15);
            this.tableLayoutPanelMain.Controls.Add(this.btnBrowseSave, 2, 15);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(12, 92);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(12, 16, 12, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.Padding = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.tableLayoutPanelMain.RowCount = 16;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(876, 512);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // lblComputerName
            // 
            this.lblComputerName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblComputerName.AutoSize = true;
            this.lblComputerName.Location = new System.Drawing.Point(3, 9);
            this.lblComputerName.Name = "lblComputerName";
            this.lblComputerName.Size = new System.Drawing.Size(111, 13);
            this.lblComputerName.TabIndex = 0;
            this.lblComputerName.Text = "Computer Name *";
            // 
            // txtComputerName
            // 
            this.txtComputerName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtComputerName.Location = new System.Drawing.Point(222, 6);
            this.txtComputerName.MaxLength = 15;
            this.txtComputerName.Name = "txtComputerName";
            this.txtComputerName.Size = new System.Drawing.Size(220, 23);
            this.txtComputerName.TabIndex = 1;
            // 
            // lblOsVersion
            // 
            this.lblOsVersion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOsVersion.AutoSize = true;
            this.lblOsVersion.Location = new System.Drawing.Point(3, 43);
            this.lblOsVersion.Name = "lblOsVersion";
            this.lblOsVersion.Size = new System.Drawing.Size(72, 13);
            this.lblOsVersion.TabIndex = 2;
            this.lblOsVersion.Text = "OS Version *";
            // 
            // cmbOsVersion
            // 
            this.cmbOsVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbOsVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOsVersion.FormattingEnabled = true;
            this.cmbOsVersion.Items.AddRange(new object[] {
            "Server2019",
            "Server2022",
            "Server2025"});
            this.cmbOsVersion.Location = new System.Drawing.Point(222, 37);
            this.cmbOsVersion.Name = "cmbOsVersion";
            this.cmbOsVersion.Size = new System.Drawing.Size(475, 23);
            this.cmbOsVersion.TabIndex = 3;
            // 
            // lblImagePath
            // 
            this.lblImagePath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblImagePath.AutoSize = true;
            this.lblImagePath.Location = new System.Drawing.Point(3, 77);
            this.lblImagePath.Name = "lblImagePath";
            this.lblImagePath.Size = new System.Drawing.Size(80, 13);
            this.lblImagePath.TabIndex = 4;
            this.lblImagePath.Text = "Image Path *";
            // 
            // txtImagePath
            // 
            this.txtImagePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImagePath.Location = new System.Drawing.Point(222, 71);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Size = new System.Drawing.Size(475, 23);
            this.txtImagePath.TabIndex = 5;
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBrowseImage.Location = new System.Drawing.Point(703, 69);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(90, 27);
            this.btnBrowseImage.TabIndex = 6;
            this.btnBrowseImage.Text = "Browse...";
            this.btnBrowseImage.UseVisualStyleBackColor = true;
            this.btnBrowseImage.Click += new System.EventHandler(this.BtnBrowseImage_Click);
            // 
            // lblImageIndex
            // 
            this.lblImageIndex.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblImageIndex.AutoSize = true;
            this.lblImageIndex.Location = new System.Drawing.Point(3, 111);
            this.lblImageIndex.Name = "lblImageIndex";
            this.lblImageIndex.Size = new System.Drawing.Size(79, 13);
            this.lblImageIndex.TabIndex = 7;
            this.lblImageIndex.Text = "Image Index *";
            // 
            // numImageIndex
            // 
            this.numImageIndex.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numImageIndex.Location = new System.Drawing.Point(222, 108);
            this.numImageIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numImageIndex.Name = "numImageIndex";
            this.numImageIndex.Size = new System.Drawing.Size(120, 23);
            this.numImageIndex.TabIndex = 8;
            this.numImageIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblTargetDisk
            // 
            this.lblTargetDisk.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTargetDisk.AutoSize = true;
            this.lblTargetDisk.Location = new System.Drawing.Point(3, 145);
            this.lblTargetDisk.Name = "lblTargetDisk";
            this.lblTargetDisk.Size = new System.Drawing.Size(73, 13);
            this.lblTargetDisk.TabIndex = 9;
            this.lblTargetDisk.Text = "Target Disk *";
            // 
            // numTargetDisk
            // 
            this.numTargetDisk.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numTargetDisk.Location = new System.Drawing.Point(222, 142);
            this.numTargetDisk.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numTargetDisk.Name = "numTargetDisk";
            this.numTargetDisk.Size = new System.Drawing.Size(120, 23);
            this.numTargetDisk.TabIndex = 10;
            // 
            // lblFormatAdditionalDisks
            // 
            this.lblFormatAdditionalDisks.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFormatAdditionalDisks.AutoSize = true;
            this.lblFormatAdditionalDisks.Location = new System.Drawing.Point(3, 179);
            this.lblFormatAdditionalDisks.Name = "lblFormatAdditionalDisks";
            this.lblFormatAdditionalDisks.Size = new System.Drawing.Size(145, 13);
            this.lblFormatAdditionalDisks.TabIndex = 11;
            this.lblFormatAdditionalDisks.Text = "Additional disks (optional)";
            // 
            // chkFormatAdditionalDisks
            // 
            this.chkFormatAdditionalDisks.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkFormatAdditionalDisks.AutoSize = true;
            this.chkFormatAdditionalDisks.Location = new System.Drawing.Point(222, 177);
            this.chkFormatAdditionalDisks.Name = "chkFormatAdditionalDisks";
            this.chkFormatAdditionalDisks.Size = new System.Drawing.Size(248, 19);
            this.chkFormatAdditionalDisks.TabIndex = 12;
            this.chkFormatAdditionalDisks.Text = "Format all non-OS disks (destructive wipe)";
            this.chkFormatAdditionalDisks.UseVisualStyleBackColor = true;
            // 
            // lblPlatform
            // 
            this.lblPlatform.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPlatform.AutoSize = true;
            this.lblPlatform.Location = new System.Drawing.Point(3, 213);
            this.lblPlatform.Name = "lblPlatform";
            this.lblPlatform.Size = new System.Drawing.Size(60, 13);
            this.lblPlatform.TabIndex = 13;
            this.lblPlatform.Text = "Platform *";
            // 
            // cmbPlatform
            // 
            this.cmbPlatform.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPlatform.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlatform.FormattingEnabled = true;
            this.cmbPlatform.Items.AddRange(new object[] {
            "VMware",
            "Proxmox"});
            this.cmbPlatform.Location = new System.Drawing.Point(222, 207);
            this.cmbPlatform.Name = "cmbPlatform";
            this.cmbPlatform.Size = new System.Drawing.Size(475, 23);
            this.cmbPlatform.TabIndex = 14;
            // 
            // lblDriverPackPath
            // 
            this.lblDriverPackPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDriverPackPath.AutoSize = true;
            this.lblDriverPackPath.Location = new System.Drawing.Point(3, 247);
            this.lblDriverPackPath.Name = "lblDriverPackPath";
            this.lblDriverPackPath.Size = new System.Drawing.Size(99, 13);
            this.lblDriverPackPath.TabIndex = 15;
            this.lblDriverPackPath.Text = "Driver Pack Path";
            // 
            // txtDriverPackPath
            // 
            this.txtDriverPackPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDriverPackPath.Location = new System.Drawing.Point(222, 241);
            this.txtDriverPackPath.Name = "txtDriverPackPath";
            this.txtDriverPackPath.Size = new System.Drawing.Size(475, 23);
            this.txtDriverPackPath.TabIndex = 16;
            // 
            // btnBrowseDriver
            // 
            this.btnBrowseDriver.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBrowseDriver.Location = new System.Drawing.Point(703, 239);
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
            this.lblUnattendTemplatePath.Location = new System.Drawing.Point(3, 281);
            this.lblUnattendTemplatePath.Name = "lblUnattendTemplatePath";
            this.lblUnattendTemplatePath.Size = new System.Drawing.Size(133, 13);
            this.lblUnattendTemplatePath.TabIndex = 18;
            this.lblUnattendTemplatePath.Text = "Unattend Template Path";
            // 
            // txtUnattendTemplatePath
            // 
            this.txtUnattendTemplatePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnattendTemplatePath.Location = new System.Drawing.Point(222, 275);
            this.txtUnattendTemplatePath.Name = "txtUnattendTemplatePath";
            this.txtUnattendTemplatePath.Size = new System.Drawing.Size(475, 23);
            this.txtUnattendTemplatePath.TabIndex = 19;
            // 
            // btnBrowseUnattend
            // 
            this.btnBrowseUnattend.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBrowseUnattend.Location = new System.Drawing.Point(703, 273);
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
            this.lblOdjBlobPath.Location = new System.Drawing.Point(3, 315);
            this.lblOdjBlobPath.Name = "lblOdjBlobPath";
            this.lblOdjBlobPath.Size = new System.Drawing.Size(77, 13);
            this.lblOdjBlobPath.TabIndex = 21;
            this.lblOdjBlobPath.Text = "ODJ Blob Path";
            // 
            // txtOdjBlobPath
            // 
            this.txtOdjBlobPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOdjBlobPath.Location = new System.Drawing.Point(222, 309);
            this.txtOdjBlobPath.Name = "txtOdjBlobPath";
            this.txtOdjBlobPath.Size = new System.Drawing.Size(475, 23);
            this.txtOdjBlobPath.TabIndex = 22;
            // 
            // btnBrowseOdj
            // 
            this.btnBrowseOdj.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBrowseOdj.Location = new System.Drawing.Point(703, 307);
            this.btnBrowseOdj.Name = "btnBrowseOdj";
            this.btnBrowseOdj.Size = new System.Drawing.Size(90, 27);
            this.btnBrowseOdj.TabIndex = 23;
            this.btnBrowseOdj.Text = "Browse...";
            this.btnBrowseOdj.UseVisualStyleBackColor = true;
            this.btnBrowseOdj.Click += new System.EventHandler(this.BtnBrowseOdj_Click);
            // 
            // chkStaticIp
            // 
            this.chkStaticIp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkStaticIp.AutoSize = true;
            this.chkStaticIp.Location = new System.Drawing.Point(3, 347);
            this.chkStaticIp.Name = "chkStaticIp";
            this.chkStaticIp.Size = new System.Drawing.Size(119, 19);
            this.chkStaticIp.TabIndex = 24;
            this.chkStaticIp.Text = "Use Static IP (opt)";
            this.chkStaticIp.UseVisualStyleBackColor = true;
            this.chkStaticIp.CheckedChanged += new System.EventHandler(this.ChkStaticIp_CheckedChanged);
            // 
            // lblStaticIp
            // 
            this.lblStaticIp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStaticIp.AutoSize = true;
            this.lblStaticIp.Location = new System.Drawing.Point(3, 381);
            this.lblStaticIp.Name = "lblStaticIp";
            this.lblStaticIp.Size = new System.Drawing.Size(91, 13);
            this.lblStaticIp.TabIndex = 25;
            this.lblStaticIp.Text = "Static IP Address";
            // 
            // txtStaticIp
            // 
            this.txtStaticIp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtStaticIp.Location = new System.Drawing.Point(222, 377);
            this.txtStaticIp.MaxLength = 15;
            this.txtStaticIp.Name = "txtStaticIp";
            this.txtStaticIp.Size = new System.Drawing.Size(220, 23);
            this.txtStaticIp.TabIndex = 26;
            // 
            // lblStaticSubnet
            // 
            this.lblStaticSubnet.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStaticSubnet.AutoSize = true;
            this.lblStaticSubnet.Location = new System.Drawing.Point(3, 415);
            this.lblStaticSubnet.Name = "lblStaticSubnet";
            this.lblStaticSubnet.Size = new System.Drawing.Size(94, 13);
            this.lblStaticSubnet.TabIndex = 27;
            this.lblStaticSubnet.Text = "Static Subnet Mask";
            // 
            // txtStaticSubnet
            // 
            this.txtStaticSubnet.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtStaticSubnet.Location = new System.Drawing.Point(222, 411);
            this.txtStaticSubnet.MaxLength = 15;
            this.txtStaticSubnet.Name = "txtStaticSubnet";
            this.txtStaticSubnet.Size = new System.Drawing.Size(220, 23);
            this.txtStaticSubnet.TabIndex = 28;
            // 
            // lblStaticGateway
            // 
            this.lblStaticGateway.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStaticGateway.AutoSize = true;
            this.lblStaticGateway.Location = new System.Drawing.Point(3, 449);
            this.lblStaticGateway.Name = "lblStaticGateway";
            this.lblStaticGateway.Size = new System.Drawing.Size(85, 13);
            this.lblStaticGateway.TabIndex = 29;
            this.lblStaticGateway.Text = "Static Gateway";
            // 
            // txtStaticGateway
            // 
            this.txtStaticGateway.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtStaticGateway.Location = new System.Drawing.Point(222, 445);
            this.txtStaticGateway.MaxLength = 15;
            this.txtStaticGateway.Name = "txtStaticGateway";
            this.txtStaticGateway.Size = new System.Drawing.Size(220, 23);
            this.txtStaticGateway.TabIndex = 30;
            // 
            // lblStaticDns
            // 
            this.lblStaticDns.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStaticDns.AutoSize = true;
            this.lblStaticDns.Location = new System.Drawing.Point(3, 483);
            this.lblStaticDns.Name = "lblStaticDns";
            this.lblStaticDns.Size = new System.Drawing.Size(121, 13);
            this.lblStaticDns.TabIndex = 31;
            this.lblStaticDns.Text = "Static DNS (comma list)";
            // 
            // txtStaticDns
            // 
            this.txtStaticDns.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtStaticDns.Location = new System.Drawing.Point(222, 479);
            this.txtStaticDns.MaxLength = 64;
            this.txtStaticDns.Name = "txtStaticDns";
            this.txtStaticDns.Size = new System.Drawing.Size(260, 23);
            this.txtStaticDns.TabIndex = 32;
            // 
            // lblSavePath
            // 
            this.lblSavePath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSavePath.AutoSize = true;
            this.lblSavePath.Location = new System.Drawing.Point(3, 517);
            this.lblSavePath.Name = "lblSavePath";
            this.lblSavePath.Size = new System.Drawing.Size(80, 13);
            this.lblSavePath.TabIndex = 33;
            this.lblSavePath.Text = "Config Save To";
            // 
            // txtSavePath
            // 
            this.txtSavePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSavePath.Location = new System.Drawing.Point(222, 513);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(475, 23);
            this.txtSavePath.TabIndex = 34;
            // 
            // btnBrowseSave
            // 
            this.btnBrowseSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBrowseSave.Location = new System.Drawing.Point(703, 511);
            this.btnBrowseSave.Name = "btnBrowseSave";
            this.btnBrowseSave.Size = new System.Drawing.Size(90, 27);
            this.btnBrowseSave.TabIndex = 35;
            this.btnBrowseSave.Text = "Browse...";
            this.btnBrowseSave.UseVisualStyleBackColor = true;
            this.btnBrowseSave.Click += new System.EventHandler(this.BtnBrowseSave_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
            this.panelButtons.Controls.Add(this.btnStartDeployment);
            this.panelButtons.Controls.Add(this.btnSaveConfig);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtons.Location = new System.Drawing.Point(12, 12);
            this.panelButtons.Margin = new System.Windows.Forms.Padding(12, 12, 12, 0);
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
            this.btnStartDeployment.Location = new System.Drawing.Point(727, 10);
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
            this.txtLog.Location = new System.Drawing.Point(12, 614);
            this.txtLog.Margin = new System.Windows.Forms.Padding(12, 0, 12, 12);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(876, 190);
            this.txtLog.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(900, 816);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.txtLog);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(880, 700);
            this.Padding = new System.Windows.Forms.Padding(12);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Automated Deployment and Servicing (ADS)";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImageIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetDisk)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
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
        private System.Windows.Forms.Label lblFormatAdditionalDisks;
        private System.Windows.Forms.CheckBox chkFormatAdditionalDisks;
        private System.Windows.Forms.Label lblPlatform;
        private System.Windows.Forms.ComboBox cmbPlatform;
        private System.Windows.Forms.Label lblDriverPackPath;
        private System.Windows.Forms.TextBox txtDriverPackPath;
        private System.Windows.Forms.Button btnBrowseDriver;
        private System.Windows.Forms.Label lblUnattendTemplatePath;
        private System.Windows.Forms.TextBox txtUnattendTemplatePath;
        private System.Windows.Forms.Button btnBrowseUnattend;
        private System.Windows.Forms.Label lblOdjBlobPath;
        private System.Windows.Forms.TextBox txtOdjBlobPath;
        private System.Windows.Forms.Button btnBrowseOdj;
        private System.Windows.Forms.Label lblSavePath;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Button btnBrowseSave;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnStartDeployment;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.CheckBox chkStaticIp;
        private System.Windows.Forms.Label lblStaticIp;
        private System.Windows.Forms.TextBox txtStaticIp;
        private System.Windows.Forms.Label lblStaticSubnet;
        private System.Windows.Forms.TextBox txtStaticSubnet;
        private System.Windows.Forms.Label lblStaticGateway;
        private System.Windows.Forms.TextBox txtStaticGateway;
        private System.Windows.Forms.Label lblStaticDns;
        private System.Windows.Forms.TextBox txtStaticDns;
    }
}
