namespace ShareholderResearch.UI
{
    partial class UI_TopTenShareholder
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_close = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView_top10shareholderqueryresult = new System.Windows.Forms.DataGridView();
            this.ColumnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNetAssetPerShare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNetProfit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnShareholderType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRanking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNumberOfShare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPercentageOfTotalStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPercentageOfChange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenInEMWEBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qianguqianpingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KCurveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_top10shareholderqueryresult)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1127, 31);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label_close);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1107, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 31);
            this.panel2.TabIndex = 2;
            // 
            // label_close
            // 
            this.label_close.AutoSize = true;
            this.label_close.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_close.ForeColor = System.Drawing.Color.Silver;
            this.label_close.Location = new System.Drawing.Point(3, 7);
            this.label_close.Name = "label_close";
            this.label_close.Size = new System.Drawing.Size(16, 17);
            this.label_close.TabIndex = 2;
            this.label_close.Text = "X";
            this.label_close.Click += new System.EventHandler(this.label_close_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTitle.ForeColor = System.Drawing.Color.Silver;
            this.labelTitle.Location = new System.Drawing.Point(36, 7);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(45, 17);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ShareholderResearch.Properties.Resources.target;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(1, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 27);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridView_top10shareholderqueryresult
            // 
            this.dataGridView_top10shareholderqueryresult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_top10shareholderqueryresult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDate,
            this.ColumnStockCode,
            this.ColumnStockName,
            this.ColumnNetAssetPerShare,
            this.ColumnNetProfit,
            this.ColumnShareholderType,
            this.ColumnRanking,
            this.ColumnNumberOfShare,
            this.ColumnPercentageOfTotalStock,
            this.ColumnStatus,
            this.ColumnPercentageOfChange});
            this.dataGridView_top10shareholderqueryresult.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView_top10shareholderqueryresult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_top10shareholderqueryresult.Location = new System.Drawing.Point(1, 33);
            this.dataGridView_top10shareholderqueryresult.Name = "dataGridView_top10shareholderqueryresult";
            this.dataGridView_top10shareholderqueryresult.RowHeadersVisible = false;
            this.dataGridView_top10shareholderqueryresult.RowTemplate.Height = 23;
            this.dataGridView_top10shareholderqueryresult.Size = new System.Drawing.Size(1127, 101);
            this.dataGridView_top10shareholderqueryresult.TabIndex = 1;
            this.dataGridView_top10shareholderqueryresult.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_top10shareholderqueryresult_CellMouseDown);
            // 
            // ColumnDate
            // 
            this.ColumnDate.HeaderText = "日期";
            this.ColumnDate.Name = "ColumnDate";
            this.ColumnDate.ReadOnly = true;
            // 
            // ColumnStockCode
            // 
            this.ColumnStockCode.HeaderText = "股票代码";
            this.ColumnStockCode.Name = "ColumnStockCode";
            this.ColumnStockCode.ReadOnly = true;
            // 
            // ColumnStockName
            // 
            this.ColumnStockName.HeaderText = "股票名称";
            this.ColumnStockName.Name = "ColumnStockName";
            this.ColumnStockName.ReadOnly = true;
            // 
            // ColumnNetAssetPerShare
            // 
            this.ColumnNetAssetPerShare.HeaderText = "每股净资产(元)";
            this.ColumnNetAssetPerShare.Name = "ColumnNetAssetPerShare";
            this.ColumnNetAssetPerShare.ReadOnly = true;
            this.ColumnNetAssetPerShare.Width = 120;
            // 
            // ColumnNetProfit
            // 
            this.ColumnNetProfit.HeaderText = "净利率(%)";
            this.ColumnNetProfit.Name = "ColumnNetProfit";
            this.ColumnNetProfit.ReadOnly = true;
            // 
            // ColumnShareholderType
            // 
            this.ColumnShareholderType.HeaderText = "股东性质";
            this.ColumnShareholderType.Name = "ColumnShareholderType";
            this.ColumnShareholderType.ReadOnly = true;
            this.ColumnShareholderType.Width = 80;
            // 
            // ColumnRanking
            // 
            this.ColumnRanking.HeaderText = "名次";
            this.ColumnRanking.Name = "ColumnRanking";
            // 
            // ColumnNumberOfShare
            // 
            this.ColumnNumberOfShare.HeaderText = "持股数(股)";
            this.ColumnNumberOfShare.Name = "ColumnNumberOfShare";
            this.ColumnNumberOfShare.ReadOnly = true;
            // 
            // ColumnPercentageOfTotalStock
            // 
            this.ColumnPercentageOfTotalStock.HeaderText = "占总流通股本持股比例";
            this.ColumnPercentageOfTotalStock.Name = "ColumnPercentageOfTotalStock";
            this.ColumnPercentageOfTotalStock.ReadOnly = true;
            this.ColumnPercentageOfTotalStock.Width = 200;
            // 
            // ColumnStatus
            // 
            this.ColumnStatus.HeaderText = "增减(股)";
            this.ColumnStatus.Name = "ColumnStatus";
            this.ColumnStatus.ReadOnly = true;
            // 
            // ColumnPercentageOfChange
            // 
            this.ColumnPercentageOfChange.HeaderText = "变动比例";
            this.ColumnPercentageOfChange.Name = "ColumnPercentageOfChange";
            this.ColumnPercentageOfChange.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenInEMWEBToolStripMenuItem,
            this.qianguqianpingToolStripMenuItem,
            this.KCurveToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(173, 70);
            // 
            // OpenInEMWEBToolStripMenuItem
            // 
            this.OpenInEMWEBToolStripMenuItem.Name = "OpenInEMWEBToolStripMenuItem";
            this.OpenInEMWEBToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.OpenInEMWEBToolStripMenuItem.Text = "查询是大流通股东";
            this.OpenInEMWEBToolStripMenuItem.Click += new System.EventHandler(this.OpenInEMWEBToolStripMenuItem_Click);
            // 
            // qianguqianpingToolStripMenuItem
            // 
            this.qianguqianpingToolStripMenuItem.Name = "qianguqianpingToolStripMenuItem";
            this.qianguqianpingToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.qianguqianpingToolStripMenuItem.Text = "千股千评";
            this.qianguqianpingToolStripMenuItem.Click += new System.EventHandler(this.qianguqianpingToolStripMenuItem_Click);
            // 
            // KCurveToolStripMenuItem
            // 
            this.KCurveToolStripMenuItem.Name = "KCurveToolStripMenuItem";
            this.KCurveToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.KCurveToolStripMenuItem.Text = "看K线";
            this.KCurveToolStripMenuItem.Click += new System.EventHandler(this.KCurveToolStripMenuItem_Click);
            // 
            // UI_TopTenShareholder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.dataGridView_top10shareholderqueryresult);
            this.Controls.Add(this.panel1);
            this.Name = "UI_TopTenShareholder";
            this.Padding = new System.Windows.Forms.Padding(1, 2, 1, 1);
            this.Size = new System.Drawing.Size(1129, 135);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_top10shareholderqueryresult)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView_top10shareholderqueryresult;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label_close;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem OpenInEMWEBToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNetAssetPerShare;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNetProfit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnShareholderType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRanking;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNumberOfShare;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPercentageOfTotalStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPercentageOfChange;
        private System.Windows.Forms.ToolStripMenuItem qianguqianpingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem KCurveToolStripMenuItem;
    }
}
