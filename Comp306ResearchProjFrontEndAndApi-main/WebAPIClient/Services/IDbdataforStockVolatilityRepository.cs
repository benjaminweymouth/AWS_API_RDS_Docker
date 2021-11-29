using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialLibary.Models;
 

namespace WebAPIClient.Services
{
    public interface IDbdataforStockVolatilityRepository
    {
        bool StockExists(String StockIdTicker);
        Task<IEnumerable<DbdataforStockVolatility>> GetAllStockVolatilityInfo();
        Task<DbdataforStockVolatility> GetStockById(String StockIdTicker);
        // , bool includeNameofStock commented out, use if needed 
       // Task<IEnumerable<DbdataforStockVolatility>> GetAllStocksbyVolatility();
       // could be done on client side 
       // Task<DbdataforStockVolatility> GetStocksForPersonbySurvey(String StockIdTicker, int SurveyId);
         void AddStock(DbdataforStockVolatility stock);

        void EditStock(DbdataforStockVolatility stock);
        void DeleteStock(DbdataforStockVolatility stock);
        Task<bool> Save();
    }
}
