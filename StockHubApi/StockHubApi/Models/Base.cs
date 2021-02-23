using System.ComponentModel.DataAnnotations;

namespace StockHubApi.Models
{
    /// <summary>
    /// The <see cref="Base"/> database abstraction for models.
    /// Contains properties which should be applied to all models via inheritance.
    /// </summary>
    public class Base
    {
        /// <summary>
        /// The id of the record.
        /// </summary>
        [Key]
        public int Id { get; init; }
    }
}