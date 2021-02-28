using System;
using System.Collections.Generic;
using StockHubApi.Interfaces;
using StockHubApi.Models;

namespace StockHubApi.Services
{
    /// <summary>
    /// Handles processing of <see cref="Stock"/>s and calls depending CRUD-operations in a given <see cref="stockRepository"/>.
    /// </summary>
    public class StockService : IStockService
    {
        private readonly IStockRepository stockRepository;

        /// <summary>
        /// Creates a new instance of <see cref="StockService"/>.
        /// </summary>
        /// <param name="stockRepository">The via dependency injection loaded <see cref="stockRepository"/> on which CRUD-operations can be called.</param>
        public StockService(IStockRepository stockRepository)
        {
            this.stockRepository = stockRepository;
        }

        /// <inheritdoc/>
        public IEnumerable<Stock> GetStocks()
        {
            return stockRepository.GetStocks();
        }

        /// <inheritdoc/>
        public Stock GetStock(int id)
        {
            return stockRepository.GetStock(id);
        }

        /// <inheritdoc/>
        public Stock CreateStock(Stock stock)
        {
            if (stock == null)
            {
                throw new ArgumentNullException(nameof(stock));
            }

            return stockRepository.CreateStock(stock);
        }

        /// <inheritdoc/>
        public void UpdateStock(Stock stock)
        {
            if (stock == null)
            {
                throw new ArgumentNullException(nameof(stock));
            }

            stockRepository.UpdateStock(stock);
        }

        /// <inheritdoc/>
        public void DeleteStock(int id)
        {
            stockRepository.DeleteStock(id);
        }
    }
}