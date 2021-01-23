using Microsoft.EntityFrameworkCore;
using StockHubApi.Models;

namespace StockHubApi.Data
{
    public class StockHubDbContext : DbContext
    {
        public StockHubDbContext(DbContextOptions<StockHubDbContext> options) : base(options)
        { }

        public DbSet<Stock> Stocks { get; set; }
    }
}
