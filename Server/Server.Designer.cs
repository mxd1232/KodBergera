using System.Windows.Forms;

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
            this.BeginInvoke(new MethodInvoker(listener.Server.Dispose));
            
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
            this.IPLabel = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtLogs = new System.Windows.Forms.TextBox();
            this.recieverWorker = new System.ComponentModel.BackgroundWorker();
            this.senderWorker = new System.ComponentModel.BackgroundWorker();
            this.txtMSG = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.numberLabel = new System.Windows.Forms.Label();
            this.Connections = new System.Windows.Forms.ListBox();
            this.logsLabel = new System.Windows.Forms.Label();
            this.connectionsLabel = new System.Windows.Forms.Label();
            this.DestinationPort = new System.Windows.Forms.Label();
            this.convertableNumberBox = new System.Windows.Forms.TextBox();
            this.bergerLabel = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnNegateOneBit = new System.Windows.Forms.Button();
            this.btnSwapBits = new System.Windows.Forms.Button();
            this.btnCloseConnection = new System.Windows.Forms.Button();
            this.isNegatedLabel = new System.Windows.Forms.Label();
            this.isSwapedLabel = new System.Windows.Forms.Label();
            this.btnControlSum = new System.Windows.Forms.Button();
            this.controlSumLabel = new System.Windows.Forms.Label();
            this.isConnectionClosedLabel = new System.Windows.Forms.Label();
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
            // recieverWorker
            // 
            this.recieverWorker.WorkerSupportsCancellation = true;
            this.recieverWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.recieverWorker_DoWork);
            // 
            // senderWorker
            // 
            this.senderWorker.WorkerSupportsCancellation = true;
            this.senderWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.senderWorker_DoWork);
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
            // numberLabel
            // 
            this.numberLabel.AutoSize = true;
            this.numberLabel.Location = new System.Drawing.Point(23, 191);
            this.numberLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(145, 17);
            this.numberLabel.TabIndex = 22;
            this.numberLabel.Text = "Short number to send";
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
            this.DestinationPort.Size = new System.Drawing.Size(105, 17);
            this.DestinationPort.TabIndex = 26;
            this.DestinationPort.Text = "DestinationPort";
            // 
            // convertableNumberBox
            // 
            this.convertableNumberBox.Location = new System.Drawing.Point(26, 219);
            this.convertableNumberBox.Margin = new System.Windows.Forms.Padding(4);
            this.convertableNumberBox.Name = "convertableNumberBox";
            this.convertableNumberBox.Size = new System.Drawing.Size(81, 22);
            this.convertableNumberBox.TabIndex = 27;
            // 
            // bergerLabel
            // 
            this.bergerLabel.AutoSize = true;
            this.bergerLabel.Location = new System.Drawing.Point(367, 263);
            this.bergerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bergerLabel.Name = "bergerLabel";
            this.bergerLabel.Size = new System.Drawing.Size(152, 17);
            this.bergerLabel.TabIndex = 28;
            this.bergerLabel.Text = "number in berger code";
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
            this.btnNegateOneBit.Location = new System.Drawing.Point(554, 254);
            this.btnNegateOneBit.Margin = new System.Windows.Forms.Padding(4);
            this.btnNegateOneBit.Name = "btnNegateOneBit";
            this.btnNegateOneBit.Size = new System.Drawing.Size(153, 28);
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
            this.btnSwapBits.Size = new System.Drawing.Size(153, 28);
            this.btnSwapBits.TabIndex = 31;
            this.btnSwapBits.Text = "Swap Bits";
            this.btnSwapBits.UseVisualStyleBackColor = true;
            this.btnSwapBits.Click += new System.EventHandler(this.btnSwapBits_Click);
            // 
            // btnCloseConnection
            // 
            this.btnCloseConnection.Location = new System.Drawing.Point(880, 254);
            this.btnCloseConnection.Margin = new System.Windows.Forms.Padding(4);
            this.btnCloseConnection.Name = "btnCloseConnection";
            this.btnCloseConnection.Size = new System.Drawing.Size(142, 28);
            this.btnCloseConnection.TabIndex = 32;
            this.btnCloseConnection.Text = "Close Connection";
            this.btnCloseConnection.UseVisualStyleBackColor = true;
            this.btnCloseConnection.Click += new System.EventHandler(this.btnCloseConnection_Click);
            // 
            // isNegatedLabel
            // 
            this.isNegatedLabel.AutoSize = true;
            this.isNegatedLabel.Location = new System.Drawing.Point(615, 290);
            this.isNegatedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.isNegatedLabel.Name = "isNegatedLabel";
            this.isNegatedLabel.Size = new System.Drawing.Size(38, 17);
            this.isNegatedLabel.TabIndex = 33;
            this.isNegatedLabel.Text = "false";
            // 
            // isSwapedLabel
            // 
            this.isSwapedLabel.AutoSize = true;
            this.isSwapedLabel.Location = new System.Drawing.Point(768, 286);
            this.isSwapedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.isSwapedLabel.Name = "isSwapedLabel";
            this.isSwapedLabel.Size = new System.Drawing.Size(38, 17);
            this.isSwapedLabel.TabIndex = 34;
            this.isSwapedLabel.Text = "false";
            // 
            // btnControlSum
            // 
            this.btnControlSum.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnControlSum.Location = new System.Drawing.Point(715, 307);
            this.btnControlSum.Margin = new System.Windows.Forms.Padding(4);
            this.btnControlSum.Name = "btnControlSum";
            this.btnControlSum.Size = new System.Drawing.Size(153, 28);
            this.btnControlSum.TabIndex = 35;
            this.btnControlSum.Text = "Include Control Sum";
            this.btnControlSum.UseVisualStyleBackColor = false;
            this.btnControlSum.Click += new System.EventHandler(this.btnControlSum_Click);
            // 
            // controlSumLabel
            // 
            this.controlSumLabel.AutoSize = true;
            this.controlSumLabel.Location = new System.Drawing.Point(768, 343);
            this.controlSumLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.controlSumLabel.Name = "controlSumLabel";
            this.controlSumLabel.Size = new System.Drawing.Size(38, 17);
            this.controlSumLabel.TabIndex = 36;
            this.controlSumLabel.Text = "false";
            // 
            // isConnectionClosedLabel
            // 
            this.isConnectionClosedLabel.AutoSize = true;
            this.isConnectionClosedLabel.Location = new System.Drawing.Point(938, 286);
            this.isConnectionClosedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.isConnectionClosedLabel.Name = "isConnectionClosedLabel";
            this.isConnectionClosedLabel.Size = new System.Drawing.Size(38, 17);
            this.isConnectionClosedLabel.TabIndex = 37;
            this.isConnectionClosedLabel.Text = "false";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 369);
            this.Controls.Add(this.isConnectionClosedLabel);
            this.Controls.Add(this.controlSumLabel);
            this.Controls.Add(this.btnControlSum);
            this.Controls.Add(this.isSwapedLabel);
            this.Controls.Add(this.isNegatedLabel);
            this.Controls.Add(this.btnCloseConnection);
            this.Controls.Add(this.btnSwapBits);
            this.Controls.Add(this.btnNegateOneBit);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.bergerLabel);
            this.Controls.Add(this.convertableNumberBox);
            this.Controls.Add(this.DestinationPort);
            this.Controls.Add(this.connectionsLabel);
            this.Controls.Add(this.logsLabel);
            this.Controls.Add(this.Connections);
            this.Controls.Add(this.numberLabel);
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
        private System.ComponentModel.BackgroundWorker recieverWorker;
        private System.ComponentModel.BackgroundWorker senderWorker;
        private System.Windows.Forms.TextBox txtMSG;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.ListBox Connections;
        private System.Windows.Forms.Label logsLabel;
        private System.Windows.Forms.Label connectionsLabel;
        private System.Windows.Forms.Label DestinationPort;
        private System.Windows.Forms.TextBox convertableNumberBox;
        private System.Windows.Forms.Label bergerLabel;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnNegateOneBit;
        private System.Windows.Forms.Button btnSwapBits;
        private Button btnCloseConnection;
        private Label isNegatedLabel;
        private Label isSwapedLabel;
        private Button btnControlSum;
        private Label controlSumLabel;
        private Label isConnectionClosedLabel;
    }
}

