using EventApi.Infrastructure.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventApi.Infrastructure.DataAccess;

public class EventDbContext : DbContext
{
    public DbSet<Event> Events { get; set; }

    public EventDbContext(DbContextOptions<EventDbContext> options) : base(options) { } 
}
