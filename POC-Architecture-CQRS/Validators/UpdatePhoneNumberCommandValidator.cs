using FluentValidation;
using POC_Architecture_CQRS.Shared.Application.Features.Commands.UpdatePhoneNumber;

namespace POC_Architecture_CQRS.Validators;

public class UpdatePhoneNumberCommandValidator : AbstractValidator<UpdatePhoneNumberCommandParam>
{
    public UpdatePhoneNumberCommandValidator()
    {
        RuleFor(x => x.PhoneNumber).NotEmpty();
        RuleFor(x => x.UserID).NotEmpty();
    }
}