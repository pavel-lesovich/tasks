using Backend.Business.Repositories;
using Backend.Business.Services;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Backend.DataAccess.Repositories
{
    public class YearSalesRepository : IYearSalesRepository
    {
        private readonly IConfiguration configuration;

        public YearSalesRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        private SqlConnection OpenConnection()
        {
            var connectionString = configuration.GetConnectionString("Default");
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public async Task<IEnumerable<YearSalesDetailsModel>> GetYearSalesDetailsList(int? orderYear, int? timeToShipInDays)
        {
            using var connection = OpenConnection();

            const string query = @"
WITH YearSales as (
SELECT
	[SalesOrderID]
	, [OrderYear] = YEAR(OrderDate)
    , [TimeToShipInDays] = DATEDIFF(day, OrderDate, ShipDate)
  FROM [Sales].[SalesOrderHeader]
)
, YearSalesTotal as (
SELECT
	[SalesOrderID]
    ,[Total] = SUM([LineTotal])
  FROM [Sales].[SalesOrderDetail]
  GROUP BY [SalesOrderID]
)
SELECT TOP (1000)
      [OrderDate]
	  , [ShipDate]
	  , soh.[SalesOrderID]
	  , [ContactName] =CONCAT(c.FirstName, ' ', c.LastName)
	  , [Total]
FROM [Sales].[SalesOrderHeader] soh
	JOIN [Person].[Contact] c ON soh.[ContactID] = c.[ContactID]
	JOIN YearSales ys ON soh.[SalesOrderID] = ys.[SalesOrderID]
	JOIN YearSalesTotal yst ON soh.[SalesOrderID] = yst.[SalesOrderID]
 WHERE [TimeToShipInDays] = @timeToShipInDays AND [OrderYear]=@orderYear
 ORDER BY [OrderDate] DESC";
            var models = await connection.QueryAsync<YearSalesDetailsModel>(query, new { orderYear, timeToShipInDays });
            return models.ToList();
        }

        public async Task<IEnumerable<YearSalesModel>> GetYearSalesList(decimal? maxTotal, int? minTimeToShipInDays)
        {
            using var connection = OpenConnection();

            const string query = @"
WITH YearSales as (
SELECT
	[SalesOrderID]
	, [OrderYear] = YEAR(OrderDate)
    , [TimeToShipInDays] = DATEDIFF(day, OrderDate, ShipDate)
  FROM [Sales].[SalesOrderHeader]
)
, YearSalesTotal as (
SELECT
	[SalesOrderID]
    ,[Total] = SUM([LineTotal])
  FROM [Sales].[SalesOrderDetail]
  GROUP BY [SalesOrderID]
)
, YearSalesGroup as (
  SELECT
	 [OrderYear]
	  , [TimeToShipInDays]
	  , [Total] = SUM([Total])
  FROM YearSales ys
  JOIN YearSalesTotal yst ON yst.[SalesOrderID] = ys.[SalesOrderID]
  GROUP BY [OrderYear], [TimeToShipInDays]
)
SELECT
      [OrderYear]
	  , [TimeToShipInDays]
	  , [Total]
FROM YearSalesGroup
WHERE (@minTimeToShipInDays IS NULL OR [TimeToShipInDays] >= @minTimeToShipInDays) AND
    (@maxTotal IS NULL OR [Total] <= @maxTotal)
ORDER BY [OrderYear] DESC, [TimeToShipInDays]";

            var models = await connection.QueryAsync<YearSalesModel>(query, new { maxTotal, minTimeToShipInDays });

            return models.ToList();
        }
    }
}
