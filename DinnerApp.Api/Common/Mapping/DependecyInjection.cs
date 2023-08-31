using System.Reflection;
using Mapster;
using MapsterMapper;

namespace DinnerApp.Api.Common.Mapping;

public static class DependecyInjection
{
    public static IServiceCollection UseMapping(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        return services;
    }
}