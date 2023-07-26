using FluentValidation;
using POC_Architecture_CQRS.Shared.Application.Features.Commands.CreateUser;

namespace POC_Architecture_CQRS.Validators;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommandParam>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.AddressId).NotEmpty();
        RuleFor(x => x.PhoneNumber).NotEmpty();
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.Gender).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
    }
}