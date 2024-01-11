using Backend.Business.Repositories;

namespace Backend.Business.Services
{
    public class YearSalesService : IYearSalesService
    {
        private readonly IYearSalesRepository yearSalesRepository;

        public YearSalesService(IYearSalesRepository yearSalesRepository)
        {
            this.yearSalesRepository = yearSalesRepository;
        }

        public Task<IEnumerable<YearSalesModel>> GetYearSalesList(decimal? maxTotal, int? minTimeToShipInDays)
        {
            return yearSalesRepository.GetYearSalesList(maxTotal, minTimeToShipInDays);
        }
        public Task<IEnumerable<YearSalesDetailsModel>> GetYearSalesDetailsList(int? orderYear, int? timeToShipInDays)
        {
            return yearSalesRepository.GetYearSalesDetailsList(orderYear, timeToShipInDays);
        }
    }
}
