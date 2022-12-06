namespace LostArkLogger
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.loggedPacketCountLabel = new System.Windows.Forms.Label();
            this.weblink = new System.Windows.Forms.LinkLabel();
            this.debugLog = new System.Windows.Forms.CheckBox();
            this.versionLabel = new System.Windows.Forms.Label();
            this.regionSelector = new System.Windows.Forms.ComboBox();
            this.displayName = new System.Windows.Forms.CheckBox();
            this.nicListBox = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.addBgColor = new System.Windows.Forms.CheckBox();
            this.lblSetBGColor = new System.Windows.Forms.Label();
            this.cbox_lockNic = new System.Windows.Forms.CheckBox();
            this.cboxEnableLogger = new System.Windows.Forms.CheckBox();
            this.cb_saveOverlayInfo = new System.Windows.Forms.CheckBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loggedPacketCountLabel
            // 
            this.loggedPacketCountLabel.Location = new System.Drawing.Point(11, 11);
            this.loggedPacketCountLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.loggedPacketCountLabel.Name = "loggedPacketCountLabel";
            this.loggedPacketCountLabel.Size = new System.Drawing.Size(203, 15);
            this.loggedPacketCountLabel.TabIndex = 2;
            this.loggedPacketCountLabel.Text = "Packets: 0";
            // 
            // weblink
            // 
            this.weblink.Location = new System.Drawing.Point(241, 11);
            this.weblink.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.weblink.Name = "weblink";
            this.weblink.Size = new System.Drawing.Size(93, 15);
            this.weblink.TabIndex = 4;
            this.weblink.TabStop = true;
            this.weblink.Text = "by shalzuth";
            this.weblink.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.weblink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.weblink_LinkClicked);
            // 
            // debugLog
            // 
            this.debugLog.Location = new System.Drawing.Point(14, 30);
            this.debugLog.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.debugLog.Name = "debugLog";
            this.debugLog.Size = new System.Drawing.Size(222, 20);
            this.debugLog.TabIndex = 9;
            this.debugLog.Text = "Write Debug Log File";
            this.debugLog.UseVisualStyleBackColor = true;
            this.debugLog.CheckedChanged += new System.EventHandler(this.debugLog_CheckedChanged);
            // 
            // versionLabel
            // 
            this.versionLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.versionLabel.Enabled = false;
            this.versionLabel.Location = new System.Drawing.Point(245, 26);
            this.versionLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(89, 49);
            this.versionLabel.TabIndex = 10;
            this.versionLabel.Text = "2022.12.01";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.versionLabel.Click += new System.EventHandler(this.versionLabel_Click);
            // 
            // regionSelector
            // 
            this.regionSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.regionSelector.FormattingEnabled = true;
            this.regionSelector.Location = new System.Drawing.Point(242, 170);
            this.regionSelector.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.regionSelector.Name = "regionSelector";
            this.regionSelector.Size = new System.Drawing.Size(91, 23);
            this.regionSelector.TabIndex = 12;
            this.regionSelector.SelectedIndexChanged += new System.EventHandler(this.regionSelector_SelectedIndexChanged);
            // 
            // displayName
            // 
            this.displayName.Checked = true;
            this.displayName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayName.Location = new System.Drawing.Point(14, 115);
            this.displayName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.displayName.Name = "displayName";
            this.displayName.Size = new System.Drawing.Size(194, 20);
            this.displayName.TabIndex = 14;
            this.displayName.Text = "Show player Names";
            this.displayName.UseVisualStyleBackColor = true;
            // 
            // nicListBox
            // 
            this.nicListBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nicListBox.FormattingEnabled = true;
            this.nicListBox.Location = new System.Drawing.Point(14, 170);
            this.nicListBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.nicListBox.Name = "nicListBox";
            this.nicListBox.Size = new System.Drawing.Size(219, 23);
            this.nicListBox.TabIndex = 15;
            this.nicListBox.SelectedIndexChanged += new System.EventHandler(this.nicListBox_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // addBgColor
            // 
            this.addBgColor.Checked = true;
            this.addBgColor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.addBgColor.Enabled = false;
            this.addBgColor.Location = new System.Drawing.Point(14, 88);
            this.addBgColor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addBgColor.Name = "addBgColor";
            this.addBgColor.Size = new System.Drawing.Size(194, 20);
            this.addBgColor.TabIndex = 17;
            this.addBgColor.Text = "add Background Color";
            this.addBgColor.UseVisualStyleBackColor = true;
            this.addBgColor.CheckedChanged += new System.EventHandler(this.addBgColor_CheckedChanged);
            // 
            // lblSetBGColor
            // 
            this.lblSetBGColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetBGColor.Enabled = false;
            this.lblSetBGColor.Location = new System.Drawing.Point(234, 86);
            this.lblSetBGColor.Name = "lblSetBGColor";
            this.lblSetBGColor.Size = new System.Drawing.Size(99, 20);
            this.lblSetBGColor.TabIndex = 18;
            this.lblSetBGColor.Text = "(Color)";
            this.lblSetBGColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSetBGColor.Click += new System.EventHandler(this.lblSetBGColor_Click);
            // 
            // cbox_lockNic
            // 
            this.cbox_lockNic.Enabled = false;
            this.cbox_lockNic.Location = new System.Drawing.Point(14, 170);
            this.cbox_lockNic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbox_lockNic.Name = "cbox_lockNic";
            this.cbox_lockNic.Size = new System.Drawing.Size(322, 40);
            this.cbox_lockNic.TabIndex = 19;
            this.cbox_lockNic.Text = "Use Current NIC/Region setting\r\n(region / nic name..)";
            this.cbox_lockNic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbox_lockNic.UseVisualStyleBackColor = true;
            this.cbox_lockNic.Visible = false;
            this.cbox_lockNic.CheckedChanged += new System.EventHandler(this.cbox_lockNic_CheckedChanged);
            // 
            // cboxEnableLogger
            // 
            this.cboxEnableLogger.Enabled = false;
            this.cboxEnableLogger.Location = new System.Drawing.Point(14, 60);
            this.cboxEnableLogger.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboxEnableLogger.Name = "cboxEnableLogger";
            this.cboxEnableLogger.Size = new System.Drawing.Size(222, 20);
            this.cboxEnableLogger.TabIndex = 20;
            this.cboxEnableLogger.Text = "Write Log File";
            this.cboxEnableLogger.UseVisualStyleBackColor = true;
            this.cboxEnableLogger.CheckedChanged += new System.EventHandler(this.cboxEnableLogger_CheckedChanged);
            // 
            // cb_saveOverlayInfo
            // 
            this.cb_saveOverlayInfo.Enabled = false;
            this.cb_saveOverlayInfo.Location = new System.Drawing.Point(14, 142);
            this.cb_saveOverlayInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cb_saveOverlayInfo.Name = "cb_saveOverlayInfo";
            this.cb_saveOverlayInfo.Size = new System.Drawing.Size(322, 20);
            this.cb_saveOverlayInfo.TabIndex = 21;
            this.cb_saveOverlayInfo.Text = "Save current overlay pos/size";
            this.cb_saveOverlayInfo.UseVisualStyleBackColor = true;
            this.cb_saveOverlayInfo.CheckedChanged += new System.EventHandler(this.cb_saveOverlayInfo_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(14, 218);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(191, 19);
            this.radioButton1.TabIndex = 23;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "use Default Elapsed Time";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(14, 245);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(226, 19);
            this.radioButton2.TabIndex = 24;
            this.radioButton2.Text = "use Entity-based Elapsed time";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(14, 272);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(317, 19);
            this.radioButton3.TabIndex = 25;
            this.radioButton3.Text = "use NPCDamagePacket-based Elapsed time";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(14, 300);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 29);
            this.button1.TabIndex = 26;
            this.button1.Text = "settings(i\'ll add later)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(187, 300);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 29);
            this.button2.TabIndex = 27;
            this.button2.Text = "loa-details patcher";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 336);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.cb_saveOverlayInfo);
            this.Controls.Add(this.cboxEnableLogger);
            this.Controls.Add(this.cbox_lockNic);
            this.Controls.Add(this.lblSetBGColor);
            this.Controls.Add(this.addBgColor);
            this.Controls.Add(this.nicListBox);
            this.Controls.Add(this.displayName);
            this.Controls.Add(this.regionSelector);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.debugLog);
            this.Controls.Add(this.weblink);
            this.Controls.Add(this.loggedPacketCountLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "2PC";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label loggedPacketCountLabel;
        private System.Windows.Forms.LinkLabel weblink;
        private System.Windows.Forms.CheckBox debugLog;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.ComboBox regionSelector;
        private System.Windows.Forms.CheckBox displayName;
        private System.Windows.Forms.ComboBox nicListBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox addBgColor;
        private System.Windows.Forms.Label lblSetBGColor;
        private System.Windows.Forms.CheckBox cbox_lockNic;
        private System.Windows.Forms.CheckBox cboxEnableLogger;
        private System.Windows.Forms.CheckBox cb_saveOverlayInfo;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
