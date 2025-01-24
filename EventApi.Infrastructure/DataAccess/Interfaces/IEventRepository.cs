using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApi.Infrastructure.DataAccess.Interfaces;

public interface IEventRepository
{
    Task<bool> Add(Entities.Event entity);
    Task<IEnumerable<Entities.Event>> GetAll();
}
