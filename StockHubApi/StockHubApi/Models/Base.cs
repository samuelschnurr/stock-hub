using System.ComponentModel.DataAnnotations;

namespace StockHubApi.Models
{
    public class Base
    {
        [Key]
        public int Id { get; init; }
    }
}
