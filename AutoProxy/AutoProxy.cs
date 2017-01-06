using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace AutoProxy
{
    public partial class AutoProxy : Form
    {
        // HKEY_CURRENT_USER
        private const string InternetOpt = "Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings";
        RegistryKey InternetKey;

        private string ProxyPacURL, ProxyServer;
        private int ProxyEnable;
        
        [DllImport("wininet.dll")]
        public static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);
        public const int INTERNET_OPTION_SETTINGS_CHANGED = 39;
        public const int INTERNET_OPTION_REFRESH = 37;

        public AutoProxy()
        {   
            InitializeComponent();

            InternetKey = Registry.CurrentUser.OpenSubKey(InternetOpt, true);

            ProxyPacURL = (string)InternetKey.GetValue("AutoConfigURL", "");
            ProxyServer = (string)InternetKey.GetValue("ProxyServer", "");
            ProxyEnable = (int)InternetKey.GetValue("ProxyEnable");

            StatusLabel.Text = "No setting";
            if (ProxyPacURL.Length > 0)
            {
                btpac.Enabled = false;
                PacAddress.Text = ProxyPacURL;
                StatusLabel.Text = "Auto Proxy set";
            }
            else if (ProxyServer.Length > 0)
            {
                PacAddress.Text = ProxyServer;
            }
            if (ProxyEnable != 0)
            {
                btserver.Enabled = false;
                PacAddress.Text = ProxyServer;
                StatusLabel.Text = "Proxy Server set";
            }
        }

        private void btserver_Click(object sender, EventArgs e)
        {
            if (PacAddress.Text.Length == 0)
                return;

            DialogResult result = MessageBox.Show("Address is " + PacAddress.Text, "代理服务器", MessageBoxButtons.YesNo);
            if (result != System.Windows.Forms.DialogResult.Yes)
                return;

            InternetKey.SetValue("ProxyServer", PacAddress.Text);
            InternetKey.SetValue("ProxyEnable", 1);

            ProxyServer = (string) InternetKey.GetValue("ProxyServer");
            if (ProxyServer == null)
            {
                StatusLabel.Text = "Set Proxy Server failure";
                InternetKey.SetValue("ProxyEnable", 0);
                return;
            }
            StatusLabel.Text = "Set Proxy Server success, address is " + ProxyServer;
            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);

            StatusLabel.Text = "Set Proxy Server success, address is " + ProxyServer;
            btpac.Enabled = false;
            btserver.Enabled = false;
        }

        private void PacAddress_TextChanged(object sender, EventArgs e)
        {
            btpac.Enabled = true;
            btserver.Enabled = true;
        }

        private void PacAddress_TextEnter(object sender, EventArgs e)
        {   
            TextBox tb = (TextBox)sender;
            ToolTip tt = new ToolTip();
            tt.Show("输入代理服务器地址或URL, 如:127.0.0.1:8888或http://127.0.0.1/autoproxy.pac", tb, 0, 20, 1500); // milliseconds
        }

        private void PAC_tip(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.Show("设置自动代理 PAC URL, 如http://127.0.0.1/autoproxy.pac", this, 10, 140, 1000);
        }

        private void ProxyServer_Tip(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.Show("设置代理器地址, 如127.0.0.1:8888", this, 10, 140, 1000);
        }

        private void startup_Click(object sender, EventArgs e)
        {
            if (PacAddress.Text.Length == 0)
                return;
                        
            DialogResult result = MessageBox.Show("URL is " + PacAddress.Text, "自动代理", MessageBoxButtons.YesNo);
            if (result != System.Windows.Forms.DialogResult.Yes)
                return;

            InternetKey.SetValue("AutoConfigURL", PacAddress.Text);
            InternetKey.SetValue("ProxyEnable", 0);

            ProxyPacURL = (string)InternetKey.GetValue("AutoConfigURL");
            if (ProxyPacURL == null)
            {
                StatusLabel.Text = "Set PAC failure";                
                return;
            }
            StatusLabel.Text = "Set PAC success, URL is " + ProxyPacURL;

            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);

            btpac.Enabled = false;
            btserver.Enabled = false;
        }


        private void stop_Click(object sender, EventArgs e)
        {
            InternetKey.SetValue("ProxyEnable", 0);
            if (InternetKey.GetValue("AutoConfigURL") != null)
                InternetKey.DeleteValue("AutoConfigURL");
            ProxyEnable = (int)InternetKey.GetValue("ProxyEnable");
            if (ProxyEnable != 0)
            {
                StatusLabel.Text = "Clear Proxy Setting failure";
            }
            else
            {
                StatusLabel.Text = "Proxy Setting has been disabled";
            }

            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);

            btpac.Enabled = true;
            btserver.Enabled = true;
        }
    }
}
