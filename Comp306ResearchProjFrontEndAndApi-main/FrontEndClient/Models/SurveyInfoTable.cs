using APItry1FRONTEND.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APItry1FRONTEND.Models
{
    public class SurveyInfoTable
    {
        public string surveyId { get; set; }
        public string surveyPersonName { get; set; }
        public string surveyAmount { get; set; }
        public string surveyIndustry { get; set; }
        public string surveyRiskTolerance { get; set; }
        public string surveyCryptoVsstocks { get; set; }
        public string surveyInfoTableSurveyId { get; set; }
        public string stockIdTicker { get; set; }
        public string[] surveyInfoList { get; set; }
        public string stockIdTickerNavigation { get; set; }
    }
}
