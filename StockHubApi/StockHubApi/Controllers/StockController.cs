using Microsoft.AspNetCore.Mvc;
using StockHubApi.Models;
using StockHubApi.Services;
using System.Collections.Generic;

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
        /// The default constructor for creating a new instance of <see cref="StockController"/>.
        /// </summary>
        /// <param name="stockService">The via dependency injection loaded <see cref="stockService"/>.</param>
        public StockController(StockService stockService)
        {
            this.stockService = stockService;
        }

        /// <summary>
        /// Retreives all <see cref="Stock"/>s.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="Stock"/>.</returns>
        [HttpGet]
        public IEnumerable<Stock> Index()
        {
            return stockService.GetStocks();
        }

        /// <summary>
        /// Retreives a single <see cref="Stock"/> by a given id.
        /// </summary>
        /// <param name="id">The id of the a <see cref="Stock"/> which will be retreived.</param>
        /// <returns>A <see cref="Stock"/> by the given id.</returns>
        [HttpGet("{id}")]
        public Stock Show(int id)
        {
            return stockService.GetStock(id);
        }

        /// <summary>
        /// Creates a single <see cref="Stock"/>.
        /// </summary>
        /// <param name="stock">A instance of a <see cref="Stock"/> which contains which will be created.</param>
        [HttpPost]
        public void Create(Stock stock)
        {
            stockService.CreateStock(stock);
        }

        /// <summary>
        /// Updates a single <see cref="Stock"/>.
        /// </summary>
        /// <param name="stock">A instance of a <see cref="Stock"/> which will be updated with the given values.</param>
        [HttpPut("{id}")]
        public void Update(Stock stock)
        {
            stockService.UpdateStock(stock);
        }

        /// <summary>
        /// Deletes a single <see cref="Stock"/>.
        /// </summary>
        /// <param name="id">The id of the a <see cref="Stock"/> which will be deleted.</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            stockService.DeleteStock(id);
        }
    }
}