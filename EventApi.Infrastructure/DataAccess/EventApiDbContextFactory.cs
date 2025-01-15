using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EventApi.Infrastructure.DataAccess;

public class EventApiDbContextFactory : IDesignTimeDbContextFactory<EventApiDbContext>
{
    public EventApiDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EventApiDbContext>();
        optionsBuilder.UseSqlServer();

        return new EventApiDbContext(optionsBuilder.Options);
    }
}
