using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StockHubApi.Models;

namespace StockHubApi.Interfaces
{
    /// <summary>
    /// Interface definition for <see cref="Stock"/> controllers.
    /// </summary>
    public interface IStockController
    {
        /// <summary>
        /// Retreives all <see cref="Stock" />s.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}" /> of <see cref="Stock" />.</returns>
        IActionResult Index();

        /// <summary>
        /// Retreives a single <see cref="Stock" /> by a given id.
        /// </summary>
        /// <param name="id">The id of the a <see cref="Stock" /> which will be retreived.</param>
        /// <returns>A <see cref="Stock" /> by the given id.</returns>
        IActionResult Show(int id);

        /// <summary>
        /// Creates a single <see cref="Stock" />.
        /// </summary>
        /// <param name="stock">A instance of a <see cref="Stock" /> which contains which will be created.</param>
        IActionResult Create(Stock stock);

        /// <summary>
        /// Updates a single <see cref="Stock" />.
        /// </summary>
        /// <param name="stock">A instance of a <see cref="Stock" /> which will be updated with the given values.</param>
        IActionResult Update(Stock stock);

        /// <summary>
        /// Deletes a single <see cref="Stock" />.
        /// </summary>
        /// <param name="id">The id of the a <see cref="Stock" /> which will be deleted.</param>
        IActionResult Delete(int id);
    }
}