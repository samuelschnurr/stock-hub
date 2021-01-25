using StockHubApi.Models;

namespace StockHubApi.Data
{
    public class StockRepository
    {
        private StockHubDbContext dbContext;

        public StockRepository(StockHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Stock stock)
        {
            this.dbContext.Stocks.Add(stock);
            this.dbContext.SaveChanges();
        }
    }
}
