using DinnerApp.Application.Common.Interfaces.Auth;
using DinnerApp.Application.Common.Interfaces.Persistence;
using DinnerApp.Infrastructure.Auth;
using DinnerApp.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace DinnerApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager config)
    {

        services.AddSingleton<IJwtGenerator, JwtGenerator>();
        services.Configure<JwtSettings>(config.GetSection("JwtSettings"));
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
