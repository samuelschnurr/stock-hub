using StockHubApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace StockHubApi.Data
{
    public class StockRepository
    {
        private StockHubDbContext dbContext;

        public StockRepository(StockHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Stock> GetStocks()
        {
            return dbContext.Stocks;
        }

        public Stock GetStock(int id)
        {
            return dbContext.Stocks.Single(s => s.Id == id);
        }

        public void CreateStock(Stock stock)
        {
            dbContext.Stocks.Add(stock);
            dbContext.SaveChanges();
        }

        public void UpdateStock(Stock stock)
        {
            dbContext.Stocks.Update(stock);
            dbContext.SaveChanges();
        }

        public void DeleteStock(int id)
        {
            dbContext.Stocks.Remove(new Stock() { Id = id });
            dbContext.SaveChanges();
        }
    }
}
