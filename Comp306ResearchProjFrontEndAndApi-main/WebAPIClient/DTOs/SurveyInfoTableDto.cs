using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIClient.DTOs
{
    public class SurveyInfoTableDto
    {
        public string SurveyId { get; set; }
        public string SurveyPersonName { get; set; }
        public string SurveyAmount { get; set; }
        public string SurveyIndustry { get; set; }
        public string SurveyRiskTolerance { get; set; }
        public string SurveyCryptoVsstocks { get; set; }
        public string StockIdTicker { get; set; }

         public ICollection<SurveyInfoTableDto> SurveyInfoList { get; set; }
      = new List<SurveyInfoTableDto>();
    }
}
