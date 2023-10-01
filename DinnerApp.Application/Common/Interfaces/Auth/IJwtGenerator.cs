using DinnerApp.Domain.Models.User;

namespace DinnerApp.Application.Common.Interfaces.Auth;

public interface IJwtGenerator
{
    string GenerateToken(User user);
}

