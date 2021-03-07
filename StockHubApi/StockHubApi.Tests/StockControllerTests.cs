using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using StockHubApi.Controllers;
using StockHubApi.Interfaces;
using StockHubApi.Models;

namespace StockHubApi.Tests
{
    /// <summary>
    /// Class for testing the controller used by <see cref="Stock"/>s.
    /// </summary>
    [TestFixture(Author = "Samuel Schnurr")]
    public class StockControllerTests
    {
        private Mock<IStockService> mockStockService;
        private IStockController stockController;

        /// <summary>
        /// Setup mock data and configuration immediately before each test runs.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // Initialize entity which is going to be tested
            mockStockService = new Mock<IStockService>();
            stockController = new StockController(mockStockService.Object);

            // Setup in which cases functions will return a valid result
            mockStockService.Setup(stockService =>
                    stockService.GetStock(It.IsAny<int>()))
                .Returns((int id) => DbContextHelper.Stocks.Single(s => s.Id == id));

            mockStockService.Setup(stockService =>
                    stockService.GetStockAsNoTracking(It.IsAny<int>()))
                .Returns((int id) => DbContextHelper.Stocks.Single(s => s.Id == id));

            mockStockService.Setup(stockService =>
                stockService.GetStocks()).Returns(() => DbContextHelper.Stocks);

            // Setup in which cases functions will return null or throw exceptions
            mockStockService.Setup(stockService =>
                    stockService.GetStock(It.Is<int>(i => i <= 0 || i > DbContextHelper.Stocks.Count())))
                .Returns(() => null);

            mockStockService.Setup(stockService =>
                    stockService.GetStockAsNoTracking(It.Is<int>(i => i <= 0 || i > DbContextHelper.Stocks.Count())))
                .Returns(() => null);

            mockStockService.Setup(stockService =>
                    stockService.CreateStock(It.Is<Stock>(s => s == null)))
                .Throws(new ArgumentNullException());

            mockStockService.Setup(stockService =>
                    stockService.UpdateStock(It.Is<Stock>(s => s == null)))
                .Throws(new ArgumentNullException());

            mockStockService.Setup(stockService =>
                    stockService.UpdateStock(It.Is<Stock>(s => s.Id <= 0)))
                .Throws(new InvalidOperationException());

            mockStockService.Setup(stockService =>
                    stockService.DeleteStock(It.Is<int>(i => i <= 0 || i > DbContextHelper.Stocks.Count())))
                .Throws(new InvalidOperationException());
        }

        /// <summary>
        /// Tests if a <see cref="OkObjectResult"/> is returned when no id is provided for querying.
        /// </summary>
        [Test]
        public void Index_WhenMethodIsCalled_Expect_OkObjectResult()
        {
            // Act
            IActionResult result = stockController.Index();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(typeof(OkObjectResult), result.GetType());
            mockStockService.Verify(stockService => stockService.GetStocks(), Times.Once);
        }

        /// <summary>
        /// Tests if a <see cref="OkObjectResult"/> is returned when a valid id is provided for showing a <see cref="Stock"/>.
        /// </summary>
        /// <param name="id">The id of the <see cref="Stock"/> which should be returned.</param>
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void Show_When_IdIsValid_Expect_OkObjectResult(int id)
        {
            // Act
            IActionResult result = stockController.Show(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(OkObjectResult), result.GetType());
            mockStockService.Verify(stockService => stockService.GetStockAsNoTracking(id), Times.Once);
        }

        /// <summary>
        /// Tests if a <see cref="NotFoundResult"/> is returned if the given id is not a valid id of a <see cref="Stock"/>.
        /// </summary>
        /// <param name="id">The id of the <see cref="Stock"/> which should be returned.</param>
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(5000)]
        public void Show_When_IdIsInValid_Expect_NotFoundResult(int id)
        {
            // Act
            IActionResult result = stockController.Show(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(NotFoundResult), result.GetType());
            mockStockService.Verify(stockService => stockService.GetStockAsNoTracking(id), Times.Once);
        }

        /// <summary>
        /// Tests if a exception is thrown if the <see cref="Stock"/> which should be created is null.
        /// </summary>
        [Test]
        public void Create_WhenStockIsNull_Expect_ArgumentNullException()
        {
            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => stockController.Create(null));
            mockStockService.Verify(stockService => stockService.CreateStock(null), Times.Once);
        }

        /// <summary>
        /// Tests if a <see cref="CreatedResult"/> is returned when a valid <see cref="Stock"/> is provided.
        /// </summary>
        [Test]
        public void Create_WhenStockIsValid_Expect_CreatedResult()
        {
            // Arrange
            Stock stock = new()
            {
                AcquisitionPricePerUnit = 2500,
                Name = "Amazon",
                Amount = 2
            };

            // Act
            IActionResult result = stockController.Create(stock);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(typeof(CreatedResult), result.GetType());
            mockStockService.Verify(stockService => stockService.CreateStock(stock), Times.Once);
        }

        /// <summary>
        /// Tests if a <see cref="BadRequestObjectResult"/> is returned if the <see cref="Stock"/> which should be updated is null.
        /// </summary>
        [Test]
        public void Update_WhenStockIsNull_Expect_BadRequestObjectResult()
        {
            // Act
            IActionResult result = stockController.Update(null);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(typeof(BadRequestObjectResult), result.GetType());
            mockStockService.Verify(stockService => stockService.UpdateStock(null), Times.Never);
        }

        /// <summary>
        /// Tests if a <see cref="NoContentResult"/> is returned if the <see cref="Stock"/> which should be updated is valid.
        /// </summary>
        [Test]
        public void Update_WhenStockIsValid_Expect_NoContentResult()
        {
            // Arrange
            Stock stock = new()
            {
                Id = 1,
                AcquisitionPricePerUnit = 2500,
                Name = "UPDATED",
                Amount = 2
            };

            // Act
            IActionResult result = stockController.Update(stock);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(typeof(NoContentResult), result.GetType());
            mockStockService.Verify(stockService => stockService.GetStockAsNoTracking(stock.Id), Times.Once);
            mockStockService.Verify(stockService => stockService.UpdateStock(stock), Times.Once);
        }

        /// <summary>
        /// Tests if a <see cref="NotFoundResult"/> is returned when a invalid id is provided for deleting a <see cref="Stock"/>.
        /// </summary>
        /// <param name="id">The id of the <see cref="Stock"/> which should be deleted.</param>
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(5000)]
        public void Delete_When_IdIsInValid_Expect_NotFoundResult(int id)
        {
            // Act
            IActionResult result = stockController.Delete(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(NotFoundResult), result.GetType());
            mockStockService.Verify(stockService => stockService.GetStockAsNoTracking(id), Times.Once);
            mockStockService.Verify(stockService => stockService.DeleteStock(id), Times.Never);
        }

        /// <summary>
        /// Tests if a <see cref="OkResult"/> is returned when a valid id is provided for deleting a <see cref="Stock"/>.
        /// </summary>
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void DeleteStock_WhenIdIsValid_Expect_OkResult(int id)
        {
            // Act
            IActionResult result = stockController.Delete(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(OkResult), result.GetType());
            mockStockService.Verify(stockService => stockService.GetStockAsNoTracking(id), Times.Once);
            mockStockService.Verify(stockService => stockService.DeleteStock(id), Times.Once);
        }
    }
}