using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using StockHubApi.Data;
using StockHubApi.Interfaces;
using StockHubApi.Models;

namespace StockHubApi.Tests
{
    /// <summary>
    /// Class for testing the data layer used by <see cref="Stock"/>s.
    /// </summary>
    [TestFixture(Author = "Samuel Schnurr")]
    internal class StockRepositoryTests
    {
        private StockHubDbContext dbContext;
        private IStockRepository stockRepository;

        /// <summary>
        /// Setup mock data and configuration immediately before each test is run
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // Setup instance of DbContext for InMemory usage
            dbContext = DbContextHelper.CreateInMemoryStockHubDbContext();

            // Setup mock data for InMemory usage of DbContext
            dbContext.Stocks.AddRange(DbContextHelper.Stocks);
            dbContext.SaveChanges();

            // Remove ChangeTrackers of the AddRange Method
            foreach (var entity in dbContext.ChangeTracker.Entries())
            {
                entity.State = EntityState.Detached;
            }

            // Setup repository to use InMemoryStockHubDbContext
            stockRepository = new StockRepository(dbContext);
        }

        /// <summary>
        /// Tests if a corresponding <see cref="Stock"/> is returned with the given valid id.
        /// </summary>
        /// <param name="id">The id of the <see cref="Stock"/> which should be returned.</param>
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void GetStock_When_IdIsValid_Expect_StockWithGivenId(int id)
        {
            // Act
            Stock stock = stockRepository.GetStock(id);

            // Assert
            Assert.IsNotNull(stock);
            Assert.AreEqual(id, stock.Id);
        }

        /// <summary>
        /// Tests if a exception is thrown if the given if doesnt exist in the database.
        /// </summary>
        /// <param name="id">The id of the <see cref="Stock"/> which should be returned.</param>
        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(999999)]
        public void GetStock_When_IdIsValidButDoesntExist_Expect_InvalidOperationException(int id)
        {
            // Act, Assert
            Assert.Throws<InvalidOperationException>(() => stockRepository.GetStock(id));
        }

        /// <summary>
        /// Tests if a a exception is thrown if the given id is not valid for database querying for getting a <see cref="Stock"/>.
        /// </summary>
        /// <param name="id">The id of the <see cref="Stock"/> which should be returned.</param>
        [TestCase(0)]
        [TestCase(-1)]
        public void GetStock_When_IdIsInValid_Expect_InvalidOperationException(int id)
        {
            // Assert
            Assert.Throws<InvalidOperationException>(() => stockRepository.GetStock(id));
        }

        /// <summary>
        /// Tests if a <see cref="List{T}"/> is returned where T is <see cref="Stock"/> when no id is provided for querying.
        /// </summary>
        [Test]
        public void GetStocks_WhenMethodIsCalled_Expect_ListOfStocks()
        {
            // Act
            List<Stock> stocks = stockRepository.GetStocks().ToList();

            // Assert
            Assert.NotNull(stocks);
            Assert.AreEqual(5, stocks.Count);
        }

        /// <summary>
        /// Tests if a exception is thrown if the <see cref="Stock"/> which should be created is null.
        /// </summary>
        [Test]
        public void CreateStock_WhenStockIsNull_Expect_ArgumentNullException()
        {
            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => stockRepository.CreateStock(null));
        }

        /// <summary>
        /// Tests if the <see cref="Stock"/> is created when the creation data is valid.
        /// </summary>
        [Test]
        public void CreateStock_WhenStockIsValid_Expect_StockWithCreatedId()
        {
            // Arrange
            int stockCountOld = dbContext.Stocks.Count();

            Stock stock = new()
            {
                AcquisitionPricePerUnit = 777,
                Name = "New Stock",
                Amount = 5
            };

            // Act
            Stock createdStock = stockRepository.CreateStock(stock);
            int stockCountNew = dbContext.Stocks.Count();

            // Assert
            Assert.NotNull(createdStock);
            Assert.Greater(createdStock.Id, 0);
            Assert.Greater(createdStock.Id, stockCountOld);
            Assert.AreEqual(stockCountOld + 1, stockCountNew);
        }

        /// <summary>
        /// Tests if a exception is thrown if the <see cref="Stock"/> which should be updated is null.
        /// </summary>
        [Test]
        public void UpdateStock_WhenStockIsNull_Expect_ArgumentNullException()
        {
            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => stockRepository.UpdateStock(null));
        }

        /// <summary>
        /// Tests if the <see cref="Stock"/> which should be updated is updated correctly.
        /// </summary>
        /// <param name="id">The id of the <see cref="Stock"/> which should be updated.</param>
        /// <param name="acquisitionPricePerUnit">The value which will be updated for the <see cref="Stock"/>.</param>
        /// <param name="amount">The value which will be updated for the <see cref="Stock"/>.</param>
        [TestCase(1, 9999, 8888)]
        [TestCase(2, 7777, 6666)]
        [TestCase(3, 5555, 4444)]
        [TestCase(4, 3333, 2222)]
        [TestCase(5, 1111, 1111)]
        public void UpdateStock_WhenStockIsValid_Expect_StockWithNewValues(int id, int acquisitionPricePerUnit,
            int amount)
        {
            // Arrange
            Stock stock = stockRepository.GetStock(id);
            stock.Name = "UPDATED";
            stock.AcquisitionPricePerUnit = acquisitionPricePerUnit;
            stock.Amount = amount;

            // Act
            stockRepository.UpdateStock(stock);
            Stock updatedStock = stockRepository.GetStock(id);

            // Assert
            Assert.NotNull(stock);
            Assert.NotNull(updatedStock);
            Assert.AreEqual(stock.Id, updatedStock.Id);
            Assert.AreEqual(updatedStock.Name, "UPDATED");
            Assert.AreEqual(updatedStock.AcquisitionPricePerUnit, acquisitionPricePerUnit);
            Assert.AreEqual(updatedStock.Amount, amount);
        }

        /// <summary>
        /// Tests if a exception is thrown if the id of the <see cref="Stock"/> which should be deleted is not valid for database querying.
        /// </summary>
        /// <param name="id">The id of the <see cref="Stock"/> which should be returned.</param>
        [TestCase(0)]
        [TestCase(-1)]
        public void DeleteStock_When_IdIsInValid_Expect_DbUpdateConcurrencyException(int id)
        {
            // Act, Assert
            Assert.Throws<DbUpdateConcurrencyException>(() => stockRepository.DeleteStock(id));
        }

        /// <summary>
        /// Tests if the <see cref="Stock"/> is deleted correctly.
        /// </summary>
        /// <param name="id">The id of the <see cref="Stock"/> which should be deleted.</param>
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void DeleteStock_WhenIdIsValid_Expect_StocksWithoutDeletedStock(int id)
        {
            // Act
            stockRepository.DeleteStock(id);
            List<Stock> stocks = stockRepository.GetStocks().ToList();

            // Assert
            Assert.NotNull(stocks);
            Assert.Greater(stocks.Count, 0);
            Assert.That(!stocks.Any(s => s.Id == id));
        }
    }
}