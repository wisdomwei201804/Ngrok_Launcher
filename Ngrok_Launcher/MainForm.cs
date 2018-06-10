using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Configuration;

namespace NgrokLauncher
{
    public partial class MainForm : Form
    {
        private Ngrok ngrok = new Ngrok();

        public MainForm()
        {
            InitializeComponent();
            notifyIcon1.Visible = true;
        }

        private async void MainForm_Shown(object sender, EventArgs e)
        {
            if (!ngrok.IsExists())
            {
                var dialog = MessageBox.Show("This application requires ngrok.exe\nDownload now?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dialog == DialogResult.Yes)
                    Process.Start("https://ngrok.com/download").Dispose();
                this.Close();
                this.Dispose();
                Application.Exit();
            }

            await ngrok.Stop();

            button_serviceStart.Enabled = false;
            button_serviceStop.Enabled = false;
            groupBox_publicUrl.Enabled = false;

            var config = ngrok.Load();
            textBox1.Text = config.authtoken;
            textBox_http.Text = config.tunnels.website.addr.ToString();
            textBox_tcp.Text = config.tunnels.ssh.addr.ToString();
            checkBox_http.Checked = config.run_website;
            checkBox_tcp.Checked = config.run_ssh;
        }

        private void LockAll(bool value)
        {
            button_serviceStart.Enabled = !value;
            button_serviceStop.Enabled = value;
            groupBox1.Enabled = !value;
            groupBox_protocol.Enabled = !value;
            groupBox_publicUrl.Enabled = value;

            // inside grupbox4
            textBox_publicHttp.Text = string.Empty;
            textBox_publicHttps.Text = string.Empty;
            textBox_publicTcp.Text = string.Empty;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
        }

        private void SaveConfigs()
        {
            var token = textBox1.Text;

            var http = 80;
            int.TryParse(textBox_http.Text, out http);
            textBox_http.Text = http.ToString();

            var tcp = 22;
            int.TryParse(textBox_tcp.Text, out tcp);
            textBox_tcp.Text = tcp.ToString();

            ngrok.Save(token, http, tcp, checkBox_http.Checked, checkBox_tcp.Checked);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            LockAll(true);
            SaveConfigs();

            int code = 0;
            if (checkBox_http.Checked && !checkBox_tcp.Checked) code = 1;
            else if (!checkBox_http.Checked && checkBox_tcp.Checked) code = 2;
            else code = 0;

            timer1.Enabled = true;
            await ngrok.Start(code);

            LockAll(false);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            button_serviceStop.Enabled = false;

            await ngrok.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var json = ngrok.GetResponse();
            if (json == null) return;

            foreach (var tunnel in json.tunnels)
            {
                if (tunnel.proto == "http")
                {
                    textBox_publicHttp.Text = tunnel.public_url;
                    button3.Enabled = true;
                    button6.Enabled = true;
                }
                if (tunnel.proto == "https")
                {
                    textBox_publicHttps.Text = tunnel.public_url;
                    button4.Enabled = true;
                    button7.Enabled = true;
                }
                if (tunnel.proto == "tcp")
                {
                    textBox_publicTcp.Text = tunnel.public_url;
                    button5.Enabled = true;
                    button8.Enabled = true;
                }
            }

            if (checkBox_http.Checked && checkBox_tcp.Checked)
            {
                if (button3.Enabled && button4.Enabled && button5.Enabled)
                    timer1.Enabled = false;
            }
            else if (checkBox_http.Checked)
            {
                if (button3.Enabled && button4.Enabled)
                    timer1.Enabled = false;
            }
            else if (checkBox_tcp.Checked)
            {
                if (button5.Enabled)
                    timer1.Enabled = false;
            }
        }

        private void button_url(object sender, EventArgs e)
        {
            var button = sender as Button;
            switch (button.Tag.ToString())
            {
                case "1c":
                    Clipboard.SetText(textBox_publicHttp.Text);
                    break;

                case "2c":
                    Clipboard.SetText(textBox_publicHttps.Text);
                    break;

                case "3c":
                    Clipboard.SetText(textBox_publicTcp.Text);
                    break;

                case "1o":
                    Process.Start(textBox_publicHttp.Text).Dispose();
                    break;

                case "2o":
                    Process.Start(textBox_publicHttps.Text).Dispose();
                    break;

                case "3o":
                    Process.Start(textBox_publicTcp.Text).Dispose();
                    break;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button_serviceStart.Enabled = !string.IsNullOrWhiteSpace(textBox1.Text);
        }

        private void textDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            var k = e.KeyChar;
            var IsDigitBackDelete = char.IsDigit(k) || (k == (char)Keys.Back) || (k == (char)Keys.Delete);
            e.Handled = !IsDigitBackDelete || (k == '.');
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_http.Checked && !checkBox_tcp.Checked)
            {
                if (sender == checkBox_http) checkBox_tcp.Checked = true;
                else checkBox_http.Checked = true;
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if ((FormWindowState.Minimized == this.WindowState) && !button_serviceStart.Enabled)
            {
                //notifyIcon1.Visible = true;
                this.Hide();
            }
        }

        private void notifyIcon_sysTray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show(); //窗体显示
                this.WindowState = FormWindowState.Normal; //窗体正常化
                this.ShowInTaskbar = true; //从状态栏显示
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                this.ShowInTaskbar = false; //从状态栏清除
                this.WindowState = FormWindowState.Minimized; //窗体最小化
                this.Hide(); //窗体隐藏
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; //取消关闭窗体
            this.WindowState = FormWindowState.Minimized; //窗体最小化
            this.Hide(); //窗体隐藏
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void checkBox_autoBoot_CheckedChanged(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (!AppSettingsKeyExists("autoBoot", config))
            {
                config.AppSettings.Settings.Add("autoBoot", "Off");
            }
            if (!checkBox_autoBoot.Checked)
            {
                config.AppSettings.Settings["autoBoot"].Value = "Off";
                Microsoft.Win32.RegistryKey Rkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                Rkey.DeleteValue("Ngrok Launcher");
                Rkey.Close();
            }
            else
            {
                config.AppSettings.Settings["autoBoot"].Value = "On";
                //获取执行该方法的程序集，并获取该程序集的文件路径（由该文件路径可以得到程序集所在的目录）
                string thisExecutablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;//this.GetType().Assembly.Location;
                                                                                                       //SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run注册表中这个路径是开机自启动的路径
                Microsoft.Win32.RegistryKey Rkey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                Rkey.SetValue("Ngrok Launcher", thisExecutablePath);
                Rkey.Close();
            }
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void checkBox_autoMinimized_CheckedChanged(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (!AppSettingsKeyExists("autoMinimized",config))
            {
                config.AppSettings.Settings.Add("autoMinimized", "Off");
            }
                
            if (!checkBox_autoMinimized.Checked)
            {
                config.AppSettings.Settings["autoMinimized"].Value = "Off";
            }
            else
            {
                config.AppSettings.Settings["autoMinimized"].Value = "On";
            }
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }
        
        /// 判断appSettings中是否有此项  
        /// </summary>  
        private static bool AppSettingsKeyExists(string strKey, Configuration config)
        {
            foreach (string str in config.AppSettings.Settings.AllKeys)
            {
                if (str == strKey)
                {
                    return true;
                }
            }
            return false;
        }
    }
}