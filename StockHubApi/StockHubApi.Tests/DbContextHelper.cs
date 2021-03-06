using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StockHubApi.Data;
using StockHubApi.Models;

namespace StockHubApi.Tests
{
    /// <summary>
    /// A Helper class to mock <see cref="DbContext"/> classes for testing with InMemory usage.
    /// </summary>
    internal static class DbContextHelper
    {
        #region MockData

        internal static IEnumerable<Stock> Stocks = new List<Stock>
            {
                new() {Id = 1, AcquisitionPricePerUnit = 100, Amount = 20, Name = "Unilever"},
                new() {Id = 2, AcquisitionPricePerUnit = 200, Amount = 10, Name = "Microsoft"},
                new() {Id = 3, AcquisitionPricePerUnit = 300, Amount = 7, Name = "Coca-Cola"},
                new() {Id = 4, AcquisitionPricePerUnit = 400, Amount = 5, Name = "Allianz"},
                new() {Id = 5, AcquisitionPricePerUnit = 2500, Amount = 1, Name = "Amazon"}
            }
            .AsReadOnly();

        #endregion

        /// <summary>
        /// Creates a new instance of a <see cref="DbContextHelper"/> for InMemory usage.
        /// </summary>
        /// <returns>The created InMemory <see cref="StockHubDbContext"/>.</returns>
        internal static StockHubDbContext CreateInMemoryStockHubDbContext()
        {
            string mockDbName = $"{nameof(StockHubDbContext)}_{Guid.NewGuid()}";

            DbContextOptions<StockHubDbContext> dbContextOptions = new DbContextOptionsBuilder<StockHubDbContext>()
                .UseInMemoryDatabase(mockDbName)
                .Options;

            return new StockHubDbContext(dbContextOptions);
        }
    }
}