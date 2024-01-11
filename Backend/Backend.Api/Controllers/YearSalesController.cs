using Backend.Api.Mappers;
using Backend.Api.Models;
using Backend.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class YearSalesController : ControllerBase
    {
        private readonly IYearSalesService yearSalesService;
        private readonly IYearSalesMapper yearSalesMapper;

        public YearSalesController(IYearSalesService yearSalesService, IYearSalesMapper yearSalesMapper)
        {
            this.yearSalesService = yearSalesService;
            this.yearSalesMapper = yearSalesMapper;
        }

        [HttpGet("YearSales", Name = "GetYearSalesList")]
        public async Task<IEnumerable<YearSales>> GetYearSalesList([FromQuery] YearSalesFilter query)
        {
            var (maxTotal, minTimeToShipInDays) = query;
            var models = await yearSalesService.GetYearSalesList(maxTotal, minTimeToShipInDays);
            return models.Select(yearSalesMapper.ToYearSales);
        }


        [HttpGet("YearSalesDetails", Name = "GetYearSalesDetailsList")]
        public async Task<IEnumerable<YearSalesDetails>> GetYearSalesDetailsList([FromQuery] YearSalesDetailsFilter query)
        {
            var models = await yearSalesService.GetYearSalesDetailsList(query.OrderYear, query.TimeToShipInDays);
            return models.Select(yearSalesMapper.ToYearSalesDetails);
        }
    }
}
