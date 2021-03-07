using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using StockHubApi.Interfaces;
using StockHubApi.Models;

namespace StockHubApi.Services
{
    /// <summary>
    /// Handles processing of <see cref="Stock"/>s and calls depending CRUD-operations in a given <see cref="IStockRepository"/>.
    /// </summary>
    public class StockService : IStockService
    {
        private readonly IStockRepository stockRepository;
        private readonly ILogger<IStockService> logger;

        /// <summary>
        /// Creates a new instance of <see cref="StockService"/>.
        /// </summary>
        /// <param name="stockRepository">The via dependency injection loaded implementation of <see cref="IStockRepository"/> on which CRUD-operations can be called.</param>
        /// <param name="logger">The via dependency injection loaded implementation of <see cref="ILogger{TCategoryName}"/>.</param>
        public StockService(IStockRepository stockRepository, ILogger<IStockService> logger)
        {
            this.stockRepository = stockRepository;
            this.logger = logger;
        }

        /// <inheritdoc/>
        public IEnumerable<Stock> GetStocks()
        {
            return stockRepository.GetStocks();
        }

        /// <inheritdoc/>
        public Stock GetStock(int id)
        {
            try
            {
                return stockRepository.GetStock(id);
            }
            catch (InvalidOperationException ex)
            {
                logger.LogError($"Cannot get Stock with id: '{id}'. " + ex);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
            }

            return null;
        }

        /// <inheritdoc/>
        public Stock GetStockAsNoTracking(int id)
        {
            try
            {
                return stockRepository.GetStockAsNoTracking(id);
            }
            catch (InvalidOperationException ex)
            {
                logger.LogError($"Cannot get Stock with id: '{id}'. " + ex);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
            }

            return null;
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