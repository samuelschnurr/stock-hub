using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StockHubApi.Models;
using StockHubApi.Services;

namespace StockHubApi.Controllers
{
    /// <summary>
    /// Processes operations on <see cref="Stock"/>s.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly StockService stockService;

        /// <summary>
        /// The default constructor for creating a new instance of <see cref="StockController" />.
        /// </summary>
        /// <param name="stockService">The via dependency injection loaded <see cref="stockService" />.</param>
        public StockController(StockService stockService)
        {
            this.stockService = stockService;
        }

        /// <summary>
        /// Retreives all <see cref="Stock" />s.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}" /> of <see cref="Stock" />.</returns>
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

        /// <summary>
        /// Retreives a single <see cref="Stock" /> by a given id.
        /// </summary>
        /// <param name="id">The id of the a <see cref="Stock" /> which will be retreived.</param>
        /// <returns>A <see cref="Stock" /> by the given id.</returns>
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

        /// <summary>
        /// Creates a single <see cref="Stock" />.
        /// </summary>
        /// <param name="stock">A instance of a <see cref="Stock" /> which contains which will be created.</param>
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Create))]
        public IActionResult Create(Stock stock)
        {
            Stock dbStock = stockService.CreateStock(stock);
            return Created(new Uri("/Stock", UriKind.Relative), dbStock);
        }

        /// <summary>
        /// Updates a single <see cref="Stock" />.
        /// </summary>
        /// <param name="stock">A instance of a <see cref="Stock" /> which will be updated with the given values.</param>
        [HttpPut("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public IActionResult Update(Stock stock)
        {
            stockService.UpdateStock(stock);
            return NoContent();
        }

        /// <summary>
        /// Deletes a single <see cref="Stock" />.
        /// </summary>
        /// <param name="id">The id of the a <see cref="Stock" /> which will be deleted.</param>
        [HttpDelete("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public IActionResult Delete(int id)
        {
            Stock databaseStock = stockService.GetStock(id);

            if (databaseStock == null)
            {
                return NotFound();
            }

            stockService.DeleteStock(id);

            return Ok();
        }
    }
}