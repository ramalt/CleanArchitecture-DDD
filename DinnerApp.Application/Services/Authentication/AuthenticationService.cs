using DinnerApp.Application.Common.Interfaces.Auth;

namespace DinnerApp.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtGenerator _jwtGenerator;

    public AuthenticationService(IJwtGenerator jwtGenerator)
    {
        _jwtGenerator = jwtGenerator;
    }

    public AuthResult Login(string email, string password)
    {
        
        return new AuthResult(Guid.NewGuid(), "firsName", "lastName", email, "token");
    }

    public AuthResult Register(string firsName, string lastName, string email, string password)
    {
        //1. Check user already exist

        //2. Create user

        //3. Create JWT token
        Guid userId = Guid.NewGuid();

        string token = _jwtGenerator.GenerateToken(userId, firsName, lastName);

        return new AuthResult(userId, firsName, lastName, email, token);
    }
}
