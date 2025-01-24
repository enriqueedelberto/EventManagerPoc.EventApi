using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApi.Infrastructure.DataAccess.Interfaces;

public interface IUserRepository
{
    Task<bool> Add(Entities.User entity);
    Task<IEnumerable<Entities.User>> GetAll();
}

