using DinnerApp.Application.Common.Interfaces.Auth;
using DinnerApp.Application.Common.Interfaces.Persistence;
using DinnerApp.Application.Services.Authentication;
using DinnerApp.Domain.Entities;
using MediatR;

namespace DinnerApp.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthResult>
{
    private readonly IJwtGenerator _jwtGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtGenerator jwtGenerator, IUserRepository userRepository)
    {
        _jwtGenerator = jwtGenerator;
        _userRepository = userRepository;
    }

    async Task<AuthResult> IRequestHandler<LoginQuery, AuthResult>.Handle(LoginQuery query, CancellationToken cancellationToken)
    {
         //1. check user exist
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
        {
            throw new Exception("Email does not exist.");
        }

        // 2. Validate user pass
        if (user.Password != query.Password)
        {
            throw new Exception("Invalid Password");
        }

        //3. create JWT
        string token = _jwtGenerator.GenerateToken(user);

        return new AuthResult(user.Id, user.FirstName, user.LastName, user.Email, token);
    }
}
