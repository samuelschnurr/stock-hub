using System.Collections.Generic;
using System.Linq;
using StockHubApi.Models;

namespace StockHubApi.Data
{
    /// <summary>
    /// A repository which provides CRUD-operations for <see cref="Stock"/>s.
    /// </summary>
    public class StockRepository
    {
        private readonly StockHubDbContext dbContext;

        /// <summary>
        /// The default constructor to create a new instance of <see cref="StockRepository"/>.
        /// </summary>
        /// <param name="dbContext">The via dependency injection loaded <see cref="StockHubDbContext"/> on which CRUD-operations will be executed.</param>
        public StockRepository(StockHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Retreives all <see cref="Stock"/>s.
        /// </summary>
        /// <returns>All <see cref="IEnumerable{T}"/> of <see cref="Stock"/>s.</returns>
        public IEnumerable<Stock> GetStocks()
        {
            return dbContext.Stocks;
        }

        /// <summary>
        /// Retreives a single <see cref="Stock"/> by a given id.
        /// </summary>
        /// <param name="id">The id of the a <see cref="Stock"/> which will be retreived.</param>
        /// <returns>A <see cref="Stock"/> by the given id.</returns>
        public Stock GetStock(int id)
        {
            return dbContext.Stocks.Single(s => s.Id == id);
        }

        /// <summary>
        /// Creates a single <see cref="Stock"/> and persists the changes.
        /// </summary>
        /// <param name="stock">The <see cref="Stock"/> which will be created.</param>
        /// <returns>The created <see cref="Stock" /> with it database id, or null if it was not created.</returns>
        public Stock CreateStock(Stock stock)
        {
            dbContext.Stocks.Add(stock);
            dbContext.SaveChanges();
            return stock;
        }

        /// <summary>
        /// Updates a single <see cref="Stock"/> and persists the changes.
        /// </summary>
        /// <param name="stock">The <see cref="Stock"/> which will be updated with the given values.</param>
        public void UpdateStock(Stock stock)
        {
            dbContext.Stocks.Update(stock);
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Deletes a single <see cref="Stock"/> and persists the changes.
        /// </summary>
        /// <param name="id">The id of the <see cref="Stock"/> which will be deleted with the given values.</param>
        public void DeleteStock(int id)
        {
            dbContext.Stocks.Remove(new Stock {Id = id});
            dbContext.SaveChanges();
        }
    }
}