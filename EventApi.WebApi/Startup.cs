using EventApi.Infrastructure.DataAccess;
using EventApi.Infrastructure.DataAccess.Interfaces;
using EventApi.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace EventApi.WebApi;

public static class Startup
{
    public static WebApplicationBuilder AddConfig(this WebApplicationBuilder builder)
    {
        var config = builder.Configuration;

        //TODO: Add KeyVault config when it has.

        if (builder.Environment.IsDevelopment())
        {
            config.AddJsonFile("appsettings.Development.json");

            config.AddJsonFile("appsettings.Private.json", true);
        }

        return builder;
    }

    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        var services = builder.Services;
        var config = builder.Configuration;

        //TODO: Add logger if so

        //TODO: Add KeyVault settings

        //TODO: Add applicationInsights

        //DB contex adding
        services.AddDbContext<EventApiDbContext>(o => 
         o.UseSqlServer(config.GetValue<string>("ConnectionStrings:DatabaseConnection"),
         b => b.MigrationsAssembly(typeof(EventApiDbContext).Assembly.FullName)));

        //Include repositories.
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        //TODO: Add Swagger
        services.AddSwaggerGen();

        return builder;
    }
}

