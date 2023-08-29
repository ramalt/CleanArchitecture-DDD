using DinnerApp.Application.Common.Interfaces.Persistence;
using DinnerApp.Domain.Entities;

namespace DinnerApp.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    //in memory 
    private static readonly List<User> _users = new();
    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        //!_users.SingleOrDefault() da olabilir
        User? user = _users.Where(x => x.Email == email).FirstOrDefault();

        return user;
    }
}
