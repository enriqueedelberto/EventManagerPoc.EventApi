using EventApi.Infrastructure.DataAccess.Entities;
using EventApi.Infrastructure.DataAccess.Interfaces;

namespace EventApi.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    public Task<bool> Add(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAll()
    {
        throw new NotImplementedException();
    }
}
