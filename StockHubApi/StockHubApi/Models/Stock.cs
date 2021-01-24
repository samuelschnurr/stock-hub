using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockHubApi.Models
{
    public class Stock : Base
    {
        [MinLength(3)]
        [MaxLength(50)]
        [Required]
        [Column(TypeName="nvarchar(50)")]
        public string Name { get; set; }

        [Range(0.0001, 9999999999999.9999)]
        [Required]
        [Column(TypeName = "decimal(17,4)")]
        public double Amount { get; set; }

        [Range(0.0001, 99999999.9999)]
        [Required]
        [Column(TypeName = "decimal(12,4)")]
        public double AcquisitionPricePerUnit { get; set; }
    }
}
