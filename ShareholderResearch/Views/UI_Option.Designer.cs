namespace ShareholderResearch.Views
{
    partial class UI_Option
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.panelClient = new System.Windows.Forms.Panel();
            this.labelOptionText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.panelClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxIcon.Location = new System.Drawing.Point(3, 6);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxIcon.TabIndex = 0;
            this.pictureBoxIcon.TabStop = false;
            this.pictureBoxIcon.MouseEnter += new System.EventHandler(this.UIOption_MouseEnter);
            this.pictureBoxIcon.MouseLeave += new System.EventHandler(this.UIOption_MouseLeave);
            // 
            // panelClient
            // 
            this.panelClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panelClient.Controls.Add(this.labelOptionText);
            this.panelClient.Controls.Add(this.pictureBoxIcon);
            this.panelClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelClient.Location = new System.Drawing.Point(1, 1);
            this.panelClient.Name = "panelClient";
            this.panelClient.Size = new System.Drawing.Size(148, 29);
            this.panelClient.TabIndex = 1;
            this.panelClient.MouseEnter += new System.EventHandler(this.UIOption_MouseEnter);
            this.panelClient.MouseLeave += new System.EventHandler(this.UIOption_MouseLeave);
            // 
            // labelOptionText
            // 
            this.labelOptionText.AutoSize = true;
            this.labelOptionText.BackColor = System.Drawing.Color.Transparent;
            this.labelOptionText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelOptionText.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelOptionText.ForeColor = System.Drawing.Color.Silver;
            this.labelOptionText.Location = new System.Drawing.Point(29, 8);
            this.labelOptionText.Name = "labelOptionText";
            this.labelOptionText.Size = new System.Drawing.Size(47, 12);
            this.labelOptionText.TabIndex = 1;
            this.labelOptionText.Text = "label1";
            this.labelOptionText.MouseEnter += new System.EventHandler(this.UIOption_MouseEnter);
            this.labelOptionText.MouseLeave += new System.EventHandler(this.UIOption_MouseLeave);
            // 
            // UI_Option
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.panelClient);
            this.Name = "UI_Option";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(150, 31);
            this.Load += new System.EventHandler(this.UI_Option_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.panelClient.ResumeLayout(false);
            this.panelClient.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Panel panelClient;
        private System.Windows.Forms.Label labelOptionText;
    }
}
