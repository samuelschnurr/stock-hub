namespace StockHubApi.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public double AcquisitionPricePerUnit;
    }
}
