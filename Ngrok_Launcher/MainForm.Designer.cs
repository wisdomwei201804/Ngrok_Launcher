namespace NgrokLauncher
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox_protocol = new System.Windows.Forms.GroupBox();
            this.textBox_tcp = new System.Windows.Forms.TextBox();
            this.textBox_http = new System.Windows.Forms.TextBox();
            this.checkBox_tcp = new System.Windows.Forms.CheckBox();
            this.checkBox_http = new System.Windows.Forms.CheckBox();
            this.groupBox_service = new System.Windows.Forms.GroupBox();
            this.button_serviceStop = new System.Windows.Forms.Button();
            this.button_serviceStart = new System.Windows.Forms.Button();
            this.groupBox_publicUrl = new System.Windows.Forms.GroupBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label_publicTcp = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox_publicTcp = new System.Windows.Forms.TextBox();
            this.label_publicHttps = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox_publicHttps = new System.Windows.Forms.TextBox();
            this.label_publicHttp = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox_publicHttp = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox_autoBoot = new System.Windows.Forms.CheckBox();
            this.checkBox_autoMinimized = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox_protocol.SuspendLayout();
            this.groupBox_service.SuspendLayout();
            this.groupBox_publicUrl.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 46);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Auth Token";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(339, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBox_protocol
            // 
            this.groupBox_protocol.Controls.Add(this.textBox_tcp);
            this.groupBox_protocol.Controls.Add(this.textBox_http);
            this.groupBox_protocol.Controls.Add(this.checkBox_tcp);
            this.groupBox_protocol.Controls.Add(this.checkBox_http);
            this.groupBox_protocol.Location = new System.Drawing.Point(12, 63);
            this.groupBox_protocol.Name = "groupBox_protocol";
            this.groupBox_protocol.Size = new System.Drawing.Size(134, 65);
            this.groupBox_protocol.TabIndex = 1;
            this.groupBox_protocol.TabStop = false;
            this.groupBox_protocol.Text = "Protocol : Port";
            // 
            // textBox_tcp
            // 
            this.textBox_tcp.Location = new System.Drawing.Point(84, 37);
            this.textBox_tcp.Name = "textBox_tcp";
            this.textBox_tcp.Size = new System.Drawing.Size(40, 21);
            this.textBox_tcp.TabIndex = 3;
            this.textBox_tcp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_tcp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textDigit_KeyPress);
            // 
            // textBox_http
            // 
            this.textBox_http.Location = new System.Drawing.Point(84, 16);
            this.textBox_http.Name = "textBox_http";
            this.textBox_http.Size = new System.Drawing.Size(40, 21);
            this.textBox_http.TabIndex = 2;
            this.textBox_http.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_http.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textDigit_KeyPress);
            // 
            // checkBox_tcp
            // 
            this.checkBox_tcp.AutoSize = true;
            this.checkBox_tcp.Location = new System.Drawing.Point(10, 39);
            this.checkBox_tcp.Name = "checkBox_tcp";
            this.checkBox_tcp.Size = new System.Drawing.Size(42, 16);
            this.checkBox_tcp.TabIndex = 1;
            this.checkBox_tcp.Text = "TCP";
            this.checkBox_tcp.UseVisualStyleBackColor = true;
            this.checkBox_tcp.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox_http
            // 
            this.checkBox_http.AutoSize = true;
            this.checkBox_http.Location = new System.Drawing.Point(10, 18);
            this.checkBox_http.Name = "checkBox_http";
            this.checkBox_http.Size = new System.Drawing.Size(60, 16);
            this.checkBox_http.TabIndex = 0;
            this.checkBox_http.Text = "HTTP/S";
            this.checkBox_http.UseVisualStyleBackColor = true;
            this.checkBox_http.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // groupBox_service
            // 
            this.groupBox_service.Controls.Add(this.checkBox_autoMinimized);
            this.groupBox_service.Controls.Add(this.checkBox_autoBoot);
            this.groupBox_service.Controls.Add(this.button_serviceStop);
            this.groupBox_service.Controls.Add(this.button_serviceStart);
            this.groupBox_service.Location = new System.Drawing.Point(152, 63);
            this.groupBox_service.Name = "groupBox_service";
            this.groupBox_service.Size = new System.Drawing.Size(220, 65);
            this.groupBox_service.TabIndex = 2;
            this.groupBox_service.TabStop = false;
            this.groupBox_service.Text = "Service";
            // 
            // button_serviceStop
            // 
            this.button_serviceStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_serviceStop.Location = new System.Drawing.Point(129, 39);
            this.button_serviceStop.Name = "button_serviceStop";
            this.button_serviceStop.Size = new System.Drawing.Size(80, 21);
            this.button_serviceStop.TabIndex = 1;
            this.button_serviceStop.Text = "STOP";
            this.button_serviceStop.UseVisualStyleBackColor = true;
            this.button_serviceStop.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_serviceStart
            // 
            this.button_serviceStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_serviceStart.Location = new System.Drawing.Point(128, 14);
            this.button_serviceStart.Name = "button_serviceStart";
            this.button_serviceStart.Size = new System.Drawing.Size(80, 21);
            this.button_serviceStart.TabIndex = 0;
            this.button_serviceStart.Text = "START";
            this.button_serviceStart.UseVisualStyleBackColor = true;
            this.button_serviceStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox_publicUrl
            // 
            this.groupBox_publicUrl.Controls.Add(this.button8);
            this.groupBox_publicUrl.Controls.Add(this.button7);
            this.groupBox_publicUrl.Controls.Add(this.button6);
            this.groupBox_publicUrl.Controls.Add(this.label_publicTcp);
            this.groupBox_publicUrl.Controls.Add(this.button5);
            this.groupBox_publicUrl.Controls.Add(this.textBox_publicTcp);
            this.groupBox_publicUrl.Controls.Add(this.label_publicHttps);
            this.groupBox_publicUrl.Controls.Add(this.button4);
            this.groupBox_publicUrl.Controls.Add(this.textBox_publicHttps);
            this.groupBox_publicUrl.Controls.Add(this.label_publicHttp);
            this.groupBox_publicUrl.Controls.Add(this.button3);
            this.groupBox_publicUrl.Controls.Add(this.textBox_publicHttp);
            this.groupBox_publicUrl.Location = new System.Drawing.Point(12, 133);
            this.groupBox_publicUrl.Name = "groupBox_publicUrl";
            this.groupBox_publicUrl.Size = new System.Drawing.Size(360, 95);
            this.groupBox_publicUrl.TabIndex = 3;
            this.groupBox_publicUrl.TabStop = false;
            this.groupBox_publicUrl.Text = "Public Url";
            // 
            // button8
            // 
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button8.Location = new System.Drawing.Point(243, 64);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(50, 21);
            this.button8.TabIndex = 12;
            this.button8.Tag = "3o";
            this.button8.Text = "Open";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button_url);
            // 
            // button7
            // 
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button7.Location = new System.Drawing.Point(243, 40);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(50, 21);
            this.button7.TabIndex = 11;
            this.button7.Tag = "2o";
            this.button7.Text = "Open";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button_url);
            // 
            // button6
            // 
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.Location = new System.Drawing.Point(243, 16);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(50, 21);
            this.button6.TabIndex = 10;
            this.button6.Tag = "1o";
            this.button6.Text = "Open";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button_url);
            // 
            // label_publicTcp
            // 
            this.label_publicTcp.AutoSize = true;
            this.label_publicTcp.Location = new System.Drawing.Point(7, 68);
            this.label_publicTcp.Name = "label_publicTcp";
            this.label_publicTcp.Size = new System.Drawing.Size(35, 12);
            this.label_publicTcp.TabIndex = 9;
            this.label_publicTcp.Text = "TCP :";
            // 
            // button5
            // 
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.Location = new System.Drawing.Point(299, 64);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 21);
            this.button5.TabIndex = 8;
            this.button5.Tag = "3c";
            this.button5.Text = "Copy";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button_url);
            // 
            // textBox_publicTcp
            // 
            this.textBox_publicTcp.Location = new System.Drawing.Point(58, 66);
            this.textBox_publicTcp.Name = "textBox_publicTcp";
            this.textBox_publicTcp.ReadOnly = true;
            this.textBox_publicTcp.Size = new System.Drawing.Size(179, 21);
            this.textBox_publicTcp.TabIndex = 7;
            // 
            // label_publicHttps
            // 
            this.label_publicHttps.AutoSize = true;
            this.label_publicHttps.Location = new System.Drawing.Point(7, 44);
            this.label_publicHttps.Name = "label_publicHttps";
            this.label_publicHttps.Size = new System.Drawing.Size(47, 12);
            this.label_publicHttps.TabIndex = 6;
            this.label_publicHttps.Text = "HTTPS :";
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Location = new System.Drawing.Point(299, 40);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 21);
            this.button4.TabIndex = 5;
            this.button4.Tag = "2c";
            this.button4.Text = "Copy";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button_url);
            // 
            // textBox_publicHttps
            // 
            this.textBox_publicHttps.Location = new System.Drawing.Point(58, 42);
            this.textBox_publicHttps.Name = "textBox_publicHttps";
            this.textBox_publicHttps.ReadOnly = true;
            this.textBox_publicHttps.Size = new System.Drawing.Size(179, 21);
            this.textBox_publicHttps.TabIndex = 4;
            // 
            // label_publicHttp
            // 
            this.label_publicHttp.AutoSize = true;
            this.label_publicHttp.Location = new System.Drawing.Point(7, 20);
            this.label_publicHttp.Name = "label_publicHttp";
            this.label_publicHttp.Size = new System.Drawing.Size(41, 12);
            this.label_publicHttp.TabIndex = 3;
            this.label_publicHttp.Text = "HTTP :";
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Location = new System.Drawing.Point(299, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 21);
            this.button3.TabIndex = 2;
            this.button3.Tag = "1c";
            this.button3.Text = "Copy";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button_url);
            // 
            // textBox_publicHttp
            // 
            this.textBox_publicHttp.Location = new System.Drawing.Point(58, 18);
            this.textBox_publicHttp.Name = "textBox_publicHttp";
            this.textBox_publicHttp.ReadOnly = true;
            this.textBox_publicHttp.Size = new System.Drawing.Size(179, 21);
            this.textBox_publicHttp.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Double click to show the main window.";
            this.notifyIcon1.BalloonTipTitle = "Ngrok Launcher";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Ngrok Launcher";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_sysTray_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.ToolStripMenuItem1.Text = "退出";
            this.ToolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // checkBox_autoBoot
            // 
            this.checkBox_autoBoot.AutoSize = true;
            this.checkBox_autoBoot.Location = new System.Drawing.Point(9, 18);
            this.checkBox_autoBoot.Name = "checkBox_autoBoot";
            this.checkBox_autoBoot.Size = new System.Drawing.Size(102, 16);
            this.checkBox_autoBoot.TabIndex = 2;
            this.checkBox_autoBoot.Text = "start on boot";
            this.checkBox_autoBoot.UseVisualStyleBackColor = true;
            this.checkBox_autoBoot.CheckedChanged += new System.EventHandler(this.checkBox_autoBoot_CheckedChanged);
            // 
            // checkBox_autoMinimized
            // 
            this.checkBox_autoMinimized.AutoSize = true;
            this.checkBox_autoMinimized.Location = new System.Drawing.Point(9, 39);
            this.checkBox_autoMinimized.Name = "checkBox_autoMinimized";
            this.checkBox_autoMinimized.Size = new System.Drawing.Size(108, 16);
            this.checkBox_autoMinimized.TabIndex = 3;
            this.checkBox_autoMinimized.Text = "auto Minimized";
            this.checkBox_autoMinimized.UseVisualStyleBackColor = true;
            this.checkBox_autoMinimized.CheckedChanged += new System.EventHandler(this.checkBox_autoMinimized_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 239);
            this.Controls.Add(this.groupBox_publicUrl);
            this.Controls.Add(this.groupBox_service);
            this.Controls.Add(this.groupBox_protocol);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ngrok – Secure tunnels to localhost";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox_protocol.ResumeLayout(false);
            this.groupBox_protocol.PerformLayout();
            this.groupBox_service.ResumeLayout(false);
            this.groupBox_service.PerformLayout();
            this.groupBox_publicUrl.ResumeLayout(false);
            this.groupBox_publicUrl.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox_protocol;
        private System.Windows.Forms.TextBox textBox_tcp;
        private System.Windows.Forms.TextBox textBox_http;
        private System.Windows.Forms.CheckBox checkBox_tcp;
        private System.Windows.Forms.CheckBox checkBox_http;
        private System.Windows.Forms.GroupBox groupBox_service;
        private System.Windows.Forms.Button button_serviceStop;
        private System.Windows.Forms.Button button_serviceStart;
        private System.Windows.Forms.GroupBox groupBox_publicUrl;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox_publicHttp;
        private System.Windows.Forms.Label label_publicTcp;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox_publicTcp;
        private System.Windows.Forms.Label label_publicHttps;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox_publicHttps;
        private System.Windows.Forms.Label label_publicHttp;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem1;
        private System.Windows.Forms.CheckBox checkBox_autoMinimized;
        private System.Windows.Forms.CheckBox checkBox_autoBoot;
    }
}

