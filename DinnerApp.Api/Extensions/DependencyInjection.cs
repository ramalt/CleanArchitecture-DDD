using DinnerApp.Api.Common.Mapping;

namespace DinnerApp.Api.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.UseMapping();
            return services;
        }
    }
}