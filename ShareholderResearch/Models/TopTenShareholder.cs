using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareholderResearch.Models
{
    public class TopTenShareholder
    {
        public string shareholderName;                              // 股东姓名
        public List<ShareHoldingRecord> lstShareHoldingRecord;      // 股票记录
        public TopTenShareholder(string name)
        {
            shareholderName = name;
            lstShareHoldingRecord = new List<ShareHoldingRecord>();
        }
    }

    public class ShareHoldingRecord
    {
        public string dateOfRecord { get; set; }                      // 记录日期   
        public string ranking { get; set; }                           // 名次
        public string stockCode { get; set; }                         // 股票代码    
        public string stockName { get; set; }                         // 股票名称 
        public string shareholderType { get; set; }                   // 股东性质
        public string shareType { get; set; }                         // 股份类型
        public string numberOfShares { get; set; }                    // 持股数(股)
        public string percentageOfTotalTradableShares { get; set; }   // 占总流通股本持股比例
        public string statusChange { get; set; }                      // 增减(股)
        public string changeRate { get; set; }                        // 变动比例
        public FinancialReport financialReport { get; set; }          // 财务分析

    }
    
}
