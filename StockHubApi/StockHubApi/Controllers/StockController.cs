using Microsoft.AspNetCore.Mvc;
using StockHubApi.Models;
using StockHubApi.Services;
using System.Collections.Generic;

namespace StockHubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private StockService stockService;

        public StockController(StockService stockService)
        {
            this.stockService = stockService;
        }

        [HttpGet]
        public IEnumerable<Stock> Index()
        {
            return stockService.GetStocks();
        }

        [HttpGet("{id}")]
        public Stock Show(int id)
        {
            return stockService.GetStock(id);
        }

        [HttpPost]
        public void Create(Stock stock)
        {
            stockService.CreateStock(stock);
        }

        [HttpPut("{id}")]
        public void Update(Stock stock)
        {
            stockService.UpdateStock(stock);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            stockService.DeleteStock(id);
        }
    }
}
