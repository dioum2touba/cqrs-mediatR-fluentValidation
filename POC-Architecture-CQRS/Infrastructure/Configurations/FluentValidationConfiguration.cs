using FluentValidation;
using FluentValidation.AspNetCore;
using POC_Architecture_CQRS.Validators.Commons;

namespace POC_Architecture_CQRS.Infrastructure.Configurations;

public static class FluentValidationConfiguration
{
    public static IServiceCollection AddAddFluentValidationConfiguration(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssemblyContaining<CustomValidatorInterceptor>();

        return services;
    }
}