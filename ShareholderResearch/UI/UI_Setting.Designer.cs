namespace ShareholderResearch.UI
{
    partial class UI_Setting
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
            this.panelLeftFunction = new System.Windows.Forms.Panel();
            this.uI_OptionDatabase = new ShareholderResearch.UI.UI_Option();
            this.panelClient = new System.Windows.Forms.Panel();
            this.panelLeftFunction.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeftFunction
            // 
            this.panelLeftFunction.Controls.Add(this.uI_OptionDatabase);
            this.panelLeftFunction.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftFunction.Location = new System.Drawing.Point(0, 30);
            this.panelLeftFunction.Name = "panelLeftFunction";
            this.panelLeftFunction.Padding = new System.Windows.Forms.Padding(5);
            this.panelLeftFunction.Size = new System.Drawing.Size(180, 420);
            this.panelLeftFunction.TabIndex = 2;
            // 
            // uI_OptionDatabase
            // 
            this.uI_OptionDatabase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.uI_OptionDatabase.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.uI_OptionDatabase.BackgroundColorHOver = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.uI_OptionDatabase.Dock = System.Windows.Forms.DockStyle.Top;
            this.uI_OptionDatabase.Icon = global::ShareholderResearch.Properties.Resources.databaseNormal;
            this.uI_OptionDatabase.IconHOver = global::ShareholderResearch.Properties.Resources.databaseHOver;
            this.uI_OptionDatabase.Location = new System.Drawing.Point(5, 5);
            this.uI_OptionDatabase.Name = "uI_OptionDatabase";
            this.uI_OptionDatabase.OptionText = "Database";
            this.uI_OptionDatabase.OptionTextForecolor = System.Drawing.Color.Gray;
            this.uI_OptionDatabase.OptionTextForecolorHOver = System.Drawing.Color.Silver;
            this.uI_OptionDatabase.Padding = new System.Windows.Forms.Padding(2);
            this.uI_OptionDatabase.Size = new System.Drawing.Size(170, 31);
            this.uI_OptionDatabase.TabIndex = 0;
            // 
            // panelClient
            // 
            this.panelClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.panelClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelClient.Location = new System.Drawing.Point(180, 30);
            this.panelClient.Name = "panelClient";
            this.panelClient.Size = new System.Drawing.Size(470, 420);
            this.panelClient.TabIndex = 3;
            // 
            // UI_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelClient);
            this.Controls.Add(this.panelLeftFunction);
            this.Icon = global::ShareholderResearch.Properties.Resources.setting;
            this.Name = "UI_Setting";
            this.Size = new System.Drawing.Size(650, 450);
            this.Title = "设置";
            this.Controls.SetChildIndex(this.panelLeftFunction, 0);
            this.Controls.SetChildIndex(this.panelClient, 0);
            this.panelLeftFunction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLeftFunction;
        private System.Windows.Forms.Panel panelClient;
        private UI_Option uI_OptionDatabase;
    }
}
