using DinnerApp.Domain.Entities;

namespace DinnerApp.Application.Common.Interfaces.Auth;

public interface IJwtGenerator
{
    string GenerateToken(User user);
}

