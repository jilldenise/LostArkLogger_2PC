using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Principal;
using System.Windows.Forms;
namespace LostArkLogger
{
    internal static class Program
    {
        public static bool IsConsole = Console.OpenStandardInput(1) != Stream.Null;
        [STAThread]
        static void Main(string[] args)
        {
            Properties.Settings.Default.Providers.Clear();
            Bluegrams.Application.PortableSettingsProvider.SettingsFileName = AppDomain.CurrentDomain.FriendlyName + ".ini";
            Bluegrams.Application.PortableSettingsProvider.ApplyProvider(Properties.Settings.Default);
            if (!AdminRelauncher()) return;
            if (!IsConsole) Warning();
            AttemptFirewallPrompt();
            Application.EnableVisualStyles();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow(args));

            if (File.Exists(Utilities.Logger.fileName) && Properties.Settings.Default.AutoUpload)
            {
                var fileBytes = File.ReadAllBytes(Utilities.Logger.fileName);
                var fileText = File.ReadAllText(Utilities.Logger.fileName);
                if (fileBytes.Length > 100 && fileText.Contains("8|"))
                    Utilities.Uploader.UploadLog(fileBytes);
            }
        }
        static void AttemptFirewallPrompt()
        {
            var ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
            var ipLocalEndPoint = new IPEndPoint(ipAddress, 12345);
            var t = new TcpListener(ipLocalEndPoint);
            t.Start();
            t.Stop();
        }
        public static bool VersionCompatibility()
        {//return true = first pc, false = second pc
            bool lockEnabled = (Properties.Settings.Default.LockedNICname.Length != 0 && Properties.Settings.Default.LockedRegionName.Length != 0);
            (var region, var installedVersion) = VersionCheck.GetLostArkVersion();
            if (installedVersion == null)
            {
                if (Properties.Settings.Default.Npcap == true && lockEnabled == false)
                {
                    MessageBox.Show("You must select the NIC yourself because Lost Ark is not running.", "Lost Ark Not Running", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;//second pc
                }
            }
            else if (region == Region.Unknown)
            {
                MessageBox.Show("DPS Meter is out of date.\nDPS Meter might not work until updated.\nCheck Discord/Github for more info.\nFeel free to add a message in the discord informing shalzuth that it's out of data", "Out of date!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;//first pc, out of date
            }
            else if (region == Region.Steam || region == Region.Korea)
            {
                return true;//first pc, supported version
            }
            return false;//If all of the above conditions are not met, it is treated as a second pc
        }
        static void Warning()
        {
            if (Properties.Settings.Default.IgnoreWarning) return;
            if (AppDomain.CurrentDomain.FriendlyName.Contains("LostArk"))
            {
                var tempName = "DpsMeter.exe";
                MessageBox.Show("LostArkLogger.exe is flagged.\nRenaming to " + tempName + " !", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                File.Copy(AppDomain.CurrentDomain.FriendlyName, tempName);
                Process.Start(tempName);
                Environment.Exit(0);
            }
            else
            {
                Process.GetProcessesByName("LostArkLogger").ToList().ForEach(p => p.Kill());
                if (File.Exists("LostArkLogger.exe")) File.Delete("LostArkLogger.exe");
            }
            var res = MessageBox.Show("The game director has instructed Amazon Game Studios to ban users using a DPS Meter.\n\nAt this time, please refrain from using the DPS Meter.\n\nSelect \"Retry\" to voice your feedback, as this is not a hack nor a solution that should violate TOS", "Warning!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
            if (res == DialogResult.Abort) Environment.Exit(0);
            else if (res == DialogResult.Retry)
            {
                Process.Start("https://forums.playlostark.com/t/talk-to-us-already-about-the-dps-meter/370558");
                Environment.Exit(0);
            }
            Properties.Settings.Default.IgnoreWarning = true;
            Properties.Settings.Default.Save();
        }
        private static bool AdminRelauncher()
        {
            if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
            {
                var startInfo = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    WorkingDirectory = Environment.CurrentDirectory,
                    FileName = Assembly.GetEntryAssembly().CodeBase.Replace(".dll", ".exe"),
                    Verb = "runas"
                };
                try { Process.Start(startInfo); }
                catch (Exception) { MessageBox.Show("This program must be run as an administrator!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                return false;
            }
            return true;
        }
    }
}
