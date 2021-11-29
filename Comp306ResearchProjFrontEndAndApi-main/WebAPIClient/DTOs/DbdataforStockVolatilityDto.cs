using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIClient.DTOs
{
    public class DbdataforStockVolatilityDto
    {
        public string StockIdTicker { get; set; }
        public string Name { get; set; }
        public string Sector { get; set; }
        public string StockVolatility { get; set; }

        public ICollection<DbdataforStockVolatilityDto> SurveyInfoTable { get; set; }
        = new List<DbdataforStockVolatilityDto>();
    }
}
