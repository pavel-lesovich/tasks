namespace Backend.Api.Models
{
    public class YearSales
    {
        public int OrderYear { get; set; }
        public int TimeToShipInDays { get; set; }
        public decimal Total { get; set; }
    }
}
