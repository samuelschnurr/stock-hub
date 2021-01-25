using StockHubApi.Data;
using StockHubApi.Models;

namespace StockHubApi.Services
{
    public class StockService
    {
        StockRepository stockRepository;

        public StockService(StockRepository stockRepository)
        {
            this.stockRepository = stockRepository;
        }

        public void Create(Stock stock)
        {
            stockRepository.Create(stock);
        }
    }
}
