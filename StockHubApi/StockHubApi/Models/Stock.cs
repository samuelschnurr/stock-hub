using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockHubApi.Models
{
    /// <summary>
    /// The database abstraction of a <see cref="Stock"/>.
    /// </summary>
    public class Stock : Base
    {
        /// <summary>
        /// The name of the <see cref="Stock"/> which can be company name, isin or wkn.
        /// </summary>
        [MinLength(3)]
        [MaxLength(50)]
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        /// <summary>
        /// The amount of the <see cref="Stock"/> which has been purchased.
        /// </summary>
        [Range(0.0001, 9999999999999.9999)]
        [Required]
        [Column(TypeName = "decimal(17,4)")]
        public double Amount { get; set; }

        /// <summary>
        /// The price per unit of the <see cref="Stock"/> which has been invoiced.
        /// </summary>
        [Range(0.0001, 99999999.9999)]
        [Required]
        [Column(TypeName = "decimal(12,4)")]
        public double AcquisitionPricePerUnit { get; set; }
    }
}