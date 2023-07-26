using Microsoft.EntityFrameworkCore;
using POC_Architecture_CQRS.Infrastructure.StaticValues;
using POC_Architecture_CQRS.Shared.Domain.ContextDatabase;

namespace POC_Architecture_CQRS.Infrastructure.Configurations;

public static class DatabaseConfiguration
{
    public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CqrsPocDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString(ConstantConfig.DefaultConnection), b => b.MigrationsAssembly(ConstantConfig.SchemaName));
        });

        return services;
    }
}