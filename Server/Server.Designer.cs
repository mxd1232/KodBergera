namespace Server
{
    partial class Server
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
            this.IPLabel = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtLogs = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtMSG = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Connections = new System.Windows.Forms.ListBox();
            this.logsLabel = new System.Windows.Forms.Label();
            this.connectionsLabel = new System.Windows.Forms.Label();
            this.DestinationPort = new System.Windows.Forms.Label();
            this.convertableNumberBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnNegateOneBit = new System.Windows.Forms.Button();
            this.btnSwapBits = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IPLabel
            // 
            this.IPLabel.AutoSize = true;
            this.IPLabel.Location = new System.Drawing.Point(23, 26);
            this.IPLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.IPLabel.Name = "IPLabel";
            this.IPLabel.Size = new System.Drawing.Size(20, 17);
            this.IPLabel.TabIndex = 1;
            this.IPLabel.Text = "IP";
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(23, 78);
            this.PortLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(34, 17);
            this.PortLabel.TabIndex = 4;
            this.PortLabel.Text = "Port";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(26, 149);
            this.txtPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(99, 22);
            this.txtPort.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(148, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(148, 101);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(13, 17);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "-";
            // 
            // txtLogs
            // 
            this.txtLogs.Location = new System.Drawing.Point(256, 46);
            this.txtLogs.Margin = new System.Windows.Forms.Padding(4);
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.Size = new System.Drawing.Size(421, 195);
            this.txtLogs.TabIndex = 7;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtMSG
            // 
            this.txtMSG.BackColor = System.Drawing.SystemColors.Info;
            this.txtMSG.Location = new System.Drawing.Point(25, 260);
            this.txtMSG.Margin = new System.Windows.Forms.Padding(4);
            this.txtMSG.Name = "txtMSG";
            this.txtMSG.Size = new System.Drawing.Size(334, 22);
            this.txtMSG.TabIndex = 19;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(25, 290);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(334, 28);
            this.btnSend.TabIndex = 18;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 191);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Short number to send";
            // 
            // Connections
            // 
            this.Connections.FormattingEnabled = true;
            this.Connections.ItemHeight = 16;
            this.Connections.Location = new System.Drawing.Point(687, 46);
            this.Connections.Margin = new System.Windows.Forms.Padding(4);
            this.Connections.Name = "Connections";
            this.Connections.Size = new System.Drawing.Size(413, 196);
            this.Connections.TabIndex = 23;
            // 
            // logsLabel
            // 
            this.logsLabel.AutoSize = true;
            this.logsLabel.Location = new System.Drawing.Point(252, 26);
            this.logsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.logsLabel.Name = "logsLabel";
            this.logsLabel.Size = new System.Drawing.Size(39, 17);
            this.logsLabel.TabIndex = 24;
            this.logsLabel.Text = "Logs";
            // 
            // connectionsLabel
            // 
            this.connectionsLabel.AutoSize = true;
            this.connectionsLabel.Location = new System.Drawing.Point(683, 26);
            this.connectionsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.connectionsLabel.Name = "connectionsLabel";
            this.connectionsLabel.Size = new System.Drawing.Size(86, 17);
            this.connectionsLabel.TabIndex = 25;
            this.connectionsLabel.Text = "Connections";
            // 
            // DestinationPort
            // 
            this.DestinationPort.AutoSize = true;
            this.DestinationPort.Location = new System.Drawing.Point(23, 117);
            this.DestinationPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DestinationPort.Name = "DestinationPort";
            this.DestinationPort.Size = new System.Drawing.Size(34, 17);
            this.DestinationPort.TabIndex = 26;
            this.DestinationPort.Text = "Port";
            // 
            // convertableNumberBox
            // 
            this.convertableNumberBox.Location = new System.Drawing.Point(26, 219);
            this.convertableNumberBox.Margin = new System.Windows.Forms.Padding(4);
            this.convertableNumberBox.Name = "convertableNumberBox";
            this.convertableNumberBox.Size = new System.Drawing.Size(81, 22);
            this.convertableNumberBox.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(367, 263);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "number in berger code";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(136, 216);
            this.btnConvert.Margin = new System.Windows.Forms.Padding(4);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(112, 28);
            this.btnConvert.TabIndex = 29;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnNegateOneBit
            // 
            this.btnNegateOneBit.Location = new System.Drawing.Point(565, 254);
            this.btnNegateOneBit.Margin = new System.Windows.Forms.Padding(4);
            this.btnNegateOneBit.Name = "btnNegateOneBit";
            this.btnNegateOneBit.Size = new System.Drawing.Size(142, 28);
            this.btnNegateOneBit.TabIndex = 30;
            this.btnNegateOneBit.Text = "Negate One Bit";
            this.btnNegateOneBit.UseVisualStyleBackColor = true;
            this.btnNegateOneBit.Click += new System.EventHandler(this.btnNegateOneBit_Click);
            // 
            // btnSwapBits
            // 
            this.btnSwapBits.Location = new System.Drawing.Point(715, 254);
            this.btnSwapBits.Margin = new System.Windows.Forms.Padding(4);
            this.btnSwapBits.Name = "btnSwapBits";
            this.btnSwapBits.Size = new System.Drawing.Size(142, 28);
            this.btnSwapBits.TabIndex = 31;
            this.btnSwapBits.Text = "Swap Bits";
            this.btnSwapBits.UseVisualStyleBackColor = true;
            this.btnSwapBits.Click += new System.EventHandler(this.btnSwapBits_Click);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 331);
            this.Controls.Add(this.btnSwapBits);
            this.Controls.Add(this.btnNegateOneBit);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.convertableNumberBox);
            this.Controls.Add(this.DestinationPort);
            this.Controls.Add(this.connectionsLabel);
            this.Controls.Add(this.logsLabel);
            this.Controls.Add(this.Connections);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMSG);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtLogs);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.IPLabel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Server";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label IPLabel;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtLogs;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.TextBox txtMSG;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox Connections;
        private System.Windows.Forms.Label logsLabel;
        private System.Windows.Forms.Label connectionsLabel;
        private System.Windows.Forms.Label DestinationPort;
        private System.Windows.Forms.TextBox convertableNumberBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnNegateOneBit;
        private System.Windows.Forms.Button btnSwapBits;
    }
}

