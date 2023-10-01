using DinnerApp.Domain.Models.User;

namespace DinnerApp.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    
    void Add(User user);    
}
