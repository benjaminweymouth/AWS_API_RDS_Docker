using FinancialLibary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIClient.Services
{
    public class DbdataforStockVolatilityRepository : IDbdataforStockVolatilityRepository
    {
        private comp306FinancialDBContext _context;
        public DbdataforStockVolatilityRepository(comp306FinancialDBContext context)
        {
            _context = context;
        }

        public bool StockExists(String StockIdTicker)
        {
            return _context.DbdataforStockVolatilities.Any<DbdataforStockVolatility>(c => c.StockIdTicker == StockIdTicker);
        }

        public async Task<IEnumerable<DbdataforStockVolatility>> GetAllStockVolatilityInfo()
        {
            var result = _context.DbdataforStockVolatilities.OrderBy(c => c.StockIdTicker);
            return await result.ToListAsync();
        }


        public async Task<DbdataforStockVolatility> GetStockById(String StockIdTicker)
        {
            IQueryable<DbdataforStockVolatility> result;
                                      
            result = _context.DbdataforStockVolatilities.Where(c => c.StockIdTicker == StockIdTicker);

            return await result.FirstOrDefaultAsync();
        }

        public void AddStock(DbdataforStockVolatility stock)
        {
            
            _context.DbdataforStockVolatilities.Add(stock);
              


        }

        public void EditStock(DbdataforStockVolatility stock)
        {
            
            _context.DbdataforStockVolatilities.Update(stock);

        }



        public void DeleteStock(DbdataforStockVolatility stock)
        {
             
            _context.DbdataforStockVolatilities.Remove(stock);
        }

        public async Task<bool> Save()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}
