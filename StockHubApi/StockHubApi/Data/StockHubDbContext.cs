using Microsoft.EntityFrameworkCore;
using StockHubApi.Models;

namespace StockHubApi.Data
{
    /// <summary>
    /// A instance of <see cref="DbContext"/> to provide access to entities which are defined in the <see cref="Models"/> namespace.
    /// </summary>
    public class StockHubDbContext : DbContext
    {
        /// <summary>
        /// The default constructor to create a new instance of <see cref="StockHubDbContext"/>.
        /// </summary>
        /// <param name="options">Can be used for configuring the <see cref="DbContext"/> and will be passed to the base implementation.</param>
        public StockHubDbContext(DbContextOptions<StockHubDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// The database abstraction of <see cref="Stock"/>s as <see cref="DbSet{TEntity}"/>.
        /// </summary>
        public DbSet<Stock> Stocks { get; set; }
    }
}