using DinnerApp.Application.Services.Authentication;
using MediatR;

namespace DinnerApp.Application.Authentication.Commands.Register;

public record RegisterCommand(string FirstName,
                              string LastName,
                              string Email,
                              string Password) : IRequest<AuthResult>;
