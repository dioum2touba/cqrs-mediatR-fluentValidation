using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Internal;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace POC_Architecture_CQRS.Validators.Commons;

public class CustomValidatorInterceptor : ClientValidatorBase
{
    public CustomValidatorInterceptor(IValidationRule rule, IRuleComponent component) : base(rule, component)
    {
    }

    public override void AddValidation(ClientModelValidationContext context)
    {
        throw new NotImplementedException();
    }
}