using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.RegularExpressions;
using ShareholderResearch.Models;

namespace ShareholderResearch.Utils
{
    public class DataCollector
    {
        public async Task<string> GetHttpResponse(string url, bool gb2312Enable)
        {
            var responseString = "";
            try
            {
                using (var client = new HttpClient())
                {
                    var byteArray = await client.GetByteArrayAsync(url);
                    responseString = gb2312Enable?Encoding.GetEncoding("gb2312").GetString(byteArray):Encoding.UTF8.GetString(byteArray);
                }
            }
            catch (Exception ex)
            {
                SystemSetting.LogAndDisplayError(ex, $"DataCollector.cs, line 27 \r\n [Url]: {url} \r\n");
            }
            return responseString;
        }

        public List<string[]> GetStockList(string rawHtml, string matchPattern)
        {
            List<string[]> lstStock = new List<string[]>();
            Regex regex = new Regex(matchPattern);
            MatchCollection matches = regex.Matches(rawHtml);
            foreach (Match match in matches)
            {
                try
                {
                    // [stockCode, stockName]
                    string[] matchPair = new string[] { match.Groups[1].Value, match.Groups[2].Value };
                    lstStock.Add(matchPair);
                }
                catch(Exception ex)
                {
                    SystemSetting.LogAndDisplayError(ex, $"DataCollector.cs, line 47 \r\n");
                }
            }
            return lstStock;
        }

        public List<string[]> GetStockList(string rawJson)
        {
            var stockList = StockList.FromJson(rawJson);
            var lstStock = stockList.Data.Diff.Select(p => new string[] { (p.F12.StartsWith("6")?"sh":"sz") + p.F12, p.F14 }).ToList();
            return lstStock;
        }

    }
}
