using Backend.Api.Mappers;

namespace Backend.Api.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddTransient<IYearSalesMapper, YearSalesMapper>();
            return services;
        }
    }
}
