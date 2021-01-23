using System.ComponentModel.DataAnnotations.Schema;

namespace StockHubApi.Models
{
    public class Stock : Base
    {
        [Column(TypeName="NVARCHAR(50)")]
        public string Name { get; set; }

        [Column(TypeName = "DECIMAL(17,4)")]
        public double Amount { get; set; }

        [Column(TypeName = "DECIMAL(12,4)")]
        public double AcquisitionPricePerUnit;
    }
}
