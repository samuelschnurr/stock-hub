using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StockHubApi.Interfaces;
using StockHubApi.Models;

namespace StockHubApi.Data
{
    /// <summary>
    /// A repository which provides CRUD-operations for <see cref="Stock"/>s.
    /// </summary>
    public class StockRepository : IStockRepository
    {
        private readonly StockHubDbContext dbContext;

        /// <summary>
        /// The default constructor to create a new instance of <see cref="StockRepository"/>.
        /// </summary>
        /// <param name="dbContext">The via dependency injection loaded <see cref="StockHubDbContext"/> on which CRUD-operations will be executed.</param>
        public StockRepository(StockHubDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            this.dbContext = dbContext;
        }

        /// <inheritdoc/>
        public IEnumerable<Stock> GetStocks()
        {
            return dbContext.Stocks;
        }

        /// <inheritdoc/>
        public Stock GetStock(int id)
        {
            return dbContext.Stocks.Single(s => s.Id == id);
        }

        /// <inheritdoc/>
        public Stock GetStockAsNoTracking(int id)
        {
            return dbContext.Stocks.AsNoTracking().Single(s => s.Id == id);
        }

        /// <inheritdoc/>
        public Stock CreateStock(Stock stock)
        {
            dbContext.Stocks.Add(stock);
            dbContext.SaveChanges();
            return stock;
        }

        /// <inheritdoc/>
        public void UpdateStock(Stock stock)
        {
            dbContext.Stocks.Update(stock);
            dbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public void DeleteStock(int id)
        {
            dbContext.Stocks.Remove(new Stock {Id = id});
            dbContext.SaveChanges();
        }
    }
}