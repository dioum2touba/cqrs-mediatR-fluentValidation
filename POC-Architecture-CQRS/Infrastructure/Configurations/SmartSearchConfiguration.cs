using Microsoft.Extensions.Azure;
using Azure.Search.Documents;

namespace POC_Architecture_CQRS.Infrastructure.Configurations;

public static class SmartSearchConfiguration
{
    public static IServiceCollection AddSmartSearchConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        // add smart search configuration
        services.AddAzureClients(builder =>
        {
            builder.AddSearchClient(configuration.GetSection("SearchClient"));
            builder.AddSearchIndexClient(configuration.GetSection("SearchClient"));
        });

        return services;
    }
}