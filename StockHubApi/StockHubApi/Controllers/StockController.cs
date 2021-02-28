using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StockHubApi.Interfaces;
using StockHubApi.Models;

namespace StockHubApi.Controllers
{
    /// <summary>
    /// Processes operations on <see cref="Stock"/>s.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase, IStockController
    {
        private readonly IStockService stockService;

        /// <summary>
        /// The default constructor for creating a new instance of <see cref="StockController" />.
        /// </summary>
        /// <param name="stockService">The via dependency injection loaded implementation of <see cref="IStockService" />.</param>
        public StockController(IStockService stockService)
        {
            this.stockService = stockService;
        }

        /// <inheritdoc/>
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public IActionResult Index()
        {
            IEnumerable<Stock> stocks = stockService.GetStocks();

            if (stocks == null || !stocks.Any())
            {
                return NotFound();
            }

            return Ok(stocks);
        }

        /// <inheritdoc/>
        [HttpGet("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public IActionResult Show(int id)
        {
            Stock stock = stockService.GetStock(id);

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock);
        }

        /// <inheritdoc/>
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Create))]
        public IActionResult Create(Stock stock)
        {
            Stock dbStock = stockService.CreateStock(stock);
            return Created(new Uri("/Stock", UriKind.Relative), dbStock);
        }

        /// <inheritdoc/>
        [HttpPut("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public IActionResult Update(Stock stock)
        {
            stockService.UpdateStock(stock);
            return NoContent();
        }

        /// <inheritdoc/>
        [HttpDelete("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public IActionResult Delete(int id)
        {
            stockService.DeleteStock(id);
            return Ok();
        }
    }
}