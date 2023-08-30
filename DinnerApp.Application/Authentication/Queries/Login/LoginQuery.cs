using DinnerApp.Application.Services.Authentication;
using MediatR;

namespace DinnerApp.Application.Authentication.Queries.Login;

public record LoginQuery(string Email,
                           string Password) : IRequest<AuthResult>;

