using Backend.Api.Models;
using Backend.Business.Services;

namespace Backend.Api.Mappers
{
    public class YearSalesMapper : IYearSalesMapper
    {
        public YearSales ToYearSales(YearSalesModel model) => new YearSales
        {
            OrderYear = model.OrderYear,
            TimeToShipInDays = model.TimeToShipInDays,
            Total = model.Total
        };
        public YearSalesDetails ToYearSalesDetails(YearSalesDetailsModel model) => new YearSalesDetails
        {
            ContactName = model.ContactName,
            OrderDate = DateOnly.FromDateTime(model.OrderDate),
            SalesOrderId = model.SalesOrderId,
            ShipDate = DateOnly.FromDateTime(model.ShipDate),
            Total = model.Total
        };
    }
}
