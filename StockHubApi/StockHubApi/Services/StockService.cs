using StockHubApi.Data;
using StockHubApi.Models;
using System.Collections.Generic;

namespace StockHubApi.Services
{
    public class StockService
    {
        private StockRepository stockRepository;

        public StockService(StockRepository stockRepository)
        {
            this.stockRepository = stockRepository;
        }

        public IEnumerable<Stock> GetStocks()
        {
            return stockRepository.GetStocks();
        }

        public Stock GetStock(int id)
        {
            return stockRepository.GetStock(id);
        }

        public void CreateStock(Stock stock)
        {
            stockRepository.CreateStock(stock);
        }

        public void UpdateStock(Stock stock)
        {
            stockRepository.UpdateStock(stock);
        }

        public void DeleteStock(int id)
        {
            stockRepository.DeleteStock(id);
        }
    }
}
