using ShareholderResearch.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace ShareholderResearch.Utils
{
    public class WebCrawler
    {
        private WebCrawler()
        { }

        public static WebCrawler Instance { get { return Nested.instance; } }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly WebCrawler instance = new WebCrawler();
        }

        public static readonly object lockObject = new object();

        public void FetchStockList(IProgress<double> progress)
        {
            lock (lockObject)
            {
                try
                {
                    DataCollector dataCollector = new DataCollector();
                    string rawStockList = dataCollector.GetHttpResponse(SystemSetting.stockListUrl, false).Result;
                    List<string[]> lstStock = dataCollector.GetStockList(rawStockList); //dataCollector.GetStockList(rawStockList, SystemSetting.stockListMatchPattern);
                    int dataCount = lstStock.Count;
                    DatabaseHelper.ClearTable("stockList");
                    int i = 0;
                    DatabaseHelper.OptimizationBegin();
                    foreach (string[] stock in lstStock)
                    {
                        DatabaseHelper.UpdateStockList(stock[0], stock[1]);
                        i++;
                        progress.Report(100.0 * i / dataCount);
                    }
                    DatabaseHelper.OptimizationEnd();
                }
                catch (Exception ex)
                {
                    SystemSetting.LogAndDisplayError(ex, "MainForm.cs, line 117");
                }
            }
        }

        public void FetchTopTenShareholder(IProgress<double> progress)
        {
            lock (lockObject)
            {
                try
                {
                    var fileDir = SystemSetting.downloadJsonDir + "topten.tmp";
                    int dataCount = DatabaseHelper.Get006030StockRecordCount("stockList");

                    var topTenShareholderList = new Dictionary<string, TopTenShareholderJsonPackage>();
                    var jsonCollection = new StringBuilder(dataCount);
                    var stockCodeTemp = "";

                    int i = 0;
                    if (File.Exists(fileDir))
                    {
                        var rawJsonList = File.ReadAllLines(fileDir);
                        foreach (var record in rawJsonList)
                        {
                            i++;
                            var line = record.Split(new string[] { "|||" }, StringSplitOptions.None);
                            var stockCode = line[0];
                            var rawTopTenShareHolder = line[1];
                            var package = TopTenShareholderJsonParser.FromJson(rawTopTenShareHolder);
                            topTenShareholderList.Add(stockCode, package);
                            progress.Report(50.0 * i / dataCount);
                            Console.WriteLine($"{i}:{stockCode} --- {rawTopTenShareHolder}");
                        }
                    }
                    else
                    {
                        try
                        {
                            var reader = DatabaseHelper.GetAll006030StockRecords("stockList");
                            var stockCodeList = new List<string>();
                            while (reader.Read())
                            {
                                stockCodeList.Add(reader[1].ToString());
                            }
                            if (stockCodeList.Any())
                            {
                                foreach (var stockCode in stockCodeList)
                                {
                                    i++;
                                    stockCodeTemp = stockCode;
                                    //var dataCollector = new DataCollector();
                                    //var rawTopTenShareHolder
                                    //    = JsonEscape(dataCollector.GetHttpResponse(SystemSetting.rootUrlOfTopTenShareHolder + stockCode, false).Result);
                                    var rawTopTenShareHolder = HttpRequestWithRetryTimes(SystemSetting.rootUrlOfTopTenShareHolder + stockCode, 3);
                                    if (rawTopTenShareHolder != "!!error!!")
                                    {
                                        var package = TopTenShareholderJsonParser.FromJson(rawTopTenShareHolder);
                                        topTenShareholderList.Add(stockCode, package);
                                        jsonCollection.AppendLine($"{stockCode}|||{rawTopTenShareHolder}");
                                    }
                                    else
                                    {
                                    }
                                    progress.Report(50.0 * i / dataCount);
                                    Console.WriteLine($"{i}:{stockCode} --- {rawTopTenShareHolder}");
                                    Thread.Sleep(200);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            SystemSetting.LogAndDisplayError(ex, $"{stockCodeTemp} MainForm.cs, line 96");
                            return;
                        }

                        if (jsonCollection.Length > 0)
                        {
                            File.WriteAllText(fileDir, jsonCollection.ToString());
                        }
                    }

                    try
                    {
                        i = 0;
                        if (topTenShareholderList.Any())
                        {
                            //DatabaseHelper.CreateIndexOnTable("topTenStockholder", "IdxTenShareHolder", new string[] { "stockCode", "shareholderName" });
                            DatabaseHelper.OptimizationBegin();
                            foreach (var dicPackage in topTenShareholderList)
                            {
                                i++;
                                var stockCode = dicPackage.Key;
                                var package = dicPackage.Value;
                                if (package == null)
                                {
                                }
                                stockCodeTemp = stockCode;
                                var sdltgdList = package.Sdltgd.SelectMany(p => p.SdltgdSdltgd).ToArray();
                                foreach (var sdltgd in sdltgdList/*sdltgdItem.SdltgdSdltgd*/)
                                {
                                    try
                                    {
                                        DatabaseHelper.UpdateTopTenStockholder(stockCode, sdltgd);
                                        Console.WriteLine($"{i}/{dataCount} - {sdltgd["rq"]}:{stockCode} --- {sdltgd["gdmc"]}");
                                    }
                                    catch (Exception ex)
                                    {
                                        SystemSetting.LogAndDisplayError(ex, $"{stockCodeTemp} MainForm.cs, line 460");
                                    }
                                }
                                progress.Report(50.0 * i / dataCount + 50);
                            }
                            DatabaseHelper.OptimizationEnd();
                        }
                    }
                    catch (Exception ex)
                    {
                        SystemSetting.LogAndDisplayError(ex, $"{stockCodeTemp} MainForm.cs, line 464");
                        return;
                    }

                    if (File.Exists(fileDir))
                    {
                        File.Delete(fileDir);
                    }
                }
                catch (Exception ex)
                {
                    SystemSetting.LogAndDisplayError(ex, "MainForm.cs, line 102");
                }
            }
        }

        public string HttpRequestWithRetryTimes(string url, int retryCount)
        {
            var dataCollector = new DataCollector();
            var rawTopTenShareHolder
                                       = DataCollector.JsonEscape(dataCollector.GetHttpResponse(url, false).Result);
            if (retryCount < 0 || rawTopTenShareHolder != "!!error!!") return rawTopTenShareHolder;

            Thread.Sleep(1000);
            return HttpRequestWithRetryTimes(url, --retryCount);
        }

        public void FetchFinanceReportProgress(IProgress<double> progress)
        {
            lock (lockObject)
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
                            string rawFinantialReport = DataCollector.JsonEscape(dataCollector.GetHttpResponse(SystemSetting.rootUrlOfFinancialReport + stockCode, false).Result);
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
        }

        public void FetchQGQP(IProgress<double> progress)
        {
            lock (lockObject)
            {
                try
                {
                    var fileDir = SystemSetting.downloadJsonDir + "qgqp.tmp";
                    int dataCount = DatabaseHelper.Get006030StockRecordCount("stockList");

                    var stockCommentList = new Dictionary<string, List<StockCommentList>>();
                    var jsonCollection = new StringBuilder(dataCount);
                    var stockCodeTemp = "";

                    // DatabaseHelper.ClearTable("qgqpData");
                    int i = 0;
                    if (File.Exists(fileDir))
                    {
                        var rawJsonList = File.ReadAllLines(fileDir);
                        foreach (var record in rawJsonList)
                        {
                            i++;
                            var line = record.Split(new string[] { "|||" }, StringSplitOptions.None);
                            var stockCode = line[0];
                            var rawTopTenShareHolder = line[1];
                            var package = StockCommentList.FromJson(rawTopTenShareHolder);
                            stockCommentList.Add(stockCode, package);
                            progress.Report(50.0 * i / dataCount);
                            Console.WriteLine($"{i}:{stockCode} --- {rawTopTenShareHolder}");
                        }
                    }
                    else
                    {
                        var reader = DatabaseHelper.GetAll006030StockRecords("stockList");
                        var stockCodeList = new List<string>();
                        while (reader.Read())
                        {
                            string stockCode = reader[1].ToString().ToLower().Replace("sz", "").Replace("sh", "");
                            stockCodeList.Add(stockCode);
                        }

                        try
                        {
                            if (stockCodeList.Any())
                            {
                                foreach (var stockCode in stockCodeList)
                                {
                                    i++;
                                    stockCodeTemp = stockCode;
                                    var qgqpData = HttpRequestWithRetryTimes(SystemSetting.stockQGQPURL.Replace("{code}", stockCode), 3);
                                    if (qgqpData != "!!error!!")
                                    {
                                        jsonCollection.AppendLine(qgqpData);

                                        var package = StockCommentList.FromJson(qgqpData);
                                        stockCommentList.Add(stockCode, package);
                                        Console.WriteLine($"{i}:{stockCode} --- {qgqpData}");
                                    }
                                    progress.Report(50.0 * i / dataCount);
                                }
                                File.WriteAllText(fileDir, jsonCollection.ToString());
                            }
                            i = 0;
                            DatabaseHelper.OptimizationBegin();
                            foreach (var record in stockCommentList)
                            {
                                i++;
                                var stockCode = record.Key;
                                var commentList = record.Value;
                                foreach (StockCommentList comment in commentList)
                                {
                                    DatabaseHelper.UpdateQGQPData(stockCode, comment);
                                }
                                progress.Report(50.0 * i / dataCount + 50);
                            }
                            DatabaseHelper.OptimizationEnd();
                        }
                        catch (Exception ex0)
                        {
                            SystemSetting.LogAndDisplayError(ex0, $"{stockCodeTemp} MainForm.cs, line 169");
                        }
                    }

                    if (File.Exists(fileDir))
                    {
                        File.Delete(fileDir);
                    }
                }
                catch (Exception ex)
                {
                    SystemSetting.LogAndDisplayError(ex, "MainForm.cs, line 178");
                }
            }
        }

        public void ManuallyFetchTopTenShareholder(IProgress<double> progress, string stockCode, string rawTopTenShareHolder)
        {
            lock (lockObject)
            {
                try
                {
                    TopTenShareholderJsonPackage package = TopTenShareholderJsonParser.FromJson(DataCollector.JsonEscape(rawTopTenShareHolder));
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
        }

        public void ManuallyFetchFinanceReportProgress(IProgress<double> progress, string stockCode, string rawFinancialReport)
        {
            lock (lockObject)
            {
                try
                {
                    int i = 0;
                    Dictionary<string, string>[] package = FinancialReportJsonParser.FromJson(DataCollector.JsonEscape(rawFinancialReport));
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
        }
    }
}
