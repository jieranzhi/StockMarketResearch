namespace ShareholderResearch.Views
{
    partial class UI_QgqpData
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label_close = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnJGCYD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnZLJLR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTRADEDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Top10ShareholderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QianguqianPingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KCurveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 30);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ShareholderResearch.Properties.Resources.center_focus_24px_1223635_easyicon_net;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 23);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.Silver;
            this.labelTitle.Location = new System.Drawing.Point(33, 6);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(45, 17);
            this.labelTitle.TabIndex = 4;
            this.labelTitle.Text = "label1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label_close);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(627, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(20, 30);
            this.panel3.TabIndex = 3;
            // 
            // label_close
            // 
            this.label_close.AutoSize = true;
            this.label_close.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_close.ForeColor = System.Drawing.Color.Silver;
            this.label_close.Location = new System.Drawing.Point(3, 6);
            this.label_close.Name = "label_close";
            this.label_close.Size = new System.Drawing.Size(16, 17);
            this.label_close.TabIndex = 2;
            this.label_close.Text = "X";
            this.label_close.Click += new System.EventHandler(this.label_close_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.panel2.Size = new System.Drawing.Size(647, 221);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCode,
            this.ColumnStockName,
            this.ColumnJGCYD,
            this.ColumnZLJLR,
            this.ColumnTRADEDATE});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(1, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(645, 220);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            // 
            // ColumnCode
            // 
            this.ColumnCode.HeaderText = "股票代码";
            this.ColumnCode.Name = "ColumnCode";
            this.ColumnCode.ReadOnly = true;
            // 
            // ColumnStockName
            // 
            this.ColumnStockName.HeaderText = "股票名称";
            this.ColumnStockName.Name = "ColumnStockName";
            this.ColumnStockName.ReadOnly = true;
            // 
            // ColumnJGCYD
            // 
            this.ColumnJGCYD.FillWeight = 110F;
            this.ColumnJGCYD.HeaderText = "机构参与度(%)";
            this.ColumnJGCYD.Name = "ColumnJGCYD";
            this.ColumnJGCYD.ReadOnly = true;
            this.ColumnJGCYD.Width = 110;
            // 
            // ColumnZLJLR
            // 
            this.ColumnZLJLR.HeaderText = "主力净流入(元)";
            this.ColumnZLJLR.Name = "ColumnZLJLR";
            this.ColumnZLJLR.ReadOnly = true;
            this.ColumnZLJLR.Width = 125;
            // 
            // ColumnTRADEDATE
            // 
            this.ColumnTRADEDATE.HeaderText = "数据日期";
            this.ColumnTRADEDATE.Name = "ColumnTRADEDATE";
            this.ColumnTRADEDATE.ReadOnly = true;
            this.ColumnTRADEDATE.Width = 200;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Top10ShareholderToolStripMenuItem,
            this.QianguqianPingToolStripMenuItem,
            this.KCurveToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(173, 70);
            // 
            // Top10ShareholderToolStripMenuItem
            // 
            this.Top10ShareholderToolStripMenuItem.Name = "Top10ShareholderToolStripMenuItem";
            this.Top10ShareholderToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.Top10ShareholderToolStripMenuItem.Text = "查询是大流通股东";
            this.Top10ShareholderToolStripMenuItem.Click += new System.EventHandler(this.Top10ShareholderToolStripMenuItem_Click);
            // 
            // QianguqianPingToolStripMenuItem
            // 
            this.QianguqianPingToolStripMenuItem.Name = "QianguqianPingToolStripMenuItem";
            this.QianguqianPingToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.QianguqianPingToolStripMenuItem.Text = "千股千评";
            this.QianguqianPingToolStripMenuItem.Click += new System.EventHandler(this.QianguqianPingToolStripMenuItem_Click);
            // 
            // KCurveToolStripMenuItem
            // 
            this.KCurveToolStripMenuItem.Name = "KCurveToolStripMenuItem";
            this.KCurveToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.KCurveToolStripMenuItem.Text = "看K线";
            this.KCurveToolStripMenuItem.Click += new System.EventHandler(this.KCurveToolStripMenuItem_Click);
            // 
            // UI_QgqpData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UI_QgqpData";
            this.Size = new System.Drawing.Size(647, 251);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label_close;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem QianguqianPingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem KCurveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Top10ShareholderToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnJGCYD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnZLJLR;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTRADEDATE;
    }
}
