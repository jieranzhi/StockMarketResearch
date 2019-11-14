using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Data.SQLite;
using ShareholderResearch.Utils;
using ShareholderResearch.Models;
using ShareholderResearch.Views;

namespace ShareholderResearch
{
    public partial class MainForm : Form
    {
        // systemm ui
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CAPTION = 0x2;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        const UInt32 HTBOTTOMRIGHT = 17;
        const UInt32 HTBOTTOM = 15;
        const int RESIZE_HANDLE_SIZE = 10;

        private string selectedStockCode;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
            {
                Size formSize = Size;
                Point screenPoint = new Point(m.LParam.ToInt32());
                Point clientPoint = PointToClient(screenPoint);
                Rectangle hitBox = new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE);
                Rectangle hitBottomBox = new Rectangle(0, formSize.Height - RESIZE_HANDLE_SIZE, formSize.Width - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE);
                if (hitBox.Contains(clientPoint))
                {
                    m.Result = (IntPtr)HTBOTTOMRIGHT;
                }
                else if (hitBottomBox.Contains(clientPoint))
                {
                    m.Result = (IntPtr)HTBOTTOM;
                }
                else
                {
                    m.Result = (IntPtr)(HT_CAPTION);
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        //// FUNCTIONS ////
        private string JsonEscape(string oriJson)
        {
            return oriJson.Replace(@"\u0027", "-");
        }

        private void QueryAndDisplayTopTenShareholder(string name)
        {
            try
            {
                SQLiteDataReader reader = DatabaseHelper.QueryByShareholderName(name);
                if (reader.HasRows)
                {
                    TopTenShareholder topTenShareholder = new TopTenShareholder(name);
                    while (reader.Read())
                    {
                        try
                        {
                            ShareHoldingRecord record = new ShareHoldingRecord()
                            {
                                dateOfRecord = DatabaseHelper.ColumnExists(reader, "dateOfRecord") ? reader["dateOfRecord"].ToString() : "",
                                ranking = DatabaseHelper.ColumnExists(reader, "ranking") ? reader["ranking"].ToString() : "",
                                stockCode = DatabaseHelper.ColumnExists(reader, "stockCode") ? reader["stockCode"].ToString() : "",
                                stockName = DatabaseHelper.ColumnExists(reader, "stockName") ? reader["stockName"].ToString() : "",
                                shareholderType = DatabaseHelper.ColumnExists(reader, "shareholderType") ? reader["shareholderType"].ToString() : "",
                                shareType = DatabaseHelper.ColumnExists(reader, "shareType") ? reader["shareType"].ToString() : "",
                                numberOfShares = DatabaseHelper.ColumnExists(reader, "numberOfShares") ? reader["numberOfShares"].ToString() : "",
                                percentageOfTotalTradableShares = DatabaseHelper.ColumnExists(reader, "percentageOfTotalTradableShares") ? reader["percentageOfTotalTradableShares"].ToString() : "",
                                statusChange = DatabaseHelper.ColumnExists(reader, "statusChange") ? reader["statusChange"].ToString() : "",
                                changeRate = DatabaseHelper.ColumnExists(reader, "changeRate") ? reader["changeRate"].ToString() : "",
                                financialReport = new FinancialReport()
                                {
                                    stockCode = DatabaseHelper.ColumnExists(reader, "stockCode") ? reader["stockCode"].ToString() : "",
                                    dateOfRecord = DatabaseHelper.ColumnExists(reader, "dateOfRecord") ? reader["dateOfRecord"].ToString() : "",
                                    basicProfitPerShare = DatabaseHelper.ColumnExists(reader, "basicProfitPerShare") ? reader["basicProfitPerShare"].ToString() : "",
                                    netAssetsPerShare = DatabaseHelper.ColumnExists(reader, "netAssetsPerShare") ? reader["netAssetsPerShare"].ToString() : "",
                                    providentFundPerShare = DatabaseHelper.ColumnExists(reader, "providentFundPerShare") ? reader["providentFundPerShare"].ToString() : "",
                                    undistributedProfitPerShare = DatabaseHelper.ColumnExists(reader, "undistributedProfitPerShare") ? reader["undistributedProfitPerShare"].ToString() : "",
                                    cashFlowPerShare = DatabaseHelper.ColumnExists(reader, "cashFlowPerShare") ? reader["cashFlowPerShare"].ToString() : "",
                                    totalOperatingIncome = DatabaseHelper.ColumnExists(reader, "totalOperatingIncome") ? reader["totalOperatingIncome"].ToString() : "",
                                    grossProfit = DatabaseHelper.ColumnExists(reader, "grossProfit") ? reader["grossProfit"].ToString() : "",
                                    netProfitAttributable = DatabaseHelper.ColumnExists(reader, "netProfitAttributable") ? reader["netProfitAttributable"].ToString() : "",
                                    deductionOfNonNetProfit = DatabaseHelper.ColumnExists(reader, "deductionOfNonNetProfit") ? reader["deductionOfNonNetProfit"].ToString() : "",
                                    totalOperatingIncomeYearOnYearGrowth = DatabaseHelper.ColumnExists(reader, "totalOperatingIncomeYearOnYearGrowth") ? reader["totalOperatingIncomeYearOnYearGrowth"].ToString() : "",
                                    netProfitAttributableYearOnYearGrowth = DatabaseHelper.ColumnExists(reader, "netProfitAttributableYearOnYearGrowth") ? reader["netProfitAttributableYearOnYearGrowth"].ToString() : "",
                                    deductionOfNonNetProfitYearOnYearGrowth = DatabaseHelper.ColumnExists(reader, "deductionOfNonNetProfitYearOnYearGrowth") ? reader["deductionOfNonNetProfitYearOnYearGrowth"].ToString() : "",
                                    totalOperatingIncomeRingGrowth = DatabaseHelper.ColumnExists(reader, "totalOperatingIncomeRingGrowth") ? reader["totalOperatingIncomeRingGrowth"].ToString() : "",
                                    netProfitAttributableRingGrowth = DatabaseHelper.ColumnExists(reader, "netProfitAttributableRingGrowth") ? reader["netProfitAttributableRingGrowth"].ToString() : "",
                                    deductionOfNonNetProfitRingGrowth = DatabaseHelper.ColumnExists(reader, "deductionOfNonNetProfitRingGrowth") ? reader["deductionOfNonNetProfitRingGrowth"].ToString() : "",
                                    dilutedReturnOnEquity = DatabaseHelper.ColumnExists(reader, "dilutedReturnOnEquity") ? reader["dilutedReturnOnEquity"].ToString() : "",
                                    dilutedReturnOnTotalAssets = DatabaseHelper.ColumnExists(reader, "dilutedReturnOnTotalAssets") ? reader["dilutedReturnOnTotalAssets"].ToString() : "",
                                    grossMargin = DatabaseHelper.ColumnExists(reader, "grossMargin") ? reader["grossMargin"].ToString() : "",
                                    netProfitRate = DatabaseHelper.ColumnExists(reader, "netProfitRate") ? reader["netProfitRate"].ToString() : ""
                                }
                            };
                            topTenShareholder.lstShareHoldingRecord.Add(record);
                        }
                        catch (Exception ex)
                        {
                            SystemSetting.LogAndDisplayError(ex, "MainForm.cs, line 114");
                        }
                    }
                    if (topTenShareholder.lstShareHoldingRecord.Count > 0)
                    {
                        Views.UI_TopTenShareholder ui = new Views.UI_TopTenShareholder();
                        ui.PopulateDataInTable(topTenShareholder);
                        int heightIntend = (topTenShareholder.lstShareHoldingRecord.Count + 2) * 23 + 38;
                        ui.Height = heightIntend < ui.minimumHeight ? ui.minimumHeight : heightIntend;

                        ui.Dock = DockStyle.Top;
                        this.panel_main.Controls.Add(ui);
                    }
                }
                else
                {
                    MessageBox.Show("未找到记录值！");
                }
            }
            catch (Exception ex1)
            {
                SystemSetting.LogAndDisplayError(ex1, "MainForm.cs, line 124");
            }
        }

        private void UpdateShareholderListWithoutQuery(string name, int recordIndex)
        {
            try
            {
                listBox_shareholders.DataSource = null;
                if (name != "")
                {
                    var selection = SystemSetting.lstTopTenShareholder.Where(a => a.ToUpper().Contains(name.ToUpper()));
                    SystemSetting.lstTopTenShareholderDisplay = new BindingList<string>(selection.ToList());
                }
                else
                {
                    SystemSetting.lstTopTenShareholderDisplay = new BindingList<string>(SystemSetting.lstTopTenShareholder.Skip(recordIndex).Take(SystemSetting.recordCountPerPage).ToList());
                }
                listBox_shareholders.DataSource = SystemSetting.lstTopTenShareholderDisplay;
            }
            catch (Exception ex)
            { }
        }

        private void UpdateShareholderListWithoutQuery(int recordIndex)
        {
            try
            {
                listBox_shareholders.DataSource = null;
                SystemSetting.lstTopTenShareholderDisplay = new BindingList<string>(SystemSetting.lstTopTenShareholder.Skip(recordIndex).Take(SystemSetting.recordCountPerPage).ToList());
                listBox_shareholders.DataSource = SystemSetting.lstTopTenShareholderDisplay;
            }
            catch (Exception ex)
            { }
        }

        private void UpdateStockList(string queryCode)
        {
            try
            {
                SystemSetting.lstStockDisplay = new BindingList<string>();
                var reader = DatabaseHelper.QueryStockRecords(queryCode);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var displayText = reader["stockCode"] + "     " + reader["stockName"];
                        SystemSetting.lstStockDisplay.Add(displayText);
                    }
                    listBox_stock.DataSource = SystemSetting.lstStockDisplay;
                }
                else
                {
                    MessageBox.Show("未找到匹配记录！");
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void QueryQgqpData(string stockCode)
        {
            var reader = DatabaseHelper.QueryQGQPDataByStockCode(DatabaseHelper.SQLString(stockCode));
            if (reader.HasRows)
            {
                var commentList = new List<StockCommentList>();
                while (reader.Read())
                {
                    try
                    {
                        var record = new StockCommentList()
                        {
                            Tradecode = reader["TRADECODE"].ToString(),
                            Tradedate = Convert.ToDateTime(reader["TRADEDATE"].ToString()),
                            Stockname = reader["STOCKNAME"].ToString(),
                            Jgcyd = Convert.ToDouble(reader["JGCYD"].ToString()) * 100,
                            Zljlr = Convert.ToInt64(reader["ZLJLR"].ToString()),
                        };
                        commentList.Add(record);
                    }
                    catch (Exception ex)
                    {
                        SystemSetting.LogAndDisplayError(ex, "MainForm.cs, line 114");
                    }
                }
                if (commentList.Count > 0)
                {
                    var ui = new Views.UI_QgqpData(stockCode);
                    ui.FillData(commentList);
                    int heightIntend = (commentList.Count) * 40 + 48;
                    ui.Height = heightIntend;
                    ui.Dock = DockStyle.Top;
                    this.panel_main.Controls.Add(ui);
                }
            }
            else
            {
                MessageBox.Show("未找到记录值！");
            }
        }
        
        private void QueryQgqpData(double proMin, double proMax)
        {
            var reader = DatabaseHelper.QueryQGQPDataByMainControl(proMin, proMax);
            if (reader.HasRows)
            {
                var commentList = new List<StockCommentList>();
                while (reader.Read())
                {
                    try
                    {
                        var record = new StockCommentList()
                        {
                            Tradecode = reader["TRADECODE"].ToString(),
                            Tradedate = Convert.ToDateTime(reader["TRADEDATE"].ToString()),
                            Stockname = reader["STOCKNAME"].ToString(),
                            Jgcyd = Convert.ToDouble(reader["JGCYD"].ToString()) * 100,
                            Zljlr = Convert.ToInt64(reader["ZLJLR"].ToString()),
                        };
                        commentList.Add(record);
                    }
                    catch (Exception ex)
                    {
                        SystemSetting.LogAndDisplayError(ex, "MainForm.cs, line 114");
                    }
                }
                if (commentList.Count > 0)
                {
                    var ui = new Views.UI_QgqpData(proMin * 100, proMax * 100, commentList.Count);
                    ui.FillData(commentList);
                    int heightIntend = (commentList.Count + 2) * 23 + 38;
                    ui.Height = heightIntend < ui.minimumHeight ? ui.minimumHeight : heightIntend;
                    ui.Dock = DockStyle.Top;
                    this.panel_main.Controls.Add(ui);
                }
            }
            else
            {
                MessageBox.Show("未找到记录值！");
            }
        }

        private void LoadShareholderNameList()
        {
            try
            {
                SQLiteDataReader reader = DatabaseHelper.GetShareholderNameList();
                SystemSetting.lstTopTenShareholder = new List<string>();
                SystemSetting.lstTopTenShareholderDisplay = new BindingList<string>();
                listBox_shareholders.Items.Clear();
                while (reader.Read())
                {
                    try
                    {
                        SystemSetting.lstTopTenShareholder.Add(reader[0].ToString());
                        // SystemSetting.lstTopTenShareholderDisplay.Add(reader[0].ToString());
                    }
                    catch (Exception ex)
                    {
                        SystemSetting.LogAndDisplayError(ex, "MainForm.cs, line 142");
                    }
                }
                if (SystemSetting.lstTopTenShareholder.Count > 0)
                {
                    listBox_shareholders.SuspendLayout();
                    SystemSetting.lstTopTenShareholderDisplay = new BindingList<string>(SystemSetting.lstTopTenShareholder.Take(SystemSetting.recordCountPerPage).ToList());
                    listBox_shareholders.DataSource = SystemSetting.lstTopTenShareholderDisplay;
                    label_shareholderList.Text = $"股东列表（{SystemSetting.lstTopTenShareholder.Count}）";
                    var totalPageCount = (int)Math.Ceiling(SystemSetting.lstTopTenShareholder.Count * 1.0 / SystemSetting.recordCountPerPage);
                    var dataIndexArray = Enumerable.Range(1, totalPageCount).ToArray();
                    comboBox_paging.Items.Clear();
                    comboBox_paging.Items.AddRange(dataIndexArray.Cast<object>().ToArray());
                    comboBox_paging.SelectedIndex = 0;
                    listBox_shareholders.ResumeLayout();
                    listBox_shareholders.Invalidate();
                }
            }
            catch (Exception ex)
            {
                SystemSetting.LogAndDisplayError(ex, "MainForm.cs, line 138");
            }
        }

        public void OpenInWebBrowser(string url)
        {
            webBrowserInner.Navigate(url);
        }
        
        public void FetchStockList(IProgress<double> progress)
        {
            try
            {
                DataCollector dataCollector = new DataCollector();
                string rawStockList = dataCollector.GetHttpResponse(SystemSetting.stockListUrl, false).Result;
                List<string[]> lstStock = dataCollector.GetStockList(rawStockList); //dataCollector.GetStockList(rawStockList, SystemSetting.stockListMatchPattern);
                int dataCount = lstStock.Count;
                DatabaseHelper.ClearTable("stockList");
                int i = 0;
                foreach (string[] stock in lstStock)
                {
                    DatabaseHelper.UpdateStockList(stock[0], stock[1]);
                    i++;
                    progress.Report(100.0 * i / dataCount);
                }
            }
            catch (Exception ex)
            {
                SystemSetting.LogAndDisplayError(ex, "MainForm.cs, line 117");
            }
        }

        public void FetchTopTenShareholder(IProgress<double> progress)
        {
            try
            {
                int dataCount = DatabaseHelper.Get006030StockRecordCount("stockList");
                var reader = DatabaseHelper.GetAll006030StockRecords("stockList");
                var stockCodeList = new List<string>();
                while (reader.Read())
                {
                    stockCodeList.Add(reader[1].ToString());
                }
                var stockCodeTemp = "";
                if (stockCodeList.Any())
                {
                    var topTenShareholderList = new Dictionary<string, TopTenShareholderJsonPackage>();
                    int i = 0;
                    try
                    {
                        foreach (var stockCode in stockCodeList)
                        {
                            i++;
                            stockCodeTemp = stockCode;
                            var dataCollector = new DataCollector();
                            string rawTopTenShareHolder
                                = JsonEscape(dataCollector.GetHttpResponse(SystemSetting.rootUrlOfTopTenShareHolder + stockCode, false).Result);
                            var package = TopTenShareholderJsonParser.FromJson(rawTopTenShareHolder);
                            topTenShareholderList.Add(stockCode, package);
                            progress.Report(50.0 * i / dataCount);
                            Console.WriteLine($"{i}:{stockCode} --- {rawTopTenShareHolder}");
                        }
                    }
                    catch (Exception ex)
                    {
                        SystemSetting.LogAndDisplayError(ex, $"{stockCodeTemp} MainForm.cs, line 96");
                    }

                    try
                    {
                        i = 0;
                        if (topTenShareholderList.Any())
                        {
                            DatabaseHelper.OptimizationBegin();
                            foreach (var dicPackage in topTenShareholderList)
                            {
                                i++;
                                var stockCode = dicPackage.Key;
                                var package = dicPackage.Value;
                                stockCodeTemp = stockCode;
                                foreach (Sdltgd sdltgdItem in package.Sdltgd)
                                {
                                    foreach (var sdltgd in sdltgdItem.SdltgdSdltgd)
                                    {
                                        DatabaseHelper.UpdateTopTenStockholder(stockCode, sdltgd);
                                        Console.WriteLine($"{i}/{dataCount}:{stockCode} --- {sdltgd["gdmc"]}");
                                    }
                                }
                                progress.Report(50.0 * i / dataCount + 50);
                            }
                            DatabaseHelper.OptimizationEnd();
                        }
                    }
                    catch (Exception ex)
                    {
                        SystemSetting.LogAndDisplayError(ex, $"{stockCodeTemp} MainForm.cs, line 96");
                    }
                }
            }
            catch (Exception ex)
            {
                SystemSetting.LogAndDisplayError(ex, "MainForm.cs, line 102");
            }
        }

        public void FetchFinanceReportProgress(IProgress<double> progress)
        {
            try
            {
                int dataCount = DatabaseHelper.Get006030StockRecordCount("stockList");
                var reader = DatabaseHelper.GetAll006030StockRecords("stockList");
                int i = 0;
                while (reader.Read())
                {
                    string stockCode = reader[1].ToString();
                    try
                    {
                        i++;
                        DataCollector dataCollector = new DataCollector();
                        string rawFinantialReport = JsonEscape(dataCollector.GetHttpResponse(SystemSetting.rootUrlOfFinancialReport + stockCode, false).Result);
                        Console.WriteLine($"{i}:{stockCode} --- {rawFinantialReport}");
                        Dictionary<string, string>[] package = FinancialReportJsonParser.FromJson(rawFinantialReport);
                        foreach (Dictionary<string, string> report in package)
                        {
                            DatabaseHelper.UpdateFinancialReport(stockCode, report);
                        }
                        progress.Report(100.0 * i / dataCount);
                    }
                    catch (Exception ex0)
                    {
                        SystemSetting.LogAndDisplayError(ex0, $"{stockCode} MainForm.cs, line 169");
                    }
                }
            }
            catch (Exception ex)
            {
                SystemSetting.LogAndDisplayError(ex, "MainForm.cs, line 178");
            }
        }

        public void FetchQGQP(IProgress<double> progress)
        {
            try
            {
                int dataCount = DatabaseHelper.Get006030StockRecordCount("stockList");
                var reader = DatabaseHelper.GetAll006030StockRecords("stockList");
                // DatabaseHelper.ClearTable("qgqpData");
                int i = 0;
                while (reader.Read())
                {
                    string stockCode = reader[1].ToString().ToLower().Replace("sz","").Replace("sh","");
                    try
                    {
                        i++;
                        DataCollector dataCollector = new DataCollector();
                        string qgqpData = JsonEscape(dataCollector.GetHttpResponse(SystemSetting.stockQGQPURL.Replace("{code}", stockCode), false).Result);
                        Console.WriteLine($"{i}:{stockCode} --- {qgqpData}");
                        var package = StockCommentList.FromJson(qgqpData);
                        foreach (StockCommentList comment in package)
                        {
                            DatabaseHelper.UpdateQGQPData(stockCode, comment);
                        }
                        progress.Report(100.0 * i / dataCount);
                    }
                    catch (Exception ex0)
                    {
                        SystemSetting.LogAndDisplayError(ex0, $"{stockCode} MainForm.cs, line 169");
                    }
                }
            }
            catch (Exception ex)
            {
                SystemSetting.LogAndDisplayError(ex, "MainForm.cs, line 178");
            }
        }

        public void ManuallyFetchTopTenShareholder(IProgress<double> progress, string stockCode, string rawTopTenShareHolder)
        {
            try
            {
                TopTenShareholderJsonPackage package = TopTenShareholderJsonParser.FromJson(JsonEscape(rawTopTenShareHolder));
                int dataCount = 0;
                foreach (Sdltgd sdltgdItem in package.Sdltgd) { dataCount += sdltgdItem.SdltgdSdltgd.Length; }
                int i = 0;
                foreach (Sdltgd sdltgdItem in package.Sdltgd)
                {
                    foreach (Dictionary<String, string> sdltgd in sdltgdItem.SdltgdSdltgd)
                    {
                        DatabaseHelper.UpdateTopTenStockholder(stockCode, sdltgd);
                        i++;
                        progress.Report(100.0 * i / dataCount);
                    }
                }
            }
            catch (Exception ex)
            {
                SystemSetting.LogAndDisplayError(ex, "MainForm.cs, line 102");
            }
        }

        public void ManuallyFetchFinanceReportProgress(IProgress<double> progress, string stockCode, string rawFinancialReport)
        {
            try
            {
                int i = 0;
                Dictionary<string, string>[] package = FinancialReportJsonParser.FromJson(JsonEscape(rawFinancialReport));
                int dataCount = package.Length;
                foreach (Dictionary<string, string> report in package)
                {
                    DatabaseHelper.UpdateFinancialReport(stockCode, report);
                    i++;
                    progress.Report(100.0 * i / dataCount);
                }
            }
            catch (Exception ex)
            {
                SystemSetting.LogAndDisplayError(ex, "MainForm.cs, line 178");
            }
        }

        public void DisplayLoadingUI(bool display)
        {
            if (panel_webBrowser.Controls.OfType<Views.UI_Loading>().Any())
            {
                var uiLoading = (panel_webBrowser.Controls.OfType<Views.UI_Loading>().ElementAt(0) as Views.UI_Loading);
                uiLoading.Visible = display;
                uiLoading.BringToFront();
            }
            else
            {
                Views.UI_Loading uiLoading = new Views.UI_Loading();
                uiLoading.Visible = display;
                uiLoading.Dock = DockStyle.Fill;
                panel_webBrowser.Controls.Add(uiLoading);
                uiLoading.BringToFront();
            }
        }

        //// EVENTS ////

        private void Form1_Load(object sender, EventArgs e)
        {
            SystemSetting.systemDir = Environment.CurrentDirectory;
            SystemSetting.databaseFileDir = SystemSetting.systemDir + "\\record.db";
            SystemSetting.errorLogDir = SystemSetting.systemDir + "\\error_log\\";
            SystemSetting.CheckDirectory(SystemSetting.errorLogDir);
            DatabaseHelper.LoadDatabase();
            LoadShareholderNameList();
        }

        private void pictureBox_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void pictureBox_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox_maximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox_search_Click(object sender, EventArgs e)
        {
            string name = textBox_stockholdername.Text.Trim();
            QueryAndDisplayTopTenShareholder(name);
        }
        
        private void textBox_stockholdername_KeyUp(object sender, KeyEventArgs e)
        {
            string name = textBox_stockholdername.Text.Trim();
            if (e.KeyData == Keys.Enter)
            {
                QueryAndDisplayTopTenShareholder(name);
            }
            else
            {
                UpdateShareholderListWithoutQuery(name, 0);
            }
        }

        private void listBox_shareholders_DoubleClick(object sender, EventArgs e)
        {
            string name = listBox_shareholders.SelectedItem.ToString();
            QueryAndDisplayTopTenShareholder(name);
        }

        private void listBox_shareholders_Click(object sender, EventArgs e)
        {
            textBox_stockholdername.Text = listBox_shareholders.SelectedItem.ToString();
        }

        private void listBox_shareholders_DrawItem(object sender, DrawItemEventArgs e)
        {
            int index = e.Index;//获取当前要进行绘制的行的序号，从0开始。
            Graphics g = e.Graphics;//获取Graphics对象。
            Rectangle bound = e.Bounds;//获取当前要绘制的行的一个矩形范围。
            string text = SystemSetting.lstTopTenShareholderDisplay[index].ToString();//获取当前要绘制的行的显示文本。
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                //如果当前行为选中行。
                //绘制选中时要显示的蓝色边框。
                g.DrawRectangle(Pens.Gray, bound.Left, bound.Top, bound.Width - 1, bound.Height - 1);
                Rectangle rect = new Rectangle(bound.Left, bound.Top,
                                               bound.Width, bound.Height);
                //绘制选中时要显示的蓝色背景。
                g.FillRectangle(Brushes.Gray, rect);
                //绘制显示文本。
                TextRenderer.DrawText(g, text, this.Font, rect, Color.White,
                                  TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
            }
            else
            {   //GetBrush为自定义方法，根据当前的行号来选择Brush进行绘制。
                //using (Brush brush = GetBrush(e.Index))
                //{
                //    g.FillRectangle(brush, bound);//绘制背景色。
                //}
                //TextRenderer.DrawText(g, text, this.Font, bound, Color.OrangeRed,
                //                      TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
                e.DrawBackground();
                e.DrawFocusRectangle();
                e.Graphics.DrawString(SystemSetting.lstTopTenShareholderDisplay[e.Index],
                    new Font(FontFamily.GenericSansSerif, 9, FontStyle.Regular),
                    new SolidBrush(Color.OrangeRed), e.Bounds.X, e.Bounds.Y);
            }

            //e.DrawBackground();
            //e.DrawFocusRectangle();
            //e.Graphics.DrawString(SystemSetting.lstTopTenShareholderDisplay[e.Index],
            //    new Font(FontFamily.GenericSansSerif, 9, FontStyle.Regular),
            //    new SolidBrush(Color.OrangeRed), e.Bounds.X, e.Bounds.Y);
        }

        private void listBox_shareholders_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            var g = e.Graphics;
            var size = g.MeasureString(SystemSetting.lstTopTenShareholderDisplay[e.Index], this.Font, this.Width-5-SystemInformation.VerticalScrollBarWidth);
            e.ItemHeight = (int)size.Height + 15;
            e.ItemWidth = (int)size.Width + 15;
        }

        private void listBox_shareholders_SizeChanged(object sender, EventArgs e)
        {
            listBox_shareholders.Invalidate();
        }
        
        private void listBox_stock_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                int index = e.Index;//获取当前要进行绘制的行的序号，从0开始。
                Graphics g = e.Graphics;//获取Graphics对象。
                Rectangle bound = e.Bounds;//获取当前要绘制的行的一个矩形范围。
                string text = SystemSetting.lstStockDisplay[index].ToString();//获取当前要绘制的行的显示文本。
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    //如果当前行为选中行。
                    //绘制选中时要显示的蓝色边框。
                    g.DrawRectangle(Pens.Gray, bound.Left, bound.Top, bound.Width - 1, bound.Height - 1);
                    Rectangle rect = new Rectangle(bound.Left, bound.Top,
                                                   bound.Width, bound.Height);
                    //绘制选中时要显示的蓝色背景。
                    g.FillRectangle(Brushes.Gray, rect);
                    //绘制显示文本。
                    TextRenderer.DrawText(g, text, this.Font, rect, Color.Red,
                                      TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
                }
                else
                {   //GetBrush为自定义方法，根据当前的行号来选择Brush进行绘制。
                    //using (Brush brush = GetBrush(e.Index))
                    //{
                    //    g.FillRectangle(brush, bound);//绘制背景色。
                    //}
                    //TextRenderer.DrawText(g, text, this.Font, bound, Color.OrangeRed,
                    //                      TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
                    e.DrawBackground();
                    e.DrawFocusRectangle();
                    e.Graphics.DrawString(SystemSetting.lstStockDisplay[e.Index],
                        new Font(FontFamily.GenericSansSerif, 9, FontStyle.Regular),
                        new SolidBrush(Color.DarkRed), e.Bounds.X, e.Bounds.Y);
                }
            }
            catch(Exception ex)
            {
            }
        }

        private void listBox_stock_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            var g = e.Graphics;
            var size = g.MeasureString(SystemSetting.lstStockDisplay[e.Index], this.Font, this.Width - 5 - SystemInformation.VerticalScrollBarWidth);
            e.ItemHeight = (int)size.Height + 8;
            e.ItemWidth = (int)size.Width + 8;
        }

        private void textBox_stockquery_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                var queryCode = textBox_stockquery.Text.Trim();
                UpdateStockList(queryCode);
            }
        }

        private void listBox_stock_SizeChanged(object sender, EventArgs e)
        {
            listBox_stock.Invalidate();
        }

        private void listBox_stock_DoubleClick(object sender, EventArgs e)
        {
            string name = listBox_stock.SelectedItem.ToString();
            var codeArray = name.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var stockCode = codeArray[0].ToLower().Replace("sh","").Replace("sz","");
            QueryQgqpData(stockCode);
        }

        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            (sender as PictureBox).BorderStyle = BorderStyle.FixedSingle;
        }

        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            (sender as PictureBox).BorderStyle = BorderStyle.None;
        }

        private void pictureBox_uploadsocketlist_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox_uploadsocketlist, "更新股票列表");
        }

        private void pictureBox_update_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox_update, "更新十大流通股东数据库");
        }

        private void pictureBox_getfinancialreport_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox_getfinancialreport, "更新股票财务分析数据库");
        }

        private void pictureBox_minimize_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox_minimize, "最小化");
        }

        private void pictureBox_maximize_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox_maximize, "最大化");
        }

        private void pictureBox_close_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox_close, "关闭");
        }

        private async void pictureBox_update_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                panel_manuallyInput.Visible = !panel_manuallyInput.Visible;
                panel_controlPanel.Height = panel_manuallyInput.Visible ? 90 : 27;
                panel_manuallyInput.Tag = "updateTopTenShareholder";
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (MessageBox.Show("确定更新股票十大流通股东数据吗？", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    label_updatep.Text = "准备中...";
                    Progress<double> fetchTopTenShareholderProgress = new Progress<double>(
                        percentage =>
                        {
                            label_updatep.Text = Math.Round(percentage, 2) + "%";
                        }
                        );
                    await Task.Run(() => FetchTopTenShareholder(fetchTopTenShareholderProgress));
                }
            }
        }

        private async void pictureBox_getfinancialreport_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                panel_manuallyInput.Visible = !panel_manuallyInput.Visible;
                panel_controlPanel.Height = panel_manuallyInput.Visible ? 90 : 27;
                panel_manuallyInput.Tag = "getFinancialReport";
                label_manuallyInputp.Text = "";
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (MessageBox.Show("确定更新股票财务分析数据吗？", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    label_getfinancialreportp.Text = "准备中...";
                    Progress<double> fetchFinanceReportProgress = new Progress<double>(
                        percentage =>
                        {
                            label_getfinancialreportp.Text = Math.Round(percentage, 2) + "%";
                        }
                        );
                    await Task.Run(() => FetchFinanceReportProgress(fetchFinanceReportProgress));
                }
            }
        }

        private async void pictureBox_uploadsocketlist_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (MessageBox.Show("确定更新股票列表吗？", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    label_uploadsocketlistp.Text = "准备中...";
                    Progress<double> fetchStockListProgress = new Progress<double>(
                        percentage =>
                        {
                            label_uploadsocketlistp.Text = Math.Round(percentage, 2) + "%";
                        }
                        );
                    await Task.Run(() => FetchStockList(fetchStockListProgress));
                }
            }
        }

        private async void pictureBox_OpenLocalJsonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Json files (*.json)|*.json|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofd.FileName;
                string rawData = File.ReadAllText(fileName);
                string stockCode = textBox_manuallyInput_stockCode.Text.Trim();
                string operationType = panel_manuallyInput.Tag.ToString();
                if (stockCode != "")
                {
                    label_manuallyInputp.Text = "准备中...";
                    Progress<double> manuallyInputProgress = new Progress<double>(
                        percentage =>
                        {
                            label_manuallyInputp.Text = Math.Round(percentage, 2) + "%";
                        }
                        );
                    switch (operationType)
                    {
                        case "updateTopTenShareholder":
                            {
                                await Task.Run(() => ManuallyFetchTopTenShareholder(manuallyInputProgress, stockCode, rawData));
                                break;
                            }
                        case "getFinancialReport":
                            {
                                await Task.Run(() => ManuallyFetchFinanceReportProgress(manuallyInputProgress, stockCode, rawData));
                                break;
                            }
                    }
                }
                else
                {
                    MessageBox.Show("请输入股票代码");
                    textBox_manuallyInput_stockCode.Focus();
                }
            }
        }

        private void pictureBox_reloadShareholderList_Click(object sender, EventArgs e)
        {
            LoadShareholderNameList();
        }
        
        private void comboBox_paging_SelectedIndexChanged(object sender, EventArgs e)
        {
            var totalPageCount = (int)Math.Ceiling(SystemSetting.lstTopTenShareholder.Count * 1.0 / SystemSetting.recordCountPerPage);
            int index = comboBox_paging.SelectedIndex;
            int skipIndex = index * SystemSetting.recordCountPerPage > SystemSetting.lstTopTenShareholder.Count ? SystemSetting.lstTopTenShareholder.Count : index * SystemSetting.recordCountPerPage;
            UpdateShareholderListWithoutQuery(skipIndex);
        }

        private void pictureBox_next_Click(object sender, EventArgs e)
        {
            var totalPageCount = (int)Math.Ceiling(SystemSetting.lstTopTenShareholder.Count * 1.0 / SystemSetting.recordCountPerPage);
            int index = comboBox_paging.SelectedIndex;
            index = index == (totalPageCount - 1) ? (totalPageCount-1) : index + 1;
            comboBox_paging.SelectedIndex = index;
        }

        private void pictureBox_previous_Click(object sender, EventArgs e)
        {
            var totalPageCount = (int)Math.Ceiling(SystemSetting.lstTopTenShareholder.Count * 1.0 / SystemSetting.recordCountPerPage);
            int index = comboBox_paging.SelectedIndex;
            index = index == 0 ? 0 : index - 1;
            comboBox_paging.SelectedIndex = index;
        }

        private void webBrowserInner_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            DisplayLoadingUI(false);
        }

        private async void pictureBox_getqgqpdata_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                panel_manuallyInput.Visible = !panel_manuallyInput.Visible;
                panel_controlPanel.Height = panel_manuallyInput.Visible ? 90 : 27;
                panel_manuallyInput.Tag = "getFinancialReport";
                label_manuallyInputp.Text = "";
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (MessageBox.Show("确定更新股票千股千评数据吗？", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    label_getqgqpdata.Text = "准备中...";
                    Progress<double> fetchQGQPDataProgress = new Progress<double>(
                        percentage =>
                        {
                            label_getqgqpdata.Text = Math.Round(percentage, 2) + "%";
                        }
                        );
                    await Task.Run(() => FetchQGQP(fetchQGQPDataProgress));
                }
            }
        }

        private void textBoxZhuLiControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var proMin = Convert.ToDouble(textBoxZhuLiControl.Text.Trim())*1.0 / 100;
                var proMax = Convert.ToDouble(textBoxZhuLiControlmax.Text.Trim()) * 1.0 / 100;
                QueryQgqpData(proMin, proMax);
            }
        }

        private void textBoxZhuLiControlmax_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var proMin = Convert.ToDouble(textBoxZhuLiControl.Text.Trim()) * 1.0 / 100;
                var proMax = Convert.ToDouble(textBoxZhuLiControlmax.Text.Trim()) * 1.0 / 100;
                QueryQgqpData(proMin, proMax);
            }
        }

        private void pictureBox_getqgqpdata_MouseEnter(object sender, EventArgs e)
        {
            (sender as PictureBox).BorderStyle = BorderStyle.FixedSingle;
        }

        private void pictureBox_getqgqpdata_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox_getqgqpdata, "更新千股千评数据库");
        }

        private void pictureBox_getqgqpdata_MouseLeave(object sender, EventArgs e)
        {
            (sender as PictureBox).BorderStyle = BorderStyle.None;
        }

        private void pictureBoxSearchStock_Click(object sender, EventArgs e)
        {
            var queryCode = textBox_stockquery.Text.Trim();
            UpdateStockList(queryCode);
        }

        private void Top10ShareholderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayLoadingUI(true);
            OpenInWebBrowser("http://emweb.securities.eastmoney.com/ShareholderResearch/Index?type=web&code=" + (selectedStockCode.StartsWith("6") ? "sh" : "sz") + selectedStockCode);
        }

        private void QianguqianpingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayLoadingUI(true);
            OpenInWebBrowser($"http://data.eastmoney.com/stockcomment/stock/" + selectedStockCode + ".html");
        }

        private void KCurveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayLoadingUI(true);
            var code = (selectedStockCode.StartsWith("0") ? "sz" : "sh") + selectedStockCode;
            // var code = selectedStockCode;
            OpenInWebBrowser(SystemSetting.kCurve + code + ".html");
        }
        
        private void MoneyFlowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayLoadingUI(true);
            var code = selectedStockCode;
            // var code = selectedStockCode;
            OpenInWebBrowser(SystemSetting.moneyFlowDetail.Replace("{code}", code));
        }

        private void listBox_stock_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                string name = listBox_stock.SelectedItem.ToString();
                var codeArray = name.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var stockCode = codeArray[0].ToLower().Replace("sh", "").Replace("sz", "");
                selectedStockCode = stockCode;
            }
        }

        private void pictureBox_logo_Click(object sender, EventArgs e)
        {
            panelTool.Visible = !panelTool.Visible;
        }

        private void pictureBoxConfig_Click(object sender, EventArgs e)
        {
            var ui = new UI_Setting() {
                Dock = DockStyle.Fill
            };
            panelWorkspace.Controls.Add(ui);
            ui.BringToFront();
        }
    }
}
