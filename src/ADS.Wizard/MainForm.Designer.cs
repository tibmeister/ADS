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
            this.tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImageIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetDisk)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelMain.ColumnCount = 3;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
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
            this.tableLayoutPanelMain.Controls.Add(this.lblPlatform, 0, 5);
            this.tableLayoutPanelMain.Controls.Add(this.cmbPlatform, 1, 5);
            this.tableLayoutPanelMain.Controls.Add(this.lblDriverPackPath, 0, 6);
            this.tableLayoutPanelMain.Controls.Add(this.txtDriverPackPath, 1, 6);
            this.tableLayoutPanelMain.Controls.Add(this.btnBrowseDriver, 2, 6);
            this.tableLayoutPanelMain.Controls.Add(this.lblUnattendTemplatePath, 0, 7);
            this.tableLayoutPanelMain.Controls.Add(this.txtUnattendTemplatePath, 1, 7);
            this.tableLayoutPanelMain.Controls.Add(this.btnBrowseUnattend, 2, 7);
            this.tableLayoutPanelMain.Controls.Add(this.lblOdjBlobPath, 0, 8);
            this.tableLayoutPanelMain.Controls.Add(this.txtOdjBlobPath, 1, 8);
            this.tableLayoutPanelMain.Controls.Add(this.btnBrowseOdj, 2, 8);
            this.tableLayoutPanelMain.Controls.Add(this.chkStaticIp, 0, 9);
            this.tableLayoutPanelMain.Controls.Add(this.lblStaticIp, 0, 10);
            this.tableLayoutPanelMain.Controls.Add(this.txtStaticIp, 1, 10);
            this.tableLayoutPanelMain.Controls.Add(this.lblStaticSubnet, 0, 11);
            this.tableLayoutPanelMain.Controls.Add(this.txtStaticSubnet, 1, 11);
            this.tableLayoutPanelMain.Controls.Add(this.lblStaticGateway, 0, 12);
            this.tableLayoutPanelMain.Controls.Add(this.txtStaticGateway, 1, 12);
            this.tableLayoutPanelMain.Controls.Add(this.lblStaticDns, 0, 13);
            this.tableLayoutPanelMain.Controls.Add(this.txtStaticDns, 1, 13);
            this.tableLayoutPanelMain.Controls.Add(this.lblSavePath, 0, 14);
            this.tableLayoutPanelMain.Controls.Add(this.txtSavePath, 1, 14);
            this.tableLayoutPanelMain.Controls.Add(this.btnBrowseSave, 2, 14);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 15;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(760, 450);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // lblComputerName
            // 
            this.lblComputerName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblComputerName.AutoSize = true;
            this.lblComputerName.Location = new System.Drawing.Point(3, 8);
            this.lblComputerName.Name = "lblComputerName";
            this.lblComputerName.Size = new System.Drawing.Size(106, 13);
            this.lblComputerName.TabIndex = 0;
            this.lblComputerName.Text = "Computer Name *";
            // 
            // txtComputerName
            // 
            this.txtComputerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComputerName.Location = new System.Drawing.Point(193, 5);
            this.txtComputerName.Name = "txtComputerName";
            this.txtComputerName.Size = new System.Drawing.Size(412, 20);
            this.txtComputerName.TabIndex = 1;
            // 
            // lblOsVersion
            // 
            this.lblOsVersion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOsVersion.AutoSize = true;
            this.lblOsVersion.Location = new System.Drawing.Point(3, 38);
            this.lblOsVersion.Name = "lblOsVersion";
            this.lblOsVersion.Size = new System.Drawing.Size(71, 13);
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
            this.cmbOsVersion.Location = new System.Drawing.Point(193, 34);
            this.cmbOsVersion.Name = "cmbOsVersion";
            this.cmbOsVersion.Size = new System.Drawing.Size(412, 21);
            this.cmbOsVersion.TabIndex = 3;
            // 
            // lblImagePath
            // 
            this.lblImagePath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblImagePath.AutoSize = true;
            this.lblImagePath.Location = new System.Drawing.Point(3, 68);
            this.lblImagePath.Name = "lblImagePath";
            this.lblImagePath.Size = new System.Drawing.Size(80, 13);
            this.lblImagePath.TabIndex = 4;
            this.lblImagePath.Text = "Image Path *";
            // 
            // txtImagePath
            // 
            this.txtImagePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImagePath.Location = new System.Drawing.Point(193, 65);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Size = new System.Drawing.Size(412, 20);
            this.txtImagePath.TabIndex = 5;
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBrowseImage.Location = new System.Drawing.Point(611, 63);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseImage.TabIndex = 6;
            this.btnBrowseImage.Text = "Browse...";
            this.btnBrowseImage.UseVisualStyleBackColor = true;
            this.btnBrowseImage.Click += new System.EventHandler(this.BtnBrowseImage_Click);
            // 
            // lblImageIndex
            // 
            this.lblImageIndex.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblImageIndex.AutoSize = true;
            this.lblImageIndex.Location = new System.Drawing.Point(3, 98);
            this.lblImageIndex.Name = "lblImageIndex";
            this.lblImageIndex.Size = new System.Drawing.Size(79, 13);
            this.lblImageIndex.TabIndex = 7;
            this.lblImageIndex.Text = "Image Index *";
            // 
            // numImageIndex
            // 
            this.numImageIndex.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numImageIndex.Location = new System.Drawing.Point(193, 95);
            this.numImageIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numImageIndex.Name = "numImageIndex";
            this.numImageIndex.Size = new System.Drawing.Size(120, 20);
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
            this.lblTargetDisk.Location = new System.Drawing.Point(3, 128);
            this.lblTargetDisk.Name = "lblTargetDisk";
            this.lblTargetDisk.Size = new System.Drawing.Size(73, 13);
            this.lblTargetDisk.TabIndex = 9;
            this.lblTargetDisk.Text = "Target Disk *";
            // 
            // numTargetDisk
            // 
            this.numTargetDisk.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numTargetDisk.Location = new System.Drawing.Point(193, 125);
            this.numTargetDisk.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numTargetDisk.Name = "numTargetDisk";
            this.numTargetDisk.Size = new System.Drawing.Size(120, 20);
            this.numTargetDisk.TabIndex = 10;
            // 
            // lblPlatform
            // 
            this.lblPlatform.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPlatform.AutoSize = true;
            this.lblPlatform.Location = new System.Drawing.Point(3, 158);
            this.lblPlatform.Name = "lblPlatform";
            this.lblPlatform.Size = new System.Drawing.Size(60, 13);
            this.lblPlatform.TabIndex = 11;
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
            this.cmbPlatform.Location = new System.Drawing.Point(193, 154);
            this.cmbPlatform.Name = "cmbPlatform";
            this.cmbPlatform.Size = new System.Drawing.Size(412, 21);
            this.cmbPlatform.TabIndex = 12;
            // 
            // lblDriverPackPath
            // 
            this.lblDriverPackPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDriverPackPath.AutoSize = true;
            this.lblDriverPackPath.Location = new System.Drawing.Point(3, 188);
            this.lblDriverPackPath.Name = "lblDriverPackPath";
            this.lblDriverPackPath.Size = new System.Drawing.Size(99, 13);
            this.lblDriverPackPath.TabIndex = 13;
            this.lblDriverPackPath.Text = "Driver Pack Path";
            // 
            // txtDriverPackPath
            // 
            this.txtDriverPackPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDriverPackPath.Location = new System.Drawing.Point(193, 185);
            this.txtDriverPackPath.Name = "txtDriverPackPath";
            this.txtDriverPackPath.Size = new System.Drawing.Size(412, 20);
            this.txtDriverPackPath.TabIndex = 14;
            // 
            // btnBrowseDriver
            // 
            this.btnBrowseDriver.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBrowseDriver.Location = new System.Drawing.Point(611, 183);
            this.btnBrowseDriver.Name = "btnBrowseDriver";
            this.btnBrowseDriver.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseDriver.TabIndex = 15;
            this.btnBrowseDriver.Text = "Browse...";
            this.btnBrowseDriver.UseVisualStyleBackColor = true;
            this.btnBrowseDriver.Click += new System.EventHandler(this.BtnBrowseDriver_Click);
            // 
            // lblUnattendTemplatePath
            // 
            this.lblUnattendTemplatePath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUnattendTemplatePath.AutoSize = true;
            this.lblUnattendTemplatePath.Location = new System.Drawing.Point(3, 218);
            this.lblUnattendTemplatePath.Name = "lblUnattendTemplatePath";
            this.lblUnattendTemplatePath.Size = new System.Drawing.Size(133, 13);
            this.lblUnattendTemplatePath.TabIndex = 16;
            this.lblUnattendTemplatePath.Text = "Unattend Template Path";
            // 
            // txtUnattendTemplatePath
            // 
            this.txtUnattendTemplatePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnattendTemplatePath.Location = new System.Drawing.Point(193, 215);
            this.txtUnattendTemplatePath.Name = "txtUnattendTemplatePath";
            this.txtUnattendTemplatePath.Size = new System.Drawing.Size(412, 20);
            this.txtUnattendTemplatePath.TabIndex = 17;
            // 
            // btnBrowseUnattend
            // 
            this.btnBrowseUnattend.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBrowseUnattend.Location = new System.Drawing.Point(611, 213);
            this.btnBrowseUnattend.Name = "btnBrowseUnattend";
            this.btnBrowseUnattend.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseUnattend.TabIndex = 18;
            this.btnBrowseUnattend.Text = "Browse...";
            this.btnBrowseUnattend.UseVisualStyleBackColor = true;
            this.btnBrowseUnattend.Click += new System.EventHandler(this.BtnBrowseUnattend_Click);
            // 
            // lblOdjBlobPath
            // 
            this.lblOdjBlobPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOdjBlobPath.AutoSize = true;
            this.lblOdjBlobPath.Location = new System.Drawing.Point(3, 248);
            this.lblOdjBlobPath.Name = "lblOdjBlobPath";
            this.lblOdjBlobPath.Size = new System.Drawing.Size(77, 13);
            this.lblOdjBlobPath.TabIndex = 19;
            this.lblOdjBlobPath.Text = "ODJ Blob Path";
            // 
            // txtOdjBlobPath
            // 
            this.txtOdjBlobPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOdjBlobPath.Location = new System.Drawing.Point(193, 245);
            this.txtOdjBlobPath.Name = "txtOdjBlobPath";
            this.txtOdjBlobPath.Size = new System.Drawing.Size(412, 20);
            this.txtOdjBlobPath.TabIndex = 20;
            // 
            // btnBrowseOdj
            // 
            this.btnBrowseOdj.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBrowseOdj.Location = new System.Drawing.Point(611, 243);
            this.btnBrowseOdj.Name = "btnBrowseOdj";
            this.btnBrowseOdj.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseOdj.TabIndex = 21;
            this.btnBrowseOdj.Text = "Browse...";
            this.btnBrowseOdj.UseVisualStyleBackColor = true;
            this.btnBrowseOdj.Click += new System.EventHandler(this.BtnBrowseOdj_Click);
            // 
            // chkStaticIp
            // 
            this.chkStaticIp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkStaticIp.AutoSize = true;
            this.chkStaticIp.Location = new System.Drawing.Point(3, 274);
            this.chkStaticIp.Name = "chkStaticIp";
            this.chkStaticIp.Size = new System.Drawing.Size(114, 17);
            this.chkStaticIp.TabIndex = 25;
            this.chkStaticIp.Text = "Use Static IP (opt)";
            this.chkStaticIp.UseVisualStyleBackColor = true;
            this.chkStaticIp.CheckedChanged += new System.EventHandler(this.ChkStaticIp_CheckedChanged);
            // 
            // lblStaticIp
            // 
            this.lblStaticIp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStaticIp.AutoSize = true;
            this.lblStaticIp.Location = new System.Drawing.Point(3, 308);
            this.lblStaticIp.Name = "lblStaticIp";
            this.lblStaticIp.Size = new System.Drawing.Size(91, 13);
            this.lblStaticIp.TabIndex = 26;
            this.lblStaticIp.Text = "Static IP Address";
            // 
            // txtStaticIp
            // 
            this.txtStaticIp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStaticIp.Location = new System.Drawing.Point(193, 305);
            this.txtStaticIp.Name = "txtStaticIp";
            this.txtStaticIp.Size = new System.Drawing.Size(412, 20);
            this.txtStaticIp.TabIndex = 27;
            // 
            // lblStaticSubnet
            // 
            this.lblStaticSubnet.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStaticSubnet.AutoSize = true;
            this.lblStaticSubnet.Location = new System.Drawing.Point(3, 338);
            this.lblStaticSubnet.Name = "lblStaticSubnet";
            this.lblStaticSubnet.Size = new System.Drawing.Size(94, 13);
            this.lblStaticSubnet.TabIndex = 28;
            this.lblStaticSubnet.Text = "Static Subnet Mask";
            // 
            // txtStaticSubnet
            // 
            this.txtStaticSubnet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStaticSubnet.Location = new System.Drawing.Point(193, 335);
            this.txtStaticSubnet.Name = "txtStaticSubnet";
            this.txtStaticSubnet.Size = new System.Drawing.Size(412, 20);
            this.txtStaticSubnet.TabIndex = 29;
            // 
            // lblStaticGateway
            // 
            this.lblStaticGateway.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStaticGateway.AutoSize = true;
            this.lblStaticGateway.Location = new System.Drawing.Point(3, 368);
            this.lblStaticGateway.Name = "lblStaticGateway";
            this.lblStaticGateway.Size = new System.Drawing.Size(85, 13);
            this.lblStaticGateway.TabIndex = 30;
            this.lblStaticGateway.Text = "Static Gateway";
            // 
            // txtStaticGateway
            // 
            this.txtStaticGateway.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStaticGateway.Location = new System.Drawing.Point(193, 365);
            this.txtStaticGateway.Name = "txtStaticGateway";
            this.txtStaticGateway.Size = new System.Drawing.Size(412, 20);
            this.txtStaticGateway.TabIndex = 31;
            // 
            // lblStaticDns
            // 
            this.lblStaticDns.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStaticDns.AutoSize = true;
            this.lblStaticDns.Location = new System.Drawing.Point(3, 398);
            this.lblStaticDns.Name = "lblStaticDns";
            this.lblStaticDns.Size = new System.Drawing.Size(118, 13);
            this.lblStaticDns.TabIndex = 32;
            this.lblStaticDns.Text = "Static DNS (comma list)";
            // 
            // txtStaticDns
            // 
            this.txtStaticDns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStaticDns.Location = new System.Drawing.Point(193, 395);
            this.txtStaticDns.Name = "txtStaticDns";
            this.txtStaticDns.Size = new System.Drawing.Size(412, 20);
            this.txtStaticDns.TabIndex = 33;
            // 
            // lblSavePath
            // 
            this.lblSavePath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSavePath.AutoSize = true;
            this.lblSavePath.Location = new System.Drawing.Point(3, 428);
            this.lblSavePath.Name = "lblSavePath";
            this.lblSavePath.Size = new System.Drawing.Size(80, 13);
            this.lblSavePath.TabIndex = 22;
            this.lblSavePath.Text = "Config Save To";
            // 
            // txtSavePath
            // 
            this.txtSavePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSavePath.Location = new System.Drawing.Point(193, 425);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(412, 20);
            this.txtSavePath.TabIndex = 23;
            // 
            // btnBrowseSave
            // 
            this.btnBrowseSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBrowseSave.Location = new System.Drawing.Point(611, 423);
            this.btnBrowseSave.Name = "btnBrowseSave";
            this.btnBrowseSave.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseSave.TabIndex = 24;
            this.btnBrowseSave.Text = "Browse...";
            this.btnBrowseSave.UseVisualStyleBackColor = true;
            this.btnBrowseSave.Click += new System.EventHandler(this.BtnBrowseSave_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButtons.Controls.Add(this.btnStartDeployment);
            this.panelButtons.Controls.Add(this.btnSaveConfig);
            this.panelButtons.Location = new System.Drawing.Point(12, 474);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(760, 40);
            this.panelButtons.TabIndex = 1;
            // 
            // btnStartDeployment
            // 
            this.btnStartDeployment.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnStartDeployment.Location = new System.Drawing.Point(623, 9);
            this.btnStartDeployment.Name = "btnStartDeployment";
            this.btnStartDeployment.Size = new System.Drawing.Size(134, 23);
            this.btnStartDeployment.TabIndex = 1;
            this.btnStartDeployment.Text = "Start Deployment";
            this.btnStartDeployment.UseVisualStyleBackColor = true;
            this.btnStartDeployment.Click += new System.EventHandler(this.BtnStartDeployment_Click);
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSaveConfig.Location = new System.Drawing.Point(3, 9);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(134, 23);
            this.btnSaveConfig.TabIndex = 0;
            this.btnSaveConfig.Text = "Save Configuration";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.BtnSaveConfig_Click);
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(12, 520);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(760, 129);
            this.txtLog.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Automated Deployment and Servicing (ADS)";
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImageIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetDisk)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
