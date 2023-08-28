namespace DinnerApp.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    public AuthResult Login(string email, string password)
    {
        return new AuthResult(Guid.NewGuid(), "firsName", "lastName", email, password);
    }

    public AuthResult Register(string firsName, string lastName, string email, string password)
    {
        return new AuthResult(Guid.NewGuid(), firsName, lastName, email, password);
    }
}
