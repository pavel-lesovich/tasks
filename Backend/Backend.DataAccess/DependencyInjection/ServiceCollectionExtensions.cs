using Backend.Business.Repositories;
using Backend.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.DataAccess.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {
            services.AddTransient<IYearSalesRepository, YearSalesRepository>();
            return services;
        }
    }
}
