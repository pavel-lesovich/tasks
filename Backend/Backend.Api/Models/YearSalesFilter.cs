using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Models
{
    public record YearSalesFilter(
        [property: FromQuery(Name = "maxTotal")] decimal? MaxTotal, 
        [property: FromQuery(Name = "minTimeToShipInDays")] int? MinTimeToShipInDays);
}
