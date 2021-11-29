using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APItry1FRONTEND.Models
{
    public class DbdataforStockVolatility
    {

            public string stockIdTicker { get; set; }
            public string name { get; set; }
            public string sector { get; set; }
            public string stockVolatility { get; set; }
            public object[] surveyInfoTable { get; set; }
       

        public override string ToString()
        {
            return $"{stockIdTicker} {name} {sector} {stockVolatility} {surveyInfoTable} \n";
        }

    }
}
