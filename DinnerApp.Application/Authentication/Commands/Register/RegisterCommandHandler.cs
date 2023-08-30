using DinnerApp.Application.Common.Interfaces.Auth;
using DinnerApp.Application.Common.Interfaces.Persistence;
using DinnerApp.Application.Services.Authentication;
using DinnerApp.Domain.Entities;
using MediatR;

namespace DinnerApp.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthResult>
{
    private readonly IJwtGenerator _jwtGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtGenerator jwtGenerator, IUserRepository userRepository)
    {
        _jwtGenerator = jwtGenerator;
        _userRepository = userRepository;
    }

    public async Task<AuthResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {

        //1. Check user already exist
        if (_userRepository.GetUserByEmail(command.Email) != null)
        {
            throw new Exception("User already exists.");
        }

        //2. Create user
        User user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password,
        };

        _userRepository.Add(user);

        //3. Create JWT 
        string token = _jwtGenerator.GenerateToken(user);

        return new AuthResult(user.Id, command.FirstName, command.LastName, command.Email, token);
    }
}
