using FluentValidation;
using POC_Architecture_CQRS.Shared.Application.Features.Commands.CreateAddress;

namespace POC_Architecture_CQRS.Validators;

public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommandParam>
{
    public CreateAddressCommandValidator()
    {
        RuleFor(x => x.PostalCode).NotEmpty();
        RuleFor(x => x.State).NotEmpty();
    }
}