namespace AutoProxy
{
    partial class AutoProxy
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btpac = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.PacAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btserver = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btpac
            // 
            this.btpac.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btpac.Location = new System.Drawing.Point(390, 84);
            this.btpac.Name = "btpac";
            this.btpac.Size = new System.Drawing.Size(88, 23);
            this.btpac.TabIndex = 0;
            this.btpac.Text = "设置自动代理";
            this.btpac.UseVisualStyleBackColor = true;
            this.btpac.Click += new System.EventHandler(this.startup_Click);
            this.btpac.MouseHover += new System.EventHandler(this.PAC_tip);
            // 
            // stop
            // 
            this.stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stop.Location = new System.Drawing.Point(486, 84);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(86, 23);
            this.stop.TabIndex = 0;
            this.stop.Text = "停止系统代理";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // PacAddress
            // 
            this.PacAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PacAddress.Location = new System.Drawing.Point(14, 43);
            this.PacAddress.Name = "PacAddress";
            this.PacAddress.Size = new System.Drawing.Size(558, 21);
            this.PacAddress.TabIndex = 1;
            this.PacAddress.TextChanged += new System.EventHandler(this.PacAddress_TextChanged);
            this.PacAddress.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PacAddress_TextEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "代理服务器地址或PAC URL:";
            // 
            // btserver
            // 
            this.btserver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btserver.Location = new System.Drawing.Point(279, 84);
            this.btserver.Name = "btserver";
            this.btserver.Size = new System.Drawing.Size(101, 23);
            this.btserver.TabIndex = 0;
            this.btserver.Text = "设置代理服务器";
            this.btserver.UseVisualStyleBackColor = true;
            this.btserver.Click += new System.EventHandler(this.btserver_Click);
            this.btserver.MouseHover += new System.EventHandler(this.ProxyServer_Tip);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 139);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(584, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // AutoProxy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 161);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PacAddress);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.btserver);
            this.Controls.Add(this.btpac);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 200);
            this.MinimumSize = new System.Drawing.Size(600, 200);
            this.Name = "AutoProxy";
            this.Text = "AutoProxy";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btpac;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.TextBox PacAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btserver;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
    }
}

