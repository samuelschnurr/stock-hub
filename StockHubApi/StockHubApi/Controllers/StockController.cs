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
        StockService stockService;

        public StockController(StockService stockService)
        {
            this.stockService = stockService;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void New(Stock stock)
        {
            stockService.Create(stock);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
