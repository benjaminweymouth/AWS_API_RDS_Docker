using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace FinancialLibary.Models
{
    public partial class DbdataforStockVolatility
    {
        public DbdataforStockVolatility()
        {
            SurveyInfoTables  = new HashSet<SurveyInfoTable>();
        }
        [Key]
        public string StockIdTicker { get; set; }
        public string Name { get; set; }
        public string Sector { get; set; }
        public string StockVolatility { get; set; }

        //maybe rename this one? surveyinfotables might not make sense 
        public virtual ICollection<SurveyInfoTable> SurveyInfoTables  { get; set; }
    }
}
