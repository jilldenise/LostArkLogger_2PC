using LostArkLogger.Utilities;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace LostArkLogger
{
    public partial class MainWindow : Form//, INotifyPropertyChanged
    {
        Parser sniffer;
        Overlay overlay;
        HttpBridge httpBridge;
        private int _packetCount;
        string[] startArgs;
        bool isFirstPC = Program.VersionCompatibility();
        System.Collections.Generic.List<int> ints = new System.Collections.Generic.List<int>();//check first access 

        //public event PropertyChangedEventHandler PropertyChanged;

        public string PacketCount
        {
            get { return "Packets: " + _packetCount; }
        }

        public MainWindow(string[] args)
        {
            startArgs = args;
            InitializeComponent();
            Oodle.Init();
            if (!Directory.Exists("logs")) Directory.CreateDirectory("logs");
            regionSelector.DataSource = Enum.GetValues(typeof(Region));
            regionSelector.SelectedItem = Properties.Settings.Default.Region;
            regionSelector.SelectedIndexChanged += new EventHandler(regionSelector_SelectedIndexChanged);
            loggedPacketCountLabel.Text = "Packets: 0";
            //loggedPacketCountLabel.DataBindings.Add("Text", this, nameof(PacketCount));
            displayName.Checked = Properties.Settings.Default.DisplayNames;
            is2PC.Checked = Properties.Settings.Default.Npcap;
            displayName.CheckedChanged += new EventHandler(displayName_CheckedChanged);
            //sniffModeCheckbox.Checked = Properties.Settings.Default.Npcap;
            this.FormClosed += new FormClosedEventHandler(form_CloseAll);
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                nicListBox.Items.Add(nic.Name);
            }

            if (args != null && args.Length != 0)
            {
                this.Text = "CONSOLE MODE";
                hideControl(debugLog);
                hideControl(addBgColor);
                hideControl(cboxEnableLogger);
                hideControl(lblSetBGColor);
                hideControl(cb_saveOverlayInfo);
                hideControl(radioButton1);
                hideControl(radioButton2);
                hideControl(radioButton3);
                hideControl(cbox_lockNic);
                hideControl(button1);
                hideControl(button2);
                if (Properties.Settings.Default.LockedNICname.Length == 0 && Properties.Settings.Default.LockedRegionName.Length == 0)
                {
                    DialogResult res = MessageBox.Show("Select nic and region to link with loa detail.\n\n"+
                        "\n* You can disable console mode(loa-details link) with 'Cancel' button."+
                        "\n* If disabled, NIC&Region Lock can be set. Once set, it also applied when console mode."+
                        "\n* if you wants to use NIC&Region lock at loa-details, check checkbox and close dps meter and restart loa-details.", "information", MessageBoxButtons.OKCancel);
                    if (res == DialogResult.Cancel)
                    {
                        startArgs = null;
                        this.Text = "2PC";
                    }
                }
            } else
            {
                if (Properties.Settings.Default.LogEnabled == true)
                {
                    isFirstAccess(2);//enable logger notify check = 2
                    settingSync(Properties.Settings.Default.LogEnabled, cboxEnableLogger);
                }
            }
            if (isFirstPC == true)
            {
                (var region, var installedVersion) = VersionCheck.GetLostArkVersion();
                Properties.Settings.Default.Region = region;
                Properties.Settings.Default.Save();
                regionSelector.SelectedItem = NetworkUtil.GetAdapter("LostArk", NetworkUtil.ReqType.ProcessName).Name;
            } else if (isFirstPC == false && 
                Properties.Settings.Default.LockedNICname.Length > 0 &&
                Properties.Settings.Default.LockedRegionName.Length > 0)
            {
                regionSelector.SelectedItem = Properties.Settings.Default.LockedRegionName;
                nicListBox.SelectedItem = Properties.Settings.Default.LockedNICname;
                settingSync(true, cbox_lockNic);
            }
        }

        private bool isFirstAccess(int id)
        {
            if (ints.Contains(id))
            {
                return false;//not first
            } else
            {
                ints.Add(id);
                return true;//first
            }
        }
        private void settingSyncRadio(int n, RadioButton[] radios)
        {
            try
            {
                radios[n].Select();
            } catch (Exception) { } 
        }
        private void settingSync(bool isChecked, CheckBox target)
        {
            target.Checked = isChecked;
        }
        private void showControl(Control control)
        {
            control.Visible = true;
            control.Enabled = true;
        }
        private void hideControl(Control control)
        {
            control.Enabled = false;
            control.Visible = false;
        }
        private void form_CloseAll(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void weblink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/shalzuth/LostArkLogger");
        }

        private void debugLog_CheckedChanged(object sender, EventArgs e)
        {
            Logger.debugLog = debugLog.Checked;
        }

        private void regionSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isFirstAccess(1) == true) { return; }//A unique number for that function(1).
            Properties.Settings.Default.Region = (Region)Enum.Parse(typeof(Region), regionSelector.Text);
            Properties.Settings.Default.Save();
        }

        private void displayName_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DisplayNames = displayName.Checked;
            Properties.Settings.Default.Save();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            loggedPacketCountLabel.Text = PacketCount;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.OverlayPos_Right == true)
            {
                this.Location = new System.Drawing.Point(0, 0);
            } else
            {
                this.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width - this.Width, 0);
            }
        }

        private void nicListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeParser(nicListBox.SelectedItem.ToString());
        }

        private void addBgColor_CheckedChanged(object sender, EventArgs e)
        {
            overlay.addBGColor = addBgColor.Checked;
        }

        private void cbox_lockNic_CheckedChanged(object sender, EventArgs e)
        {
            if (cbox_lockNic.Checked == true && nicListBox.SelectedItem != null)
            {
                Properties.Settings.Default.LockedNICname = nicListBox.SelectedItem.ToString();
                Properties.Settings.Default.LockedRegionName = regionSelector.SelectedItem.ToString();
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.LockedNICname = "";
                Properties.Settings.Default.LockedRegionName = "";
                Properties.Settings.Default.Save();
            }
        }

        private void lblSetBGColor_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;
            MyDialog.Color = lblSetBGColor.ForeColor;
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                lblSetBGColor.ForeColor = MyDialog.Color;
                Properties.Settings.Default.BackgroundColor = MyDialog.Color;
                overlay.bgColor = new System.Drawing.SolidBrush(MyDialog.Color);
                overlay.updateUI();
                Properties.Settings.Default.Save();
            }
        }

        private void cboxEnableLogger_CheckedChanged(object sender, EventArgs e)
        {
            if (isFirstAccess(2) == true)
            {//A unique number for that function(2).
                switch (Properties.Settings.Default.Region)
                {
                    case LostArkLogger.Region.Korea:
                        MessageBox.Show("해당 기능은 Loa details용으로 로그를 생성하는 기능입니다.\n로그 생성 시 나중에 Loa Details로 전투 기록을 확인할 수 있습니다.");
                        break;
                    case LostArkLogger.Region.Steam:
                        MessageBox.Show("Generates logs that are compatible with Loa-details,\nyou can check combat history with Loa-details later.");
                        break;
                }
            }
            Properties.Settings.Default.LogEnabled = cboxEnableLogger.Checked;
            Properties.Settings.Default.Save();
        }

        private void versionLabel_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.OverlayPos_Right == true)
            {
                this.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width - this.Width, 0);
                overlay.Location = new System.Drawing.Point(0, 0);
                Properties.Settings.Default.OverlayPos_Right = false;
            } else
            {
                this.Location = new System.Drawing.Point(0, 0);
                overlay.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width / 2, 0);
                Properties.Settings.Default.OverlayPos_Right = true;
            }
            Properties.Settings.Default.Save();
        }

        private void cb_saveOverlayInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_saveOverlayInfo.Checked == true)
            {
                Properties.Settings.Default.OverlayStartInfo = overlay.Width.ToString() + "|" + overlay.Height.ToString() + "|" + overlay.Left.ToString() + "|" + overlay.Top.ToString();
            } else
            {
                Properties.Settings.Default.OverlayStartInfo = "";
            }
            Properties.Settings.Default.Save();
        }

        private void rb_changed(int selected)
        {
            Properties.Settings.Default.ElapsedTimeType = selected;//0:default 1:entity 2:dmgpacket
            Properties.Settings.Default.Save();
            sniffer.eTimeType = Properties.Settings.Default.ElapsedTimeType;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            rb_changed(0);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            rb_changed(1);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            rb_changed(2);
        }

        LostArkLogger.GUI.LoaDetailsPatcher loaDetailsPatcher;
        private void button2_Click(object sender, EventArgs e)
        {
            loaDetailsPatcher = new GUI.LoaDetailsPatcher();
            loaDetailsPatcher.Show();
            loaDetailsPatcher.showNotice();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void is2PC_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Npcap = is2PC.Checked;
            Properties.Settings.Default.Save();

            if (Properties.Settings.Default.Npcap == true)
            {

                if (Properties.Settings.Default.LockedNICname.Length > 0 &&
                    Properties.Settings.Default.LockedRegionName.Length > 0)
                {
                    regionSelector.SelectedItem = Properties.Settings.Default.LockedRegionName;
                    nicListBox.SelectedItem = Properties.Settings.Default.LockedNICname;
                    settingSync(true, cbox_lockNic);
                    InitializeParser(nicListBox.SelectedItem.ToString());
                }
                else
                {
                    showControl(regionSelector);
                    showControl(nicListBox);
                    hideControl(cbox_lockNic);
                    regionSelector.SelectedItem = Properties.Settings.Default.LockedRegionName;
                    nicListBox.SelectedItem = Properties.Settings.Default.LockedNICname;
                }
            }
            else
            {
                hideControl(cbox_lockNic);
                (var region, var installedVersion) = VersionCheck.GetLostArkVersion();
                if (installedVersion == null)
                {
                    Properties.Settings.Default.Npcap = true;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Launch Lost Ark before launching logger if you want DPS meter to work.", "Lost Ark Not Running", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Environment.Exit(10);
                }
                else
                {
                    InitializeParser("none");
                }
                
            }

        }

        private void InitializeParser(string nicName)
        {
            hideControl(nicListBox);
            hideControl(regionSelector);
            if (startArgs != null && startArgs.Length != 0)
            {
                this.Visible = false;
                httpBridge = new HttpBridge();
                httpBridge.args = startArgs;
                httpBridge.Start(nicName);
            }
            else
            {
                sniffer = new Parser();
                sniffer.isFirstPC = isFirstPC;
                sniffer.onPacketTotalCount += (int totalPacketCount) =>
                {
                    _packetCount = totalPacketCount;
                };
                overlay = new Overlay();
                overlay.Show();
                string[] overlayStartinfo = Properties.Settings.Default.OverlayStartInfo.Split('|');
                bool overlayErr = false;
                try
                {
                    if (overlayStartinfo?.Length == 4)
                    {
                        overlay.Location = new System.Drawing.Point(int.Parse(overlayStartinfo[2]), int.Parse(overlayStartinfo[3]));
                        overlay.Size = new System.Drawing.Size(int.Parse(overlayStartinfo[0]), int.Parse(overlayStartinfo[1]));
                        cb_saveOverlayInfo.Checked = true;
                    }
                    else
                    {
                        Properties.Settings.Default.OverlayStartInfo = "";
                        Properties.Settings.Default.Save();
                        overlayErr = true;
                    }
                }
                catch (Exception) { overlayErr = true; }

                if (overlayErr == true)
                {
                    if (Properties.Settings.Default.OverlayPos_Right == true)
                    {
                        overlay.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width / 2, 0);
                    }
                    else
                    {
                        overlay.Location = new System.Drawing.Point(0, 0);
                    }
                    overlay.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height);
                }
                sniffer.use_npcap = Properties.Settings.Default.Npcap;
                sniffer.startParse(nicName);
                overlay.AddSniffer(sniffer);
                overlay.getHP = sniffer.getLatestEntityHPInfo;
                overlay.getElapsedTime = sniffer.getLatestEntityElapsedTime;

                showControl(addBgColor);
                if (Properties.Settings.Default.Npcap == true)
                {
                    cbox_lockNic.Text = "Use Current NIC/Region setting\n(" + regionSelector.SelectedItem.ToString() + " / " + nicListBox.SelectedItem.ToString() + ")";
                    showControl(cbox_lockNic);
                }
                
                lblSetBGColor.ForeColor = Properties.Settings.Default.BackgroundColor;
                showControl(lblSetBGColor);
                showControl(cb_saveOverlayInfo);
                settingSyncRadio(Properties.Settings.Default.ElapsedTimeType, new RadioButton[] { radioButton1, radioButton2, radioButton3 });
                showControl(radioButton1);
                showControl(radioButton2);
                showControl(radioButton3);
                settingSync(Properties.Settings.Default.LogEnabled, cboxEnableLogger);
                showControl(cboxEnableLogger);
                showControl(versionLabel);
                showControl(debugLog);//when disable console mode
                showControl(button1);//same
                showControl(button2);//same
                timer1.Enabled = true;
            }
        }
    }
}
