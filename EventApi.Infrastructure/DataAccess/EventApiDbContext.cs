using EventApi.Infrastructure.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventApi.Infrastructure.DataAccess;

public class EventApiDbContext : DbContext
{
    public DbSet<Event> Events { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Invitation> Invitations { get; set; }

    public EventApiDbContext(DbContextOptions<EventApiDbContext> options) : base(options) { } 
}
