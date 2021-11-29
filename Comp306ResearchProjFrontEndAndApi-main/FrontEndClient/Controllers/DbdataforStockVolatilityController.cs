using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APItry1FRONTEND.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;


namespace APItry1FRONTEND.Controllers
{

    public class DbdataforStockVolatilityController : Controller
    {
        HttpClient client;
        string baseUrl;
        string apiKey;

        public DbdataforStockVolatilityController()
        {
            client = new HttpClient();
            baseUrl = "http://webapiclientelasticbean-dev.us-east-1.elasticbeanstalk.com/api/DbdataforStockVolatilities/";
           // apiKey = "";
        }

        [HttpGet]
        public async Task<IActionResult> ListOfStocks()
        {
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // client.DefaultRequestHeaders.Add("apikey", apiKey);
            IEnumerable<DbdataforStockVolatility> DbdataforStockVolatilityList = new List<DbdataforStockVolatility>();

            HttpResponseMessage response = await client.GetAsync(baseUrl);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                DbdataforStockVolatilityList = JsonConvert.DeserializeObject<IEnumerable<DbdataforStockVolatility>>(json);
            }

            return View(DbdataforStockVolatilityList);
        }

        [HttpGet]
        public async Task<IActionResult> ViewStockDetails (string stockTickerId)
        {

            var stock = await GetStockById(stockTickerId);
            return View("StockDetail", stock);
        }

        public async Task<DbdataforStockVolatility> GetStockById(string stockTickerId)
        {
            var newUrl = baseUrl + $"{stockTickerId}?StockIdTicker={stockTickerId}";
            client.BaseAddress = new Uri(newUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // client.DefaultRequestHeaders.Add("apikey", apiKey);
            DbdataforStockVolatility Stock = null;

            HttpResponseMessage response = await client.GetAsync(newUrl);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                // convert json to joboffers object
                Stock = JsonConvert.DeserializeObject<DbdataforStockVolatility>(json);
            }
            return Stock;
        }

        [HttpGet]
        public async Task<IActionResult> EditStock(string stockTickerId)
        {
            var stock = await GetStockById(stockTickerId);
            return View("EditStock", stock);
        }

        [HttpPost]
        public async Task<IActionResult> EditStock(DbdataforStockVolatility stock)
        {

            var newUrl = $"{stock.stockIdTicker}?StockIdTicker={stock.stockIdTicker}";

            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var json = JsonConvert.SerializeObject(stock);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(newUrl, content);
            response.EnsureSuccessStatusCode();

            //client.DefaultRequestHeaders.Add("apikey", apiKey);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> AddStock()
        {
            return View("AddStock");
        }

        [HttpPost]
        public async Task<IActionResult> AddStock(DbdataforStockVolatility stock)
        {
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var json = JsonConvert.SerializeObject(stock);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(baseUrl, content);
            response.EnsureSuccessStatusCode();

            //client.DefaultRequestHeaders.Add("apikey", apiKey);

            return RedirectToAction("ListOfStocks");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteStock(string stockTickerId)
        {
            var newUrl = baseUrl + $"{stockTickerId}?StockIdTicker={stockTickerId}";
            client.BaseAddress = new Uri(newUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // client.DefaultRequestHeaders.Add("apikey", apiKey);

            HttpResponseMessage response = await client.DeleteAsync(newUrl);
            response.EnsureSuccessStatusCode();

            return RedirectToAction("ListOfStocks");
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
