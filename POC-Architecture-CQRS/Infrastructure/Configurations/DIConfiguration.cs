using POC_Architecture_CQRS.Shared.Application.Services;
using POC_Architecture_CQRS.Shared.Application.Services.Address;
using POC_Architecture_CQRS.Shared.Application.Services.SmartSearch;

namespace POC_Architecture_CQRS.Infrastructure.Configurations;

public static class DIConfiguration
{
    public static IServiceCollection AddDIConfiguration(this IServiceCollection services)
    {
        services
                .AddTransient<IAddressService, AddressService>()
                .AddTransient<ISmartSearchService, SmartSearchService>()
                .AddTransient<IUserService, UserService>();

        return services;
    }
}