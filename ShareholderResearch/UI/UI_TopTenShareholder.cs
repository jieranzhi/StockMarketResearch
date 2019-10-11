using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShareholderResearch.Model;

namespace ShareholderResearch.UI
{
    public partial class UI_TopTenShareholder : UserControl
    {
        public int minimumHeight = 135;
        public string selectedStockCode = "";

        public UI_TopTenShareholder()
        {
            InitializeComponent();
        }
        
        public void SetShareholderInfo(string info)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(SetShareholderInfo), new object[] { info });
                return;
            }
            this.labelTitle.Text = info;
        }

        public void PopulateDataInTable(TopTenShareholder shareholder)
        {
            SetShareholderInfo(shareholder.shareholderName);
            dataGridView_top10shareholderqueryresult.AllowUserToAddRows = true;
            foreach (ShareHoldingRecord record in shareholder.lstShareHoldingRecord)
            {
                dataGridView_top10shareholderqueryresult.Rows.Add(
                    record.dateOfRecord,
                    record.stockCode,
                    record.stockName,
                    record.financialReport.netAssetsPerShare,
                    record.financialReport.netProfitRate,
                    record.shareholderType,
                    record.ranking,
                    record.numberOfShares,
                    record.percentageOfTotalTradableShares,
                    record.statusChange,
                    record.changeRate
                    );
            }
            dataGridView_top10shareholderqueryresult.AllowUserToAddRows = false;
        }

        private void label_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void OpenInEMWEBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Parent != null)
            {
                (this.TopLevelControl as MainForm).DisplayLoadingUI(true);
                (this.TopLevelControl as MainForm).OpenInWebBrowser("http://emweb.securities.eastmoney.com/ShareholderResearch/Index?type=web&code=" + selectedStockCode);
            }
        }

        private void dataGridView_top10shareholderqueryresult_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            int idx = e.RowIndex;
            if (idx > -1)
            {
                selectedStockCode = dataGridView_top10shareholderqueryresult["ColumnStockCode", idx].Value.ToString();
                dataGridView_top10shareholderqueryresult.ClearSelection();
                dataGridView_top10shareholderqueryresult.SuspendLayout();
                dataGridView_top10shareholderqueryresult.Rows[idx].Selected = true;
                dataGridView_top10shareholderqueryresult.ResumeLayout();
            }
        }

        private void qianguqianpingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Parent != null)
            {
                (this.TopLevelControl as MainForm).DisplayLoadingUI(true);
                (this.TopLevelControl as MainForm).OpenInWebBrowser($"http://data.eastmoney.com/stockcomment/stock/"+selectedStockCode.Substring(2)+".html");
            }
        }

        private void KCurveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Parent != null)
            {
                (this.TopLevelControl as MainForm).DisplayLoadingUI(true);
                // var code = selectedStockCode.ToLower().Replace("sz", "").Replace("sh", "");
                var code = selectedStockCode;
                (this.TopLevelControl as MainForm).OpenInWebBrowser(SystemSetting.kCurve + code + ".html");
            }
        }
    }
}
