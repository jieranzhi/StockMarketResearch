using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareholderResearch.Models
{
    public class FinancialReport
    {
        public string stockCode { get; set; }                                           // 股票代码
        public string dateOfRecord { get; set; }                                        // 报告日期
        public string basicProfitPerShare { get; set; }                                 // 基本每股收益(元) 
        public string netAssetsPerShare { get; set; }                                   // 每股净资产(元)
        public string providentFundPerShare { get; set; }                               // 每股公积金(元)
        public string undistributedProfitPerShare { get; set; }                         // 每股未分配利润(元)
        public string cashFlowPerShare { get; set; }                                    // 每股经营现金流(元)
        public string totalOperatingIncome { get; set; }                                // 营业总收入(元)
        public string grossProfit { get; set; }                                         // 毛利润(元)
        public string netProfitAttributable { get; set; }                               // 归属净利润(元)
        public string deductionOfNonNetProfit { get; set; }                             // 扣非净利润(元)
        public string totalOperatingIncomeYearOnYearGrowth { get; set; }                // 营业总收入同比增长(%)
        public string netProfitAttributableYearOnYearGrowth { get; set; }               // 归属净利润同比增长(%)
        public string deductionOfNonNetProfitYearOnYearGrowth { get; set; }             // 扣非净利润同比增长(%)
        public string totalOperatingIncomeRingGrowth { get; set; }                      // 营业总收入滚动环比增长(%)
        public string netProfitAttributableRingGrowth { get; set; }                     // 归属净利润滚动环比增长(%)
        public string deductionOfNonNetProfitRingGrowth { get; set; }                   // 扣非净利润滚动环比增长(%)
        public string dilutedReturnOnEquity { get; set; }                               // 摊薄净资产收益率(%)
        public string dilutedReturnOnTotalAssets { get; set; }                          // 摊薄总资产收益率(%)
        public string grossMargin{ get; set; }                                          // 毛利率(%)
        public string netProfitRate { get; set; }                                       // 净利率(%)
    }
}
