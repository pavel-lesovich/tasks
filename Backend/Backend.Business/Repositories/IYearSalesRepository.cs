using Backend.Business.Services;

namespace Backend.Business.Repositories
{
    public interface IYearSalesRepository
    {
        Task<IEnumerable<YearSalesModel>> GetYearSalesList(decimal? maxTotal, int? minTimeToShipInDays);
        Task<IEnumerable<YearSalesDetailsModel>> GetYearSalesDetailsList(int? orderYear, int? timeToShipInDays);
    }
}
