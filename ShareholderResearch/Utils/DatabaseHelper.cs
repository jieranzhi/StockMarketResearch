using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;
using System.Globalization;
using ShareholderResearch.Models;

namespace ShareholderResearch.Utils
{
    public class DatabaseHelper
    {
        private static string password = "gT2?GErn#MuDfw(UR4:]S%L<{/}t>3p*W6'qkYaF$,!vxJ~ch";
        /////////////////////////// Database /////////////////////////////
        public static void LoadDatabase()
        {
            try
            {
                if (SystemSetting.databaseFileDir != null && SystemSetting.databaseFileDir.Trim() != "")
                {
                    if (File.Exists(SystemSetting.databaseFileDir))
                    {
                        // load database
                        OpenDatabase(false);
                    }
                    else
                    {
                        // create database
                        CreateDatabase();
                    }
                }
                else
                {
                    SystemSetting.databaseFileDir = SystemSetting.systemDir + "record.db";
                    CreateDatabase();

                }
            }
            catch (Exception e)
            {
                SystemSetting.LogAndDisplayError(e, "DatabaseHelper.cs, line 41");
            }
        }
        // create database
        public static void CreateDatabase()
        {
            try
            {
                SQLiteConnection.CreateFile(SystemSetting.databaseFileDir);
                OpenDatabase(true);
                string sql = "CREATE TABLE IF NOT EXISTS stockList (_id INTEGER PRIMARY KEY AUTOINCREMENT, stockCode VARCHAR(8), stockName VARCHAR(20))";
                SQLiteCommand cmd = new SQLiteCommand(sql, SystemSetting.sqliteConnection);
                cmd.ExecuteNonQuery();

                string sql2 = "CREATE TABLE IF NOT EXISTS topTenStockholder (_id INTEGER PRIMARY KEY AUTOINCREMENT, ranking INT, stockCode VARCHAR(8), dateOfRecord VARCHAR(100)," +
                    " shareholderName VARCHAR(100), shareholderType VARCHAR(100), shareType VARCHAR(100), numberOfShares VARCHAR(100), percentageOfTotalTradableShares VARCHAR(100)," +
                    " statusChange VARCHAR(100), changeRate VARCHAR(100))";
                SQLiteCommand cmd2 = new SQLiteCommand(sql2, SystemSetting.sqliteConnection);
                cmd2.ExecuteNonQuery();

                string sql3 = "CREATE TABLE IF NOT EXISTS financialReport (_id INTEGER PRIMARY KEY AUTOINCREMENT, stockCode VARCHAR(8), dateOfRecord VARCHAR(100), basicProfitPerShare VARCHAR(100)," +
                    " netAssetsPerShare VARCHAR(100), providentFundPerShare VARCHAR(100), undistributedProfitPerShare VARCHAR(100), cashFlowPerShare VARCHAR(100), totalOperatingIncome VARCHAR(100)," +
                    " grossProfit VARCHAR(100), netProfitAttributable VARCHAR(100), deductionOfNonNetProfit VARCHAR(100), totalOperatingIncomeYearOnYearGrowth VARCHAR(100)," +
                    " netProfitAttributableYearOnYearGrowth VARCHAR(100), deductionOfNonNetProfitYearOnYearGrowth VARCHAR(100), totalOperatingIncomeRingGrowth VARCHAR(100)," +
                    " netProfitAttributableRingGrowth VARCHAR(100),deductionOfNonNetProfitRingGrowth VARCHAR(100), dilutedReturnOnEquity VARCHAR(100),dilutedReturnOnTotalAssets VARCHAR(100)," +
                    " grossMargin VARCHAR(100), netProfitRate VARCHAR(100))";
                SQLiteCommand cmd3 = new SQLiteCommand(sql3, SystemSetting.sqliteConnection);
                cmd3.ExecuteNonQuery();

                string sql4 = "CREATE TABLE IF NOT EXISTS qgqpData (_id INTEGER PRIMARY KEY AUTOINCREMENT, TRADECODE VARCHAR(8), TRADEDATE VARCHAR(100), STOCKNAME VARCHAR(100)," +
                    " PCTBUYXL VARCHAR(100), PCTBUYL VARCHAR(100), ZB VARCHAR(100), ZB3RAVG VARCHAR(100), ZB50RAVG VARCHAR(100)," +
                    " JGCYD VARCHAR(100), FLOWINXL VARCHAR(100), FLOWOUTXL VARCHAR(100), FLOWINL VARCHAR(100)," +
                    " FLOWOUTL VARCHAR(100), ZLJLR VARCHAR(100))";
                SQLiteCommand cmd4 = new SQLiteCommand(sql4, SystemSetting.sqliteConnection);
                cmd4.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                SystemSetting.LogAndDisplayError(ex, "DatabaseHelper.cs, line 58");
            }
        }
        // create 千股千评 table
        public static void CreateQGQPTable()
        {
            string sql4 = "CREATE TABLE IF NOT EXISTS qgqpData (_id INTEGER PRIMARY KEY AUTOINCREMENT, TRADECODE VARCHAR(8), TRADEDATE VARCHAR(100), STOCKNAME VARCHAR(100)," +
                " PCTBUYXL VARCHAR(100), PCTBUYL VARCHAR(100), ZB VARCHAR(100), ZB3RAVG VARCHAR(100), ZB50RAVG VARCHAR(100)," +
                " JGCYD VARCHAR(100), FLOWINXL VARCHAR(100), FLOWOUTXL VARCHAR(100), FLOWINL VARCHAR(100)," +
                " FLOWOUTL VARCHAR(100), ZLJLR VARCHAR(100))";
            SQLiteCommand cmd4 = new SQLiteCommand(sql4, SystemSetting.sqliteConnection);
            cmd4.ExecuteNonQuery();
        }
        // open database
        public static void OpenDatabase(bool init)
        {
            try
            {
                if (init)
                {
                    string connection_string = $"Data Source = {SystemSetting.databaseFileDir}; Version = 3;";
                    SystemSetting.sqliteConnection = new SQLiteConnection(connection_string);
                    SystemSetting.sqliteConnection.SetPassword(password);
                    SystemSetting.sqliteConnection.Open();
                }
                else
                {
                    string connection_string = $"Data Source = {SystemSetting.databaseFileDir}; Version = 3;Password={password};";
                    SystemSetting.sqliteConnection = new SQLiteConnection(connection_string);
                    SystemSetting.sqliteConnection.Open();
                }
            }
            catch (Exception ex)
            {
                SystemSetting.LogAndDisplayError(ex, "DatabaseHelper.cs, line 73");
            }
        }
        // query 
        public static SQLiteDataReader GetRecords(string tableName, int limit, int offset)
        {
            string sql = "select * from " + tableName + "limit " + limit.ToString(CultureInfo.InvariantCulture) + " offset " + offset.ToString(CultureInfo.InvariantCulture);
            SQLiteCommand cmd = new SQLiteCommand(sql, SystemSetting.sqliteConnection);
            return cmd.ExecuteReader();
        }
        // get all records
        public static SQLiteDataReader GetAll006030StockRecords(string tableName)
        {
            string sql = $"select * from {tableName} where stockCode like {SQLString("sz00%")} or stockCode like {SQLString("sz30%")} or stockCode like {SQLString("sh60%")}";
            SQLiteCommand cmd = new SQLiteCommand(sql, SystemSetting.sqliteConnection);
            return cmd.ExecuteReader();
        }
        // query 
        public static int Get006030StockRecordCount(string tableName)
        {
            string sql = $"select count(*) from {tableName} where stockCode like {SQLString("sz00%")} or stockCode like {SQLString("sz30%")} or stockCode like {SQLString("sh60%")}";
            SQLiteCommand cmd = new SQLiteCommand(sql, SystemSetting.sqliteConnection);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
        // query stock record
        public static SQLiteDataReader QueryStockRecords(string keyword)
        {
            var queryKey = "%" + keyword + "%";
            string sql = $"select * from stockList where stockCode like {SQLString(queryKey)} or stockName like {SQLString(queryKey)}";
            var cmd = new SQLiteCommand(sql, SystemSetting.sqliteConnection);
            return cmd.ExecuteReader();
        }
        // main query
        public static SQLiteDataReader QueryByShareholderName(string name)
        {
            string sql = $"select a.*, b.stockName, c.* from topTenStockholder as a " +
                $"join stockList as b on a.stockCode = b.stockCode " +
                $"join financialReport as c on (a.stockCode = c.stockCode and a.dateOfRecord = c.dateOfRecord)" +
                $" where a.shareholderName ={SQLString(name)}";
            SQLiteCommand cmd = new SQLiteCommand(sql, SystemSetting.sqliteConnection);
            SQLiteDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                sql = $"select a.*, b.stockName from topTenStockholder as a " +
                    $"join stockList as b on a.stockCode = b.stockCode " +
                    $"where a.shareholderName = { SQLString(name) } ";
                SQLiteCommand cmd2 = new SQLiteCommand(sql, SystemSetting.sqliteConnection);
                reader = cmd2.ExecuteReader();
            }
            if (!reader.HasRows)
            {
                sql = $"select * from topTenStockholder where shareholderName = {SQLString(name)}";
                SQLiteCommand cmd3 = new SQLiteCommand(sql, SystemSetting.sqliteConnection);
                reader = cmd3.ExecuteReader();
            }
            return reader;
        }
        // get all shareholders
        public static SQLiteDataReader GetShareholderNameList()
        {
            string sql = "select distinct(shareholderName)  from topTenStockholder order by shareholderName asc";
            SQLiteCommand cmd = new SQLiteCommand(sql, SystemSetting.sqliteConnection);
            return cmd.ExecuteReader();
        }
        // main query
        public static SQLiteDataReader QueryQGQPDataByMainControl(double proMin, double proMax)
        {
            string sql = $"select * from qgqpData where JGCYD >= {proMin} AND JGCYD <= {proMax}";
            SQLiteCommand cmd = new SQLiteCommand(sql, SystemSetting.sqliteConnection);
            SQLiteDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        // query by code
        public static SQLiteDataReader QueryQGQPDataByStockCode(string stockCode)
        {
            string sql = $"select * from qgqpData where TRADECODE == {stockCode}";
            SQLiteCommand cmd = new SQLiteCommand(sql, SystemSetting.sqliteConnection);
            SQLiteDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        // wrap string with ''double proportion
        public static string SQLString(string str)
        {
            return "'" + str.Replace("\0", string.Empty) + "'";
        }
        // delete all records in the table
        public static void ClearTable(string tableName)
        {
            string sql = $"delete from {tableName}";
            SQLiteCommand cmd = new SQLiteCommand(sql, SystemSetting.sqliteConnection);
            cmd.ExecuteNonQuery();
        }
        // save to database
        public static void UpdateStockList( string stockCode, string stockName)
        {
            string sql = $"insert or replace into stockList (_id, stockCode, stockName) values " +
                $"((select _id from stockList where stockCode == {SQLString(stockCode)}), " +
                $"{SQLString(stockCode)}, {SQLString(stockName)})";
            SQLiteCommand cmd = new SQLiteCommand(sql, SystemSetting.sqliteConnection);
            cmd.ExecuteNonQuery();
        }
        // save to database
        public static void UpdateTopTenStockholder(string stockCode, Dictionary<string,string> sdltgd)
        {
            var sqlId = "select _id from topTenStockholder where " +
                $"stockCode == {SQLString(stockCode)} and shareholderName=={SQLString(sdltgd["gdmc"])} and dateOfRecord=={SQLString(sdltgd["rq"])}";
            var cmd = new SQLiteCommand(sqlId, SystemSetting.sqliteConnection);
            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                var _id = "null";
                while (reader.Read())
                {
                    _id = reader["_id"].ToString();
                }
                // replace
                var sql = $"replace into topTenStockholder (_id, ranking, stockCode, dateOfRecord, " +
                    $"shareholderName, shareholderType, shareType, numberOfShares, percentageOfTotalTradableShares, " +
                    $"statusChange, changeRate) values "+
                    $"({_id}, {SQLString(sdltgd["mc"])}, {SQLString(stockCode)}, {SQLString(sdltgd["rq"])}, {SQLString(sdltgd["gdmc"])},{SQLString(sdltgd["gdxz"])}," +
                    $"{SQLString(sdltgd["gflx"])},{SQLString(sdltgd["cgs"])},{SQLString(sdltgd["zltgbcgbl"])},{SQLString(sdltgd["zj"])},{SQLString(sdltgd["bdbl"])})";
                var cmdReplace = new SQLiteCommand(sql, SystemSetting.sqliteConnection);
                cmdReplace.ExecuteNonQuery();
            }
            else
            {
                // insert
                var sql = $"insert into topTenStockholder (ranking, stockCode, dateOfRecord, " +
                    $"shareholderName, shareholderType, shareType, numberOfShares, percentageOfTotalTradableShares, " +
                    $"statusChange, changeRate) values " +
                    $"({SQLString(sdltgd["mc"])}, {SQLString(stockCode)}, {SQLString(sdltgd["rq"])}, {SQLString(sdltgd["gdmc"])},{SQLString(sdltgd["gdxz"])}," +
                    $"{SQLString(sdltgd["gflx"])},{SQLString(sdltgd["cgs"])},{SQLString(sdltgd["zltgbcgbl"])},{SQLString(sdltgd["zj"])},{SQLString(sdltgd["bdbl"])})";
                var cmdInsert = new SQLiteCommand(sql, SystemSetting.sqliteConnection);
                cmdInsert.ExecuteNonQuery();
            }

            //var sql = $"insert or replace into topTenStockholder (_id, ranking, stockCode, dateOfRecord, " +
            //    $"shareholderName, shareholderType, shareType, numberOfShares, percentageOfTotalTradableShares, " +
            //    $"statusChange, changeRate) values ((select _id from topTenStockholder where " +
            //    $"stockCode == {SQLString(stockCode)} and shareholderName=={SQLString(sdltgd["gdmc"])} and dateOfRecord=={SQLString(sdltgd["rq"])}), " +
            //    $"{SQLString(sdltgd["mc"])}, {SQLString(stockCode)}, {SQLString(sdltgd["rq"])}, {SQLString(sdltgd["gdmc"])},{SQLString(sdltgd["gdxz"])}," +
            //    $"{SQLString(sdltgd["gflx"])},{SQLString(sdltgd["cgs"])},{SQLString(sdltgd["zltgbcgbl"])},{SQLString(sdltgd["zj"])},{SQLString(sdltgd["bdbl"])})";
            //var cmd = new SQLiteCommand(sql, SystemSetting.sqliteConnection);
            //cmd.ExecuteNonQuery();
        }
        // save to database
        public static void UpdateFinancialReport(string stockCode, Dictionary<string, string> report)
        {
            string sql = $"insert or replace into financialReport (_id, stockCode, dateOfRecord, basicProfitPerShare, netAssetsPerShare, providentFundPerShare, undistributedProfitPerShare, " +
                $"cashFlowPerShare, totalOperatingIncome, grossProfit, netProfitAttributable, deductionOfNonNetProfit, totalOperatingIncomeYearOnYearGrowth, netProfitAttributableYearOnYearGrowth," +
                $" deductionOfNonNetProfitYearOnYearGrowth, totalOperatingIncomeRingGrowth, netProfitAttributableRingGrowth, deductionOfNonNetProfitRingGrowth, dilutedReturnOnEquity," +
                $" dilutedReturnOnTotalAssets, grossMargin,netProfitRate) values " +
                $"((select _id from financialReport where stockCode == {SQLString(stockCode)} and dateOfRecord == {SQLString(report["date"])}), " +
                $"{SQLString(stockCode)}, {SQLString(report["date"])}, {SQLString(report["jbmgsy"])}, {SQLString(report["mgjzc"])}, {SQLString(report["mggjj"])}, {SQLString(report["mgwfply"])}" +
                $", {SQLString(report["mgjyxjl"])}, {SQLString(report["yyzsr"])}, {SQLString(report["mlr"])}, {SQLString(report["gsjlr"])}, {SQLString(report["kfjlr"])}, {SQLString(report["yyzsrtbzz"])}" +
                $", {SQLString(report["gsjlrtbzz"])}, {SQLString(report["kfjlrtbzz"])}, {SQLString(report["yyzsrgdhbzz"])}, {SQLString(report["gsjlrgdhbzz"])}, {SQLString(report["kfjlrgdhbzz"])}," +
                $" {SQLString(report["tbjzcsyl"])}, {SQLString(report["tbzzcsyl"])}, {SQLString(report["mll"])}, {SQLString(report["jll"])})";
            SQLiteCommand cmd = new SQLiteCommand(sql, SystemSetting.sqliteConnection);
            cmd.ExecuteNonQuery();
        }
        // save to database
        public static void UpdateQGQPData(string stockCode, StockCommentList report)
        {
            string sql = $"insert or replace into qgqpData (_id, TRADECODE, STOCKNAME, TRADEDATE, PCTBUYXL, PCTBUYL, ZB, " +
                $"ZB3RAVG, ZB50RAVG, JGCYD, FLOWINXL, FLOWOUTXL, FLOWINL, FLOWOUTL, ZLJLR) values " +
                $"((select _id from qgqpData where TRADECODE == {SQLString(stockCode)} and TRADEDATE == {SQLString(report.Tradedate.ToString())}), " +
                $"{SQLString(stockCode)}, {SQLString(report.Stockname)}, {SQLString(report.Tradedate.ToString())}, {SQLString(report.Pctbuyxl.ToString())}, {SQLString(report.Pctbuyl.ToString())}, {SQLString(report.Zb.ToString())}" +
                $", {SQLString(report.Zb3Ravg.ToString())}, {SQLString(report.Zb50Ravg.ToString())}, {SQLString(report.Jgcyd.ToString())}, {SQLString(report.Flowinxl.ToString())}, {SQLString(report.Flowoutxl.ToString())}, {SQLString(report.Flowinl.ToString())}" +
                $", {SQLString(report.Flowoutl.ToString())}, {SQLString(report.Zljlr.ToString())})";
            SQLiteCommand cmd = new SQLiteCommand(sql, SystemSetting.sqliteConnection);
            cmd.ExecuteNonQuery();
        }
        // check if a column exists
        public static bool ColumnExists(SQLiteDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
        // optimize the batch operation
        public static void OptimizationBegin()
        {
            SQLiteCommand cmd = new SQLiteCommand("begin", SystemSetting.sqliteConnection);
            cmd.ExecuteNonQuery();
        }       
        // optimize the batch operation
        public static void OptimizationEnd()
        {
            SQLiteCommand cmd = new SQLiteCommand("end", SystemSetting.sqliteConnection);
            cmd.ExecuteNonQuery();
        }
    }
}
