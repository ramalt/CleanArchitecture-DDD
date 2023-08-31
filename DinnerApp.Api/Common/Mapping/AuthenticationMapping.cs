using DinnerApp.Application.Authentication.Commands.Register;
using DinnerApp.Application.Authentication.Queries.Login;
using DinnerApp.Application.Services.Authentication;
using DinnerApp.Contracts.Authentication;
using Mapster;

namespace DinnerApp.Api.Common.Mapping;

public class AuthenticationMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthResult, AuthResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.user);

        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
    }
}