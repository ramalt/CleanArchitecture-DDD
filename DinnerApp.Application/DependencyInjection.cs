using System.Reflection;
using DinnerApp.Application.Authentication.Commands.Register;
using DinnerApp.Application.Common.Behaviors;
using DinnerApp.Application.Services.Authentication;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DinnerApp.Application;

public static class DependencyInjection
{
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services.AddMediatR(typeof(DependencyInjection).Assembly);

    //validation 
    services.AddScoped<IPipelineBehavior<RegisterCommand, AuthResult>, ValidationBehavior>();
    // services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidation>();
    services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    return services;
  }
}
