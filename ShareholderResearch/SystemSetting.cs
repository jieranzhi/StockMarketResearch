using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.ComponentModel;

namespace ShareholderResearch
{
    public static class SystemSetting
    {
        public static string version = "v 1.45";
        public static string rootUrlOfTopTenShareHolder = "http://emweb.securities.eastmoney.com/PC_HSF10/ShareholderResearch/ShareholderResearchAjax?code=";
        public static string rootUrlOfFinancialReport = "http://emweb.securities.eastmoney.com/NewFinanceAnalysis/MainTargetAjax?ctype=4&type=0&code=";
        public static string kCurve = "http://quote.eastmoney.com/"; // "http://stockpage.10jqka.com.cn/";//
        public static string stockListUrl = "http://81.push2.eastmoney.com/api/qt/clist/get?pn=1&pz=4000&po=1&np=1&ut=bd1d9ddb04089700cf9c27f6f7426281&fltt=2&invt=2&fid=f3&fs=m:0+t:6,m:0+t:13,m:0+t:80,m:1+t:2,m:1+t:23&_=1568966477018";//"http://quote.eastmoney.com/stocklist.html";
        public static string stockQGQPURL = "http://dcfm.eastmoney.com/em_mutisvcexpandinterface/api/js/get?type=QGQP_LSJGCYD&token=70f12f2f4f091e459a279469fe49eca5&ps=1&filter=(TRADECODE=%27{code}%27)";
        public static string stockListMatchPattern = "\\\"http://quote.eastmoney.com/(.*?).html\\\">(.*?)\\(";
        public static string moneyFlowDetail = "http://data.eastmoney.com/zjlx/{code}.html";
        public static string moneyFlowUrl = "http://ff.eastmoney.com//EM_CapitalFlowInterface/api/js?type=hff&rtntype=2&js=(x)&cb=&check=TMLBMSPROCR&acces_token=1942f5da9b46b069953c873404aad4b5&id={code}&_=1569244129547";
        public static string databaseFileDir;
        public static string systemDir;
        public static string errorLogDir;
        public static SQLiteConnection sqliteConnection;
        public static List<string> lstTopTenShareholder;
        public static BindingList<string> lstTopTenShareholderDisplay;
        public static BindingList<string> lstStockDisplay = new BindingList<string> { "sh600015\t华夏银行" };
        public static int recordCountPerPage = 200;
        
        public static void CheckDirectory(string dir)
        {
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
        }

        public static void LogAndDisplayError(Exception ex, string source_info)
        {
            DateTime now = DateTime.Now;
            string file_name = errorLogDir + "error_" + now.ToString("yyyy_MM_dd") + ".ERR";
            string timestring = now.ToString("yyyy-MM-dd HH:mm:ss");
            var error_log = $"\r\n[{timestring}] {source_info}\r\n";
            string pr_message = ex.Message;
            error_log += ($"[Message]: {pr_message} \r\n");
            if (ex.StackTrace != null)
            {
                var pr_stacktrace = ex.StackTrace;
                error_log += ($"[StackTrace]: {pr_stacktrace} \r\n");
            }

            if (ex.InnerException != null)
            {
                var inner_message = ex.InnerException.Message;
                error_log += ($"[Inner Message]: {inner_message} \r\n");

                if (ex.InnerException.StackTrace != null)
                {
                    var inner_stacktrace = ex.InnerException.StackTrace;
                    error_log += ($"[Inner StackTrace]: {inner_stacktrace} \r\n");
                }
            }

            File.AppendAllText(file_name, error_log);
            Debug.Write(error_log);
        }
    }
}
