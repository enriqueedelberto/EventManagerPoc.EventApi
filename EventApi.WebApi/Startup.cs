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
        services.AddSwaggerGen(options =>
        {
            // Swagger gets confused by classes with the same name in different namespaces;
            // this tells it to use the fully qualifed name.
            options.CustomSchemaIds(schemaType => schemaType.FullName);

            // Adds documentation to endpoints based on C# type attribution in the generated XML file.
            // (The generated file is named in the csproj project definition and is generated with builds.)
            options.IncludeXmlComments("Properties/Command.Core.xml", true);

            // Including details from the project readme markdown file in swagger.
            var assembly = Assembly.GetExecutingAssembly();
            using var readmeResource = assembly.GetManifestResourceStream("Command.Core.readme.md");
            using var readmeStream = new StreamReader(readmeResource);

            // Creates documentation for the version.
            // (Ideally this would loop for versions.)
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Commands Core Service",
                Version = "v1",
                Description = readmeStream.ReadToEnd()
            });

            // Add security awareness for bearer tokens
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Auth header value: Bearer <your-JWT-token>",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Scheme = "bearer",
                Type = SecuritySchemeType.ApiKey
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new List<string>()
                }
            });

            options.EnableAnnotations();
        });

        return builder;
    }
}

