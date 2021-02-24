using System.Collections.Generic;
using StockHubApi.Data;
using StockHubApi.Models;

namespace StockHubApi.Services
{
    /// <summary>
    /// Handles processing of <see cref="Stock"/>s and calls depending CRUD-operations in a given <see cref="stockRepository"/>.
    /// </summary>
    public class StockService
    {
        private readonly StockRepository stockRepository;

        /// <summary>
        /// Creates a new instance of <see cref="StockService"/>.
        /// </summary>
        /// <param name="stockRepository">The via dependency injection loaded <see cref="stockRepository"/> on which CRUD-operations can be called.</param>
        public StockService(StockRepository stockRepository)
        {
            this.stockRepository = stockRepository;
        }

        /// <summary>
        /// Retreives all <see cref="Stock"/>s.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="Stock"/>.</returns>
        public IEnumerable<Stock> GetStocks()
        {
            return stockRepository.GetStocks();
        }

        /// <summary>
        /// Retreives a single <see cref="Stock"/> by a given id.
        /// </summary>
        /// <param name="id">The id of the a <see cref="Stock"/> which will be retreived.</param>
        /// <returns>A <see cref="Stock"/> by the given id.</returns>
        public Stock GetStock(int id)
        {
            return stockRepository.GetStock(id);
        }

        /// <summary>
        /// Creates a single <see cref="Stock"/>.
        /// </summary>
        /// <param name="stock">A instance of a <see cref="Stock"/> which contains which will be created.</param>
        /// <returns>The created <see cref="Stock" /> with it database id, or null if it was not created.</returns>
        public Stock CreateStock(Stock stock)
        {
            return stockRepository.CreateStock(stock);
        }

        /// <summary>
        /// Updates a single <see cref="Stock"/>.
        /// </summary>
        /// <param name="stock">A instance of a <see cref="Stock"/> which will be updated with the given values.</param>
        public void UpdateStock(Stock stock)
        {
            stockRepository.UpdateStock(stock);
        }

        /// <summary>
        /// Deletes a single <see cref="Stock"/>.
        /// </summary>
        /// <param name="id">The id of the a <see cref="Stock"/> which will be deleted.</param>
        public void DeleteStock(int id)
        {
            stockRepository.DeleteStock(id);
        }
    }
}