﻿using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StockHubApi.Models;

namespace StockHubApi.Interfaces
{
    /// <summary>
    /// Interface definition for <see cref="Stock"/> services.
    /// </summary>
    public interface IStockService
    {
        /// <summary>
        /// Retreives all <see cref="Stock"/>s.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="Stock"/>.</returns>
        IEnumerable<Stock> GetStocks();

        /// <summary>
        /// Retreives a single <see cref="Stock"/> by a given id.
        /// </summary>
        /// <param name="id">The id of the a <see cref="Stock"/> which will be retreived.</param>
        /// <returns>A <see cref="Stock"/> by the given id or null if the id is not found.</returns>
        Stock GetStock(int id);

        /// <summary>
        /// Retreives a single <see cref="Stock"/> by a given id.
        /// The record is not being tracked by the <see cref="ChangeTracker"/>.
        /// </summary>
        /// <param name="id">The id of the a <see cref="Stock"/> which will be retreived.</param>
        /// <returns>A <see cref="Stock"/> by the given id ot null if the id is not found.</returns>
        Stock GetStockAsNoTracking(int id);

        /// <summary>
        /// Creates a single <see cref="Stock"/>.
        /// </summary>
        /// <param name="stock">A instance of a <see cref="Stock"/> which contains which will be created.</param>
        /// <returns>The created <see cref="Stock" /> with it database id, or null if it was not created.</returns>
        Stock CreateStock(Stock stock);

        /// <summary>
        /// Updates a single <see cref="Stock"/>.
        /// </summary>
        /// <param name="stock">A instance of a <see cref="Stock"/> which will be updated with the given values.</param>
        void UpdateStock(Stock stock);

        /// <summary>
        /// Deletes a single <see cref="Stock"/>.
        /// </summary>
        /// <param name="id">The id of the a <see cref="Stock"/> which will be deleted.</param>
        void DeleteStock(int id);
    }
}