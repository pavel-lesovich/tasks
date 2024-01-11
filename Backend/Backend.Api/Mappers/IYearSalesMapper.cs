using Backend.Api.Models;
using Backend.Business.Services;

namespace Backend.Api.Mappers
{
    public interface IYearSalesMapper
    {
        YearSalesDetails ToYearSalesDetails(YearSalesDetailsModel model);
        YearSales ToYearSales(YearSalesModel model);
    }
}