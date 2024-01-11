namespace Backend.Business.Services
{
    public class YearSalesDetailsModel
    {
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public int SalesOrderId { get; set; }
        public string? ContactName { get; set; }
        public decimal Total { get; set; }
    }
}
