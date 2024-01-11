namespace Backend.Api.Models
{
    public class YearSalesDetails
    {
        public DateOnly OrderDate { get; set; }
        public DateOnly ShipDate { get; set; }
        public int SalesOrderId { get; set; }
        public string? ContactName { get; set; }
        public decimal Total { get; set; }
    }
}
