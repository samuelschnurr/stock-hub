using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using StockHubApi.Interfaces;
using StockHubApi.Models;
using StockHubApi.Services;

namespace StockHubApi.Tests
{
    /// <summary>
    /// Class for testing the service layer used by <see cref="Stock"/>s.
    /// </summary>
    [TestFixture(Author = "Samuel Schnurr")]
    public class StockServiceTests
    {
        private readonly Mock<IStockRepository> mockStockRepository = new();
        private IStockService stockService;
        private Stock validStock;
        private List<Stock> stocks;

        [SetUp]
        public void Setup()
        {
            // Setup instance of a valid stock which will be returned for valid service method calls
            validStock = new Stock
            {
                Id = 1,
                AcquisitionPricePerUnit = 155.50,
                Amount = 15,
                Name = "Microsoft"
            };
            stocks = new List<Stock> {validStock};

            // Setup in which cases functions will return a valid result
            mockStockRepository.Setup(stockRepository => stockRepository.GetStock(It.IsAny<int>())).Returns(validStock);
            mockStockRepository.Setup(stockRepository => stockRepository.GetStocks())
                .Returns(new List<Stock> {validStock});
            mockStockRepository.Setup(stockRepository => stockRepository.CreateStock(It.IsNotNull<Stock>()))
                .Callback((Stock stock) => stocks.Add(stock))
                .Returns(() => stocks.Last());
            mockStockRepository.Setup(stockRepository => stockRepository.UpdateStock(It.IsNotNull<Stock>()))
                .Callback((Stock stock) => validStock = stock);
            mockStockRepository.Setup(stockRepository => stockRepository.DeleteStock(It.IsAny<int>()))
                .Callback((int id) => stocks = stocks.Where(s => s.Id != id).ToList());

            // Setup in which cases functions will throw an exception
            mockStockRepository.Setup(stockRepository => stockRepository.GetStock(It.Is<int>(i => i <= 0)))
                .Throws(new InvalidOperationException());
            mockStockRepository.Setup(stockRepository => stockRepository.DeleteStock(It.Is<int>(i => i <= 0)))
                .Throws(new InvalidOperationException());

            // Initialize entity which is going to be tested
            stockService = new StockService(mockStockRepository.Object);
        }

        [Test]
        public void GetStock_When_IdIsValid_Expect_StockIsNotNull()
        {
            // Arrange
            int id = validStock.Id;

            // Act
            Stock stock = stockService.GetStock(id);

            // Assert
            Assert.IsNotNull(stock);
            Assert.AreEqual(id, stock.Id);

            // Verify repository method has been called exactly one time
            mockStockRepository.Verify(stockRepository => stockRepository.GetStock(id), Times.Once);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void GetStock_When_IdIsInValid_Expect_ArgumentOutOfRangeException(int id)
        {
            // Arrange, Act, Assert
            Assert.Throws<InvalidOperationException>(() => stockService.GetStock(id));
            mockStockRepository.Verify(stockRepository => stockRepository.GetStock(id), Times.Once);
        }

        [Test]
        public void GetStocks_WhenMethodIsCalled_Expect_ListOfStocks()
        {
            // Arrange, Act
            List<Stock> stocks = stockService.GetStocks().ToList();

            // Assert
            Assert.NotNull(stocks);
            Assert.GreaterOrEqual(1, stocks.Count);
            mockStockRepository.Verify(stockRepository => stockRepository.GetStocks(), Times.Once);
        }

        [Test]
        public void CreateStock_WhenStockIsNull_Expect_ArgumentNullException()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => stockService.CreateStock(null));
            mockStockRepository.Verify(stockRepository => stockRepository.CreateStock(null), Times.Never);
        }

        [Test]
        public void CreateStock_WhenStockIsValid_Expect_StockWithCreatedId()
        {
            // Arrange
            int stockCountOld = stocks.Count;

            Stock stock = new()
            {
                Id = 999,
                AcquisitionPricePerUnit = 2500,
                Name = "Amazon",
                Amount = 2
            };

            // Act
            Stock createdStock = stockService.CreateStock(stock);

            // Assert
            Assert.NotNull(createdStock);
            Assert.AreEqual(createdStock.Id, stock.Id);
            Assert.Less(stockCountOld, stocks.Count);
            mockStockRepository.Verify(stockRepository => stockRepository.CreateStock(stock), Times.Once);
        }

        [Test]
        public void UpdateStock_WhenStockIsNull_Expect_ArgumentNullException()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => stockService.UpdateStock(null));
            mockStockRepository.Verify(stockRepository => stockRepository.UpdateStock(null), Times.Never);
        }

        [Test]
        public void UpdateStock_WhenStockIsValid_Expect_StockWithNewValues()
        {
            // Arrange
            int validStockOldId = validStock.Id;
            string validStockOldName = validStock.Name;
            double validStockOldAcquisitionPricePerUnit = validStock.AcquisitionPricePerUnit;
            double validStockOldAmount = validStock.Amount;

            Stock stock = new()
            {
                Id = validStock.Id,
                AcquisitionPricePerUnit = 999,
                Amount = 999,
                Name = "UPDATED"
            };

            // Act
            stockService.UpdateStock(stock);

            // Assert
            Assert.NotNull(validStock);
            Assert.AreEqual(validStock.Name, "UPDATED");
            Assert.AreEqual(validStockOldId, validStock.Id);
            Assert.AreNotEqual(validStockOldName, validStock.Name);
            Assert.AreNotEqual(validStockOldAcquisitionPricePerUnit, validStock.AcquisitionPricePerUnit);
            Assert.AreNotEqual(validStockOldAmount, validStock.Amount);
            mockStockRepository.Verify(stockRepository => stockRepository.UpdateStock(stock), Times.Once);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void DeleteStock_When_IdIsInValid_Expect_ArgumentOutOfRangeException(int id)
        {
            // Arrange, Act, Assert
            Assert.Throws<InvalidOperationException>(() => stockService.DeleteStock(id));
            mockStockRepository.Verify(stockRepository => stockRepository.DeleteStock(id), Times.Once);
        }

        [Test]
        public void DeleteStock_WhenIdIsValid_Expect_StocksWithoutDeletedStock()
        {
            // Arrange
            int stockCountOld = stocks.Count;
            int id = validStock.Id;

            // Act
            stockService.DeleteStock(id);

            // Assert
            Assert.NotNull(stocks);
            Assert.Less(stocks.Count, stockCountOld);
            Assert.That(!stocks.Any(s => s.Id == id));
            mockStockRepository.Verify(stockRepository => stockRepository.DeleteStock(id), Times.Once);
        }
    }
}