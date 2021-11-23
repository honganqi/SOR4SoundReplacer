
namespace SOR4SoundReplacer
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.btnExtract = new System.Windows.Forms.Button();
            this.btnBrowseSource = new System.Windows.Forms.Button();
            this.txtGameDir = new System.Windows.Forms.Label();
            this.btnBrowseDestination = new System.Windows.Forms.Button();
            this.txtExtractDir = new System.Windows.Forms.Label();
            this.btnRepack = new System.Windows.Forms.Button();
            this.labelBackups = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.radioOverwrite = new System.Windows.Forms.RadioButton();
            this.radioSeparate = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelDestFolderMissing = new System.Windows.Forms.Label();
            this.btnToggleCommandLog = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.imgSF = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.imgTwitch = new System.Windows.Forms.PictureBox();
            this.imgYoutube = new System.Windows.Forms.PictureBox();
            this.imgBMCSupport = new System.Windows.Forms.PictureBox();
            this.labelSupport = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExtractCore = new System.Windows.Forms.Button();
            this.btnExtractGeneric = new System.Windows.Forms.Button();
            this.btnRepackCore = new System.Windows.Forms.Button();
            this.btnRepackGeneric = new System.Windows.Forms.Button();
            this.progressCore = new System.Windows.Forms.ProgressBar();
            this.progressGeneric = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgSF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTwitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgYoutube)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBMCSupport)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExtract
            // 
            this.btnExtract.AutoSize = true;
            this.btnExtract.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtract.Location = new System.Drawing.Point(124, 311);
            this.btnExtract.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(67, 35);
            this.btnExtract.TabIndex = 3;
            this.btnExtract.Text = "Extract";
            this.btnExtract.UseVisualStyleBackColor = true;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // btnBrowseSource
            // 
            this.btnBrowseSource.AutoSize = true;
            this.btnBrowseSource.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseSource.Location = new System.Drawing.Point(18, 53);
            this.btnBrowseSource.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBrowseSource.Name = "btnBrowseSource";
            this.btnBrowseSource.Size = new System.Drawing.Size(124, 35);
            this.btnBrowseSource.TabIndex = 1;
            this.btnBrowseSource.Text = "BNK Folder";
            this.btnBrowseSource.UseVisualStyleBackColor = true;
            this.btnBrowseSource.Click += new System.EventHandler(this.btnBrowseSource_Click);
            // 
            // txtGameDir
            // 
            this.txtGameDir.AutoSize = true;
            this.txtGameDir.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGameDir.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtGameDir.Location = new System.Drawing.Point(17, 90);
            this.txtGameDir.Name = "txtGameDir";
            this.txtGameDir.Size = new System.Drawing.Size(251, 13);
            this.txtGameDir.TabIndex = 3;
            this.txtGameDir.Text = "location of your Core.bnk and Generic.bnk files";
            this.txtGameDir.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtGameDir_MouseDown);
            this.txtGameDir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txtGameDir_MouseMove);
            // 
            // btnBrowseDestination
            // 
            this.btnBrowseDestination.AutoSize = true;
            this.btnBrowseDestination.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseDestination.Location = new System.Drawing.Point(18, 126);
            this.btnBrowseDestination.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBrowseDestination.Name = "btnBrowseDestination";
            this.btnBrowseDestination.Size = new System.Drawing.Size(124, 35);
            this.btnBrowseDestination.TabIndex = 2;
            this.btnBrowseDestination.Text = "Destination Folder";
            this.btnBrowseDestination.UseVisualStyleBackColor = true;
            this.btnBrowseDestination.Click += new System.EventHandler(this.btnBrowseDestination_Click);
            // 
            // txtExtractDir
            // 
            this.txtExtractDir.AutoSize = true;
            this.txtExtractDir.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExtractDir.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtExtractDir.Location = new System.Drawing.Point(17, 164);
            this.txtExtractDir.Name = "txtExtractDir";
            this.txtExtractDir.Size = new System.Drawing.Size(304, 13);
            this.txtExtractDir.TabIndex = 7;
            this.txtExtractDir.Text = "the folder where the WEM sound files will be extracted to";
            this.txtExtractDir.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtExtractDir_MouseDown);
            this.txtExtractDir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txtExtractDir_MouseMove);
            // 
            // btnRepack
            // 
            this.btnRepack.AutoSize = true;
            this.btnRepack.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRepack.Location = new System.Drawing.Point(197, 311);
            this.btnRepack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRepack.Name = "btnRepack";
            this.btnRepack.Size = new System.Drawing.Size(67, 35);
            this.btnRepack.TabIndex = 4;
            this.btnRepack.Text = "Repack";
            this.btnRepack.UseVisualStyleBackColor = true;
            this.btnRepack.Click += new System.EventHandler(this.btnRepack_Click);
            // 
            // labelBackups
            // 
            this.labelBackups.AutoSize = true;
            this.labelBackups.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBackups.Location = new System.Drawing.Point(148, 64);
            this.labelBackups.Name = "labelBackups";
            this.labelBackups.Size = new System.Drawing.Size(301, 13);
            this.labelBackups.TabIndex = 10;
            this.labelBackups.Text = "Backups of Core.bnk and Generic.bnk have been created.";
            this.labelBackups.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelBackups_MouseDown);
            this.labelBackups.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelBackups_MouseMove);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 459);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(505, 28);
            this.label4.TabIndex = 11;
            this.label4.Text = "EXTRACT: WEM files will be extracted into folders named \"Core\" and \"Generic\" in t" +
    "he indicated destination folder. This folder will not use more than 100 MB.";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 496);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(505, 27);
            this.label5.TabIndex = 12;
            this.label5.Text = "REPACK: All the WEM files from the \"Core\" and \"Generic\" folders in the indicated " +
    "\"Destination\" folder will be repacked into.";
            // 
            // radioOverwrite
            // 
            this.radioOverwrite.AutoSize = true;
            this.radioOverwrite.Location = new System.Drawing.Point(17, 403);
            this.radioOverwrite.Name = "radioOverwrite";
            this.radioOverwrite.Size = new System.Drawing.Size(253, 21);
            this.radioOverwrite.TabIndex = 6;
            this.radioOverwrite.TabStop = true;
            this.radioOverwrite.Text = "Overwrite BNK files in the Game Folder";
            this.radioOverwrite.UseVisualStyleBackColor = true;
            this.radioOverwrite.CheckedChanged += new System.EventHandler(this.radioOverwrite_CheckedChanged);
            // 
            // radioSeparate
            // 
            this.radioSeparate.AutoSize = true;
            this.radioSeparate.Checked = true;
            this.radioSeparate.Location = new System.Drawing.Point(17, 380);
            this.radioSeparate.Name = "radioSeparate";
            this.radioSeparate.Size = new System.Drawing.Size(319, 21);
            this.radioSeparate.TabIndex = 5;
            this.radioSeparate.TabStop = true;
            this.radioSeparate.Text = "Create separate BNK files in the Destination folder";
            this.radioSeparate.UseVisualStyleBackColor = true;
            this.radioSeparate.CheckedChanged += new System.EventHandler(this.radioSeparate_CheckedChanged);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(17, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(505, 2);
            this.label3.TabIndex = 15;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(359, 516);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(143, 23);
            this.progressBar.TabIndex = 17;
            this.progressBar.Visible = false;
            this.progressBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.progressBar_MouseDown);
            this.progressBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.progressBar_MouseMove);
            // 
            // labelDestFolderMissing
            // 
            this.labelDestFolderMissing.AutoSize = true;
            this.labelDestFolderMissing.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDestFolderMissing.ForeColor = System.Drawing.Color.Crimson;
            this.labelDestFolderMissing.Location = new System.Drawing.Point(148, 138);
            this.labelDestFolderMissing.Name = "labelDestFolderMissing";
            this.labelDestFolderMissing.Size = new System.Drawing.Size(182, 13);
            this.labelDestFolderMissing.TabIndex = 18;
            this.labelDestFolderMissing.Text = "Please set your destination folder.";
            this.labelDestFolderMissing.Visible = false;
            this.labelDestFolderMissing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelDestFolderMissing_MouseDown);
            this.labelDestFolderMissing.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelDestFolderMissing_MouseMove);
            // 
            // btnToggleCommandLog
            // 
            this.btnToggleCommandLog.AutoSize = true;
            this.btnToggleCommandLog.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToggleCommandLog.Location = new System.Drawing.Point(413, 401);
            this.btnToggleCommandLog.Name = "btnToggleCommandLog";
            this.btnToggleCommandLog.Size = new System.Drawing.Size(109, 23);
            this.btnToggleCommandLog.TabIndex = 19;
            this.btnToggleCommandLog.Text = "Show Output Log";
            this.btnToggleCommandLog.UseVisualStyleBackColor = true;
            this.btnToggleCommandLog.Visible = false;
            this.btnToggleCommandLog.Click += new System.EventHandler(this.btnToggleCommandLog_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.Black;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(466, 0);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(36, 36);
            this.btnMinimize.TabIndex = 42;
            this.btnMinimize.Text = "̶̶";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Black;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(502, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 36);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.DimGray;
            this.panelTop.Controls.Add(this.labelVersion);
            this.panelTop.Controls.Add(this.labelAuthor);
            this.panelTop.Controls.Add(this.btnMinimize);
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Controls.Add(this.labelTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(538, 36);
            this.panelTop.TabIndex = 45;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseDown);
            this.panelTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseMove);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.ForeColor = System.Drawing.Color.White;
            this.labelVersion.Location = new System.Drawing.Point(203, 13);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(27, 13);
            this.labelVersion.TabIndex = 44;
            this.labelVersion.Text = "v1.0";
            this.labelVersion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelVersion_MouseDown);
            this.labelVersion.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelVersion_MouseMove);
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAuthor.ForeColor = System.Drawing.Color.White;
            this.labelAuthor.Location = new System.Drawing.Point(236, 13);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(73, 13);
            this.labelAuthor.TabIndex = 43;
            this.labelAuthor.Text = "by honganqi";
            this.labelAuthor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelAuthor_MouseDown);
            this.labelAuthor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelAuthor_MouseMove);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(12, 7);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(193, 21);
            this.labelTitle.TabIndex = 41;
            this.labelTitle.Text = "SOR4 SOUND REPLACER";
            this.labelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseDown);
            this.labelTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseMove);
            // 
            // imgSF
            // 
            this.imgSF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgSF.Location = new System.Drawing.Point(427, 571);
            this.imgSF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.imgSF.Name = "imgSF";
            this.imgSF.Size = new System.Drawing.Size(95, 20);
            this.imgSF.TabIndex = 71;
            this.imgSF.TabStop = false;
            this.imgSF.Click += new System.EventHandler(this.imgSF_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(474, 559);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 12);
            this.label8.TabIndex = 74;
            this.label8.Text = "Updates on";
            // 
            // imgTwitch
            // 
            this.imgTwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgTwitch.Location = new System.Drawing.Point(410, 574);
            this.imgTwitch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.imgTwitch.Name = "imgTwitch";
            this.imgTwitch.Size = new System.Drawing.Size(15, 16);
            this.imgTwitch.TabIndex = 73;
            this.imgTwitch.TabStop = false;
            this.imgTwitch.Click += new System.EventHandler(this.imgTwitch_Click);
            // 
            // imgYoutube
            // 
            this.imgYoutube.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgYoutube.Location = new System.Drawing.Point(385, 574);
            this.imgYoutube.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.imgYoutube.Name = "imgYoutube";
            this.imgYoutube.Size = new System.Drawing.Size(23, 16);
            this.imgYoutube.TabIndex = 72;
            this.imgYoutube.TabStop = false;
            this.imgYoutube.Click += new System.EventHandler(this.imgYoutube_Click);
            // 
            // imgBMCSupport
            // 
            this.imgBMCSupport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgBMCSupport.InitialImage = null;
            this.imgBMCSupport.Location = new System.Drawing.Point(17, 548);
            this.imgBMCSupport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.imgBMCSupport.Name = "imgBMCSupport";
            this.imgBMCSupport.Size = new System.Drawing.Size(152, 43);
            this.imgBMCSupport.TabIndex = 69;
            this.imgBMCSupport.TabStop = false;
            this.imgBMCSupport.Click += new System.EventHandler(this.imgBMCSupport_Click);
            // 
            // labelSupport
            // 
            this.labelSupport.AutoSize = true;
            this.labelSupport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSupport.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelSupport.Location = new System.Drawing.Point(15, 539);
            this.labelSupport.Name = "labelSupport";
            this.labelSupport.Size = new System.Drawing.Size(86, 15);
            this.labelSupport.TabIndex = 70;
            this.labelSupport.Text = "Support me on";
            this.labelSupport.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 21);
            this.label1.TabIndex = 81;
            this.label1.Text = "Core.bnk";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 21);
            this.label2.TabIndex = 82;
            this.label2.Text = "Generic.bnk";
            // 
            // btnExtractCore
            // 
            this.btnExtractCore.AutoSize = true;
            this.btnExtractCore.Enabled = false;
            this.btnExtractCore.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtractCore.Location = new System.Drawing.Point(124, 211);
            this.btnExtractCore.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExtractCore.Name = "btnExtractCore";
            this.btnExtractCore.Size = new System.Drawing.Size(67, 35);
            this.btnExtractCore.TabIndex = 83;
            this.btnExtractCore.Text = "Extract";
            this.btnExtractCore.UseVisualStyleBackColor = true;
            this.btnExtractCore.Click += new System.EventHandler(this.btnExtractCore_Click);
            // 
            // btnExtractGeneric
            // 
            this.btnExtractGeneric.AutoSize = true;
            this.btnExtractGeneric.Enabled = false;
            this.btnExtractGeneric.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtractGeneric.Location = new System.Drawing.Point(124, 254);
            this.btnExtractGeneric.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExtractGeneric.Name = "btnExtractGeneric";
            this.btnExtractGeneric.Size = new System.Drawing.Size(67, 35);
            this.btnExtractGeneric.TabIndex = 84;
            this.btnExtractGeneric.Text = "Extract";
            this.btnExtractGeneric.UseVisualStyleBackColor = true;
            this.btnExtractGeneric.Click += new System.EventHandler(this.btnExtractGeneric_Click);
            // 
            // btnRepackCore
            // 
            this.btnRepackCore.AutoSize = true;
            this.btnRepackCore.Enabled = false;
            this.btnRepackCore.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRepackCore.Location = new System.Drawing.Point(197, 211);
            this.btnRepackCore.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRepackCore.Name = "btnRepackCore";
            this.btnRepackCore.Size = new System.Drawing.Size(67, 35);
            this.btnRepackCore.TabIndex = 85;
            this.btnRepackCore.Text = "Repack";
            this.btnRepackCore.UseVisualStyleBackColor = true;
            this.btnRepackCore.Click += new System.EventHandler(this.btnRepackCore_Click);
            // 
            // btnRepackGeneric
            // 
            this.btnRepackGeneric.AutoSize = true;
            this.btnRepackGeneric.Enabled = false;
            this.btnRepackGeneric.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRepackGeneric.Location = new System.Drawing.Point(197, 253);
            this.btnRepackGeneric.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRepackGeneric.Name = "btnRepackGeneric";
            this.btnRepackGeneric.Size = new System.Drawing.Size(67, 35);
            this.btnRepackGeneric.TabIndex = 86;
            this.btnRepackGeneric.Text = "Repack";
            this.btnRepackGeneric.UseVisualStyleBackColor = true;
            this.btnRepackGeneric.Click += new System.EventHandler(this.btnRepackGeneric_Click);
            // 
            // progressCore
            // 
            this.progressCore.Location = new System.Drawing.Point(270, 220);
            this.progressCore.Name = "progressCore";
            this.progressCore.Size = new System.Drawing.Size(252, 17);
            this.progressCore.TabIndex = 87;
            this.progressCore.Visible = false;
            // 
            // progressGeneric
            // 
            this.progressGeneric.Location = new System.Drawing.Point(270, 263);
            this.progressGeneric.Name = "progressGeneric";
            this.progressGeneric.Size = new System.Drawing.Size(252, 17);
            this.progressGeneric.TabIndex = 88;
            this.progressGeneric.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 322);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 15);
            this.label7.TabIndex = 89;
            this.label7.Text = "Both files";
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(18, 365);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(505, 2);
            this.label6.TabIndex = 16;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 605);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.progressGeneric);
            this.Controls.Add(this.progressCore);
            this.Controls.Add(this.btnRepackGeneric);
            this.Controls.Add(this.btnRepackCore);
            this.Controls.Add(this.btnExtractGeneric);
            this.Controls.Add(this.btnExtractCore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imgSF);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.imgTwitch);
            this.Controls.Add(this.imgYoutube);
            this.Controls.Add(this.imgBMCSupport);
            this.Controls.Add(this.labelSupport);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.btnToggleCommandLog);
            this.Controls.Add(this.labelDestFolderMissing);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radioSeparate);
            this.Controls.Add(this.radioOverwrite);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelBackups);
            this.Controls.Add(this.btnRepack);
            this.Controls.Add(this.txtExtractDir);
            this.Controls.Add(this.btnBrowseDestination);
            this.Controls.Add(this.txtGameDir);
            this.Controls.Add(this.btnBrowseSource);
            this.Controls.Add(this.btnExtract);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainWindow";
            this.Text = "SOR4 Sound Replacer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseMove);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgSF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTwitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgYoutube)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBMCSupport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.Button btnBrowseSource;
        private System.Windows.Forms.Label txtGameDir;
        private System.Windows.Forms.Button btnBrowseDestination;
        private System.Windows.Forms.Label txtExtractDir;
        private System.Windows.Forms.Button btnRepack;
        private System.Windows.Forms.Label labelBackups;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioOverwrite;
        private System.Windows.Forms.RadioButton radioSeparate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelDestFolderMissing;
        public System.Windows.Forms.Button btnToggleCommandLog;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelVersion;
        public System.Windows.Forms.PictureBox imgSF;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.PictureBox imgTwitch;
        public System.Windows.Forms.PictureBox imgYoutube;
        public System.Windows.Forms.PictureBox imgBMCSupport;
        public System.Windows.Forms.Label labelSupport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExtractCore;
        private System.Windows.Forms.Button btnExtractGeneric;
        private System.Windows.Forms.Button btnRepackCore;
        private System.Windows.Forms.Button btnRepackGeneric;
        private System.Windows.Forms.ProgressBar progressCore;
        private System.Windows.Forms.ProgressBar progressGeneric;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}

