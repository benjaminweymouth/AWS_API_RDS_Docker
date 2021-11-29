using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace FinancialLibary.Models
{
    public partial class SurveyInfoTable
    {
        public SurveyInfoTable()
        {
            SurveyInfoList = new HashSet<SurveyInfoTable>();
        }

        public string SurveyId { get; set; }
        public string SurveyPersonName { get; set; }
        public string SurveyAmount { get; set; }
        public string SurveyIndustry { get; set; }
        public string SurveyRiskTolerance { get; set; }
        public string SurveyCryptoVsstocks { get; set; }
        public string SurveyInfoTableSurveyId { get; set; }
        
        [ForeignKey("StockIdTicker")]
        public string StockIdTicker { get; set; }

         public virtual ICollection<SurveyInfoTable> SurveyInfoList { get; set; }
        public virtual DbdataforStockVolatility StockIdTickerNavigation { get; set; }

      
    }
}
