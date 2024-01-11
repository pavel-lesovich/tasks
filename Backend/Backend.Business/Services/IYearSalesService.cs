namespace Backend.Business.Services
{
    public interface IYearSalesService
    {
        Task<IEnumerable<YearSalesDetailsModel>> GetYearSalesDetailsList(int? orderYear, int? timeToShipInDays);
        Task<IEnumerable<YearSalesModel>> GetYearSalesList(decimal? maxTotal, int? minTimeToShipInDays);
    }
}