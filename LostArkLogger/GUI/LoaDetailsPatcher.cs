using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LostArkLogger.GUI
{
    public partial class LoaDetailsPatcher : Form
    {
        bool patchToForkedVersion = true;
        string binaryName = "ae92984b-6f1b-4b0d-ad31-504e1905d5e6.exe";
        string oo2Name = "oo2net_9_win64.dll";
        string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Programs\loa-details\";
        bool needsManualSelection = false;
        public LoaDetailsPatcher()
        {
            InitializeComponent();
            string binaryPath = path + @"binary\";
            DirectoryInfo di = new DirectoryInfo(binaryPath);
            if (di.Exists == false)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Programs\loa-details\";
                di = new DirectoryInfo(path + @"binary\");
                if (di.Exists == false)
                {
                    needsManualSelection = true;
                    path = "NEEDS MANUAL SELECTION";
                }
            }
            lbl_path.Text = path;
        }

        public void showNotice()
        {
            MessageBox.Show("if you're running loa-details, exit loa-details first.\n"+
                "because running process's filename can't be changed. \n\n"+
                "Also, for the same reason, when reverting from the fork version to the original binary,\n"+
                "needs copy and paste this exe for create another file and use it.\n\n" +
                "[** it only works if Loa-details is installed in the default installation path. **]", "Notice");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (needsManualSelection == true) {
                MessageBox.Show("The Loa-details installation path could not be found, so patching is possible only after manually selected.");
                return;
            }
            bool fileFound = false;
            bool originalFileFound = false;
            string binaryPath = path + @"binary\";
            DirectoryInfo di = new DirectoryInfo(binaryPath);
            FileInfo[] files = di.GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Name == binaryName) fileFound = true;
                if (files[i].Name == binaryName + ".original") originalFileFound = true;
            }

            if (patchToForkedVersion == true &&
                MessageBox.Show("Patch Loa-details binary to 2pc forked version?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                bool hasException = false;
                try
                {
                    string curPath = Directory.GetCurrentDirectory()+@"\";
                    FileInfo[] fi = new DirectoryInfo(curPath).GetFiles();
                    bool oo2Found = false;
                    bool meterFound = false;
                    string fname = AppDomain.CurrentDomain.FriendlyName;
                    for (int i = 0; i < fi.Length; i++)
                    {
                        if (fi[i].Name == (AppDomain.CurrentDomain.FriendlyName + ".exe")) meterFound = true;
                        if (fi[i].Name == oo2Name) oo2Found = true;
                    }
                    if (!oo2Found)
                    {
                        MessageBox.Show("don't delete oo2net_9_win64.dll. re-unzip debug.zip and retry.");
                        return;
                    }
                    if (!fileFound)
                    {
                        MessageBox.Show("original file not exist, needs reinstall loa-details");
                        return;
                    }
                    if (!meterFound)
                    {
                        MessageBox.Show("?? don't delete dps meter's .exe file. why you're deleted it?");
                        Environment.Exit(Environment.ExitCode);
                        return;
                    }
                    if (originalFileFound == false)
                    {
                        File.Move(binaryPath + binaryName, binaryPath + binaryName + ".original");
                        File.Copy(curPath + AppDomain.CurrentDomain.FriendlyName + ".exe", binaryPath + binaryName);
                        if (!File.Exists(path + oo2Name)) File.Copy(curPath + oo2Name, path + oo2Name);
                        if (!File.Exists(binaryPath + oo2Name)) File.Copy(curPath + oo2Name, binaryPath + oo2Name);
                    }
                    else//patch new meter only
                    {
                        File.Delete(binaryPath + binaryName);
                        File.Copy(curPath + AppDomain.CurrentDomain.FriendlyName + ".exe", binaryPath + binaryName);
                        if (!File.Exists(path + oo2Name)) File.Copy(curPath + oo2Name, path + oo2Name);
                        if (!File.Exists(binaryPath + oo2Name)) File.Copy(curPath + oo2Name, binaryPath + oo2Name);
                        MessageBox.Show("overwrited loa-details binary to current binary.");
                    }
                } catch(Exception) { hasException = true; }
                if (hasException)
                {
                    MessageBox.Show("unknown error");
                } else
                {
                    MessageBox.Show("successfully patched loa-details binary. close this meter and start loa-details to use it.");
                }
            }
            else if (patchToForkedVersion == false &&
                MessageBox.Show("Delete 2pc forked version binary and roll back to default Loa-details binary?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                bool hasException = false;
                try
                {
                    if (originalFileFound == false)
                    {
                        MessageBox.Show("patcher can't find original binary. reinstall loa-details to roll back to original binary. sorry\n"+
                            "(or it is already changed to original binary)");
                        return;
                    }

                    File.Delete(binaryPath + binaryName);
                    File.Delete(binaryPath + oo2Name);
                    File.Move(binaryPath + binaryName + ".original", binaryPath + binaryName);
                } catch(Exception) { hasException = true; }
                if (hasException)
                {
                    MessageBox.Show("unknown error");
                }
                else
                {
                    MessageBox.Show("successfully removed 2pc fork version binary. at next start, loa-details will use default binary.");
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            patchToForkedVersion = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            patchToForkedVersion = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == binaryName) return;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Programs\loa-details\binary\";
            if (!textBox1.Text.EndsWith(".exe"))
            {
                textBox1.Text = textBox1.Text + ".exe";
                return;
            } else if (textBox1.Text.Length != 0 && !File.Exists(path + textBox1.Text) && File.Exists(path + binaryName))
            {
                MessageBox.Show("Copy and paste the file name instead of write it yourself here.\n"+
                    "if you don't know file name, wait new release. it will be updated\n"+
                    "(copy file name -> ctrl+a + ctrl+v here.)");
                textBox1.Text = binaryName;
            } else if (textBox1.Text.Length != 0 && File.Exists(path + textBox1.Text))
            {
                binaryName = textBox1.Text;
                textBox1.Enabled = false;
            }
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The Loa-Details shortcut link also works. You don't have to browse and select folders yourself.");
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.Filter = "Loa-Details EXE|*.exe;";

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] str = dialog.FileName.Split(new string[] { @"loa-details\" }, StringSplitOptions.RemoveEmptyEntries);
                if (str.Length == 2)
                {
                    path = str[0] +@"loa-details\";
                    needsManualSelection = false;
                } else
                {
                    MessageBox.Show("The file appears to have been selected incorrectly.");
                }
                lbl_path.Text = path;
            }
            lbl_path.Text = path;
            return;
        }
    }
}
