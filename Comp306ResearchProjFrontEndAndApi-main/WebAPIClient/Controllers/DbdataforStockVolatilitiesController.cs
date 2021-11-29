using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinancialLibary.Models;
using WebAPIClient.Services;
using AutoMapper;
using WebAPIClient.DTOs;

namespace WebAPIClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbdataforStockVolatilitiesController : ControllerBase
    {
        // private readonly comp306FinancialDBContext _context;

        private IDbdataforStockVolatilityRepository _DbdataforStockVolatilityRepository;
        private readonly IMapper _mapper;

        public DbdataforStockVolatilitiesController(IDbdataforStockVolatilityRepository _dbdataforStockVolatilityRepository, IMapper mapper)
        {
            _DbdataforStockVolatilityRepository = _dbdataforStockVolatilityRepository;
            _mapper = mapper;
        }

        // GET: api/DbdataforStockVolatilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DbdataforStockVolatility>>> GetDbdataforStockVolatilities()
        {
            var stockdata = await _DbdataforStockVolatilityRepository.GetAllStockVolatilityInfo();
            var results = _mapper.Map<IEnumerable<DbdataforStockVolatilityDto>>(stockdata);

            return Ok(results);
        }

        // GET: api/DbdataforStockVolatilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DbdataforStockVolatility>> GetDbdataforStockVolatility(String StockIdTicker)
        {
            var dbdataforStockVolatility = await _DbdataforStockVolatilityRepository.GetStockById(StockIdTicker);

            if (dbdataforStockVolatility == null)
            {
                return NotFound();
            }

            return dbdataforStockVolatility;
        }

        // PUT: api/DbdataforStockVolatilities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDbdataforStockVolatility(String StockIdTicker, DbdataforStockVolatility stock)
        {
            if (StockIdTicker != stock.StockIdTicker)
            {
                return BadRequest();
            }

            try
            {
                 _DbdataforStockVolatilityRepository.EditStock(stock);
                    await _DbdataforStockVolatilityRepository.Save();
            }
            catch (Exception)
            {
                if (!DbdataforStockVolatilityExists(StockIdTicker))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DbdataforStockVolatilities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DbdataforStockVolatility>> PostDbdataforStockVolatility(DbdataforStockVolatility stock)
        {
            
            try
            {
                 _DbdataforStockVolatilityRepository.AddStock(stock);
                await _DbdataforStockVolatilityRepository.Save();
            }
            catch (Exception)
            {
                if (DbdataforStockVolatilityExists(stock.StockIdTicker))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDbdataforStockVolatility", new { id = stock.StockIdTicker }, stock);
        }

        // DELETE: api/DbdataforStockVolatilities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDbdataforStockVolatility(String StockIdTicker)
        {
            var dbdataforStockVolatility = await _DbdataforStockVolatilityRepository.GetStockById(StockIdTicker);
            if (dbdataforStockVolatility == null)
            {
                return NotFound();
            }

            _DbdataforStockVolatilityRepository.DeleteStock(dbdataforStockVolatility);
            await _DbdataforStockVolatilityRepository.Save();

            return NoContent();
        }

        private bool DbdataforStockVolatilityExists(String StockIdTicker)
        {
            return _DbdataforStockVolatilityRepository.StockExists(StockIdTicker);
        }
    }
}
