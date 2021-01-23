using System.ComponentModel.DataAnnotations.Schema;

namespace StockHubApi.Models
{
    public class Stock : Base
    {
        [Column(TypeName="nvarchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "decimal(17,4)")]
        public double Amount { get; set; }

        [Column(TypeName = "decimal(12,4)")]
        public double AcquisitionPricePerUnit { get; set; }
    }
}
