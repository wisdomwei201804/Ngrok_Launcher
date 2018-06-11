using System;
using System.Diagnostics;
using System.Windows.Forms;

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
                //this.Close();
                //this.Dispose();
                Application.Exit();
            }

            await ngrok.Stop();

            button_serviceStart.Enabled = false;
            button_serviceStop.Enabled = false;
            groupBox_publicUrl.Enabled = false;

            var config = ngrok.Load();
            textBox_authToken.Text = config.authtoken;
            textBox_serverAddr.Text = config.server_addr;
            textBox_http.Text = config.tunnels.website.proto.http.ToString();
            textBox_subDomain.Text = config.tunnels.website.subdomain.ToString();
            textBox_tcp.Text = config.tunnels.tcp.remote_port.ToString();
            textBox_lanPort.Text = config.tunnels.tcp.proto.tcp.ToString();
            checkBox_http.Checked = config.run_website;
            checkBox_tcp.Checked = config.run_tcp;
            checkBox_autoBoot.Checked = config.auto_boot;
            checkBox_autoMinimized.Checked = config.auto_minimized;
            if( config.authtoken != "" || config.server_addr != "" )
            {
                if (config.auto_minimized)
                {
                    checkBox_autoMinimized.Checked = true;
                    this.WindowState = FormWindowState.Minimized; //窗体最小化
                    this.Hide(); //窗体隐藏
                }
                if (config.auto_boot)
                {
                    checkBox_autoBoot.Checked = true;
                    LockAll(true);
                    int code = 0;
                    if (checkBox_http.Checked && !checkBox_tcp.Checked) code = 1;
                    else if (!checkBox_http.Checked && checkBox_tcp.Checked) code = 2;
                    else code = 0;
                    //timer1.Enabled = true;
                    await ngrok.Start(code);
                    LockAll(false);
                }
            }
           
        }

        private void LockAll(bool value)
        {
            button_serviceStart.Enabled = !value;
            button_serviceStop.Enabled = value;
            groupBox_authToken.Enabled = !value;
            groupBox_serverAddr.Enabled = !value;
            groupBox_protocol.Enabled = !value;
            groupBox_publicUrl.Enabled = value;
            checkBox_autoBoot.Enabled = !value;
            checkBox_autoMinimized.Enabled = !value;

            // inside Public Url
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
            var token = textBox_authToken.Text.ToString();
            var server_addr = textBox_serverAddr.Text.ToString();

            var http = 80;
            int.TryParse(textBox_http.Text, out http);
            textBox_http.Text = http.ToString();

            var subdomain = textBox_subDomain.Text.ToString();

            var tcp = 2222;
            int.TryParse(textBox_tcp.Text, out tcp);
            textBox_tcp.Text = tcp.ToString();

            var lanport = 22;
            int.TryParse(textBox_lanPort.Text, out lanport);
            textBox_lanPort.Text = lanport.ToString();

            ngrok.Save(token, server_addr, http, subdomain, tcp, lanport, checkBox_http.Checked, checkBox_tcp.Checked, checkBox_autoBoot.Checked, checkBox_autoMinimized.Checked);
        }

        private async void button_serviceStart_Click(object sender, EventArgs e)
        {
            LockAll(true);
            SaveConfigs();

            int code = 0;
            if (checkBox_http.Checked && !checkBox_tcp.Checked) code = 1;
            else if (!checkBox_http.Checked && checkBox_tcp.Checked) code = 2;
            else code = 0;

            //timer1.Enabled = true;
            await ngrok.Start(code);

            LockAll(false);
        }

        private async void button_serviceStop_Click(object sender, EventArgs e)
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

        private void textBox_authToken_TextChanged(object sender, EventArgs e)
        {
            button_serviceStart.Enabled = !string.IsNullOrWhiteSpace(textBox_authToken.Text);
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
            SaveConfigs();
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

        private async void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await ngrok.Stop();
            this.Close();
            this.Dispose();
        }

        private void checkBox_autoBoot_CheckedChanged(object sender, EventArgs e)
        {
            SaveConfigs();
            if (!checkBox_autoBoot.Checked)
            {
                Microsoft.Win32.RegistryKey Rkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                Rkey.DeleteValue("Ngrok Launcher");
                Rkey.Close();
            }
            else
            {
                //获取执行该方法的程序集，并获取该程序集的文件路径（由该文件路径可以得到程序集所在的目录）
                string thisExecutablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;//this.GetType().Assembly.Location;
                                                                                                       //SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run注册表中这个路径是开机自启动的路径
                Microsoft.Win32.RegistryKey Rkey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                Rkey.SetValue("Ngrok Launcher", thisExecutablePath);
                Rkey.Close();
            }
        }

        private void checkBox_autoMinimized_CheckedChanged(object sender, EventArgs e)
        {
            SaveConfigs();
        }
        
        private void textBox_serverAddr_TextChanged(object sender, EventArgs e)
        {
            button_serviceStart.Enabled = !string.IsNullOrWhiteSpace(textBox_serverAddr.Text);
        }
    }
}