using DinnerApp.Application.Common.Interfaces.Auth;
using DinnerApp.Infrastructure.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace DinnerApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager config)
    {

        services.AddSingleton<IJwtGenerator, JwtGenerator>();
        services.Configure<JwtSettings>(config.GetSection("JwtSettings"));

        return services;
    }    
}
