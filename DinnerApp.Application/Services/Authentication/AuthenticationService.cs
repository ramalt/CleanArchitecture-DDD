using DinnerApp.Application.Common.Interfaces.Auth;
using DinnerApp.Application.Common.Interfaces.Persistence;
using DinnerApp.Domain.Entities;

namespace DinnerApp.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtGenerator _jwtGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtGenerator jwtGenerator, IUserRepository userRepository)
    {
        _jwtGenerator = jwtGenerator;
        _userRepository = userRepository;
    }

    public AuthResult Login(string email, string password)
    {
        //1. check user exist
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("Email does not exist.");
        }

        // 2. Validate user pass
        if (user.Password != password)
        {
            throw new Exception("Invalid Password");
        }

        //3. create JWT
        string token = _jwtGenerator.GenerateToken(user);

        return new AuthResult(user.Id, user.FirstName, user.LastName, user.Email, token);
    }

    public AuthResult Register(string firsName, string lastName, string email, string password)
    {
        //1. Check user already exist
        if (_userRepository.GetUserByEmail(email) != null)
        {
            throw new Exception("User already exists.");
        }

        //2. Create user
        User user = new User
        {
            FirstName = firsName,
            LastName = lastName,
            Email = email,
            Password = password,
        };

        _userRepository.Add(user);

        //3. Create JWT 
        string token = _jwtGenerator.GenerateToken(user);

        return new AuthResult(user.Id, firsName, lastName, email, token);
    }
}
