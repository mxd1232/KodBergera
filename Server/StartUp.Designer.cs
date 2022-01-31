
namespace Server
{
    partial class StartUp
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
            this.startProgram = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startProgram
            // 
            this.startProgram.Location = new System.Drawing.Point(53, 37);
            this.startProgram.Name = "startProgram";
            this.startProgram.Size = new System.Drawing.Size(271, 91);
            this.startProgram.TabIndex = 0;
            this.startProgram.Text = "Start Program";
            this.startProgram.UseVisualStyleBackColor = true;
            this.startProgram.Click += new System.EventHandler(this.startProgram_Click);
            // 
            // StartUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 179);
            this.Controls.Add(this.startProgram);
            this.Name = "StartUp";
            this.Text = "StartUp";
            this.Load += new System.EventHandler(this.StartUp_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startProgram;
    }
}