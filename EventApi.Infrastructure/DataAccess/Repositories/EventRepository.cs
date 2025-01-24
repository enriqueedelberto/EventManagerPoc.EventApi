using EventApi.Infrastructure.DataAccess.Entities;
using EventApi.Infrastructure.DataAccess.Interfaces;

namespace EventApi.Infrastructure.DataAccess.Repositories;

public class EventRepository : IEventRepository
{
    public Task<bool> Add(Event entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Event>> GetAll()
    {
        throw new NotImplementedException();
    }
}
