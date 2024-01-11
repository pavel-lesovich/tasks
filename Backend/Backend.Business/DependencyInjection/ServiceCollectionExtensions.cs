using Backend.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Business.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<IYearSalesService, YearSalesService>();
            return services;
        }
    }
}
