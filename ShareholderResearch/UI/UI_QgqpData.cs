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
    public partial class UI_QgqpData : UserControl
    {
        private string selectedStockCode;
        public int minimumHeight = 135;

        public UI_QgqpData()
        {
            InitializeComponent();
        }

        public UI_QgqpData(double proMin, double proMax, int count)
            :this()
        {
            labelTitle.Text = $"机构参与度 >= {proMin}% and <= {proMax}% ({count})";
        }

        public UI_QgqpData(string title)
            : this()
        {
            labelTitle.Text = title;
        }

        public void FillData(List<StockCommentList> data)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.AllowUserToAddRows = true;
            foreach (var record in data)
            {
                dataGridView1.Rows.Add(
                    record.Tradecode,
                    record.Stockname,
                    record.Jgcyd,
                    record.Zljlr,
                    record.Tradedate
                    );
            }
            dataGridView1.AllowUserToAddRows = false;
            ColorRows();
        }

        public void ColorRows()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                var flow = Convert.ToInt64(dataGridView1["ColumnZLJLR", i].Value);
                dataGridView1.Rows[i].DefaultCellStyle.ForeColor = flow > 0 ? Color.Red : Color.Green;
            }
        }

        private void label_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void QianguqianPingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Parent != null)
            {
                (this.TopLevelControl as MainForm).DisplayLoadingUI(true);
                (this.TopLevelControl as MainForm).OpenInWebBrowser($"http://data.eastmoney.com/stockcomment/stock/" + selectedStockCode + ".html");
            }
            if (this.Parent != null)
            {
                (this.TopLevelControl as MainForm).DisplayLoadingUI(true);
                (this.TopLevelControl as MainForm).OpenInWebBrowser($"http://data.eastmoney.com/stockcomment/stock/" + selectedStockCode + ".html");
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            int idx = e.RowIndex;
            if (idx > -1)
            {
                selectedStockCode = dataGridView1["ColumnCode", idx].Value.ToString();
            }
        }

        private void KCurveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Parent != null)
            {
                (this.TopLevelControl as MainForm).DisplayLoadingUI(true);
                var code = (selectedStockCode.StartsWith("0") ? "sz" : "sh") + selectedStockCode;
                // var code = selectedStockCode;
                (this.TopLevelControl as MainForm).OpenInWebBrowser(SystemSetting.kCurve + code + ".html");
            }
        }

        private void Top10ShareholderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Parent != null)
            {
                (this.TopLevelControl as MainForm).DisplayLoadingUI(true);
                (this.TopLevelControl as MainForm).OpenInWebBrowser("http://emweb.securities.eastmoney.com/ShareholderResearch/Index?type=web&code=" + (selectedStockCode.StartsWith("6")?"sh":"sz")+ selectedStockCode);
            }
        }
    }
}
