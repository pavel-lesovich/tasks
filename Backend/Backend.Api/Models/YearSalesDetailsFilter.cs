using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Models
{
    public class YearSalesDetailsFilter
    {
        [FromQuery(Name = "orderYear")] 
        public int? OrderYear { get; set; }
        [FromQuery(Name = "timeToShipInDays")] 
        public int? TimeToShipInDays { get; set; }
    }
}
