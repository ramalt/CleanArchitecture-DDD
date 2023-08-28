namespace DinnerApp.Application.Services.Authentication;

public interface IAuthenticationService
{
       AuthResult Register(string firsName, string lastName, string email, string password);
       AuthResult Login(string email, string password);
}
