using System.Text;
using DinnerApp.Application.Common.Interfaces.Auth;
using DinnerApp.Application.Common.Interfaces.Persistence;
using DinnerApp.Infrastructure.Auth;
using DinnerApp.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace DinnerApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager config)
    {
        services.AddAuth(config);
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
    public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager config)
    {
        var jwtSettings = new JwtSettings();
        config.Bind("JwtSettings", jwtSettings);

        services.AddSingleton<IJwtGenerator, JwtGenerator>();
        // services.Configure<JwtSettings>(config.GetSection("JwtSettings"));
        services.AddSingleton(Options.Create(jwtSettings));
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt => opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
            });

        return services;
    }


}
