using FluentValidation;
using POC_Architecture_CQRS.Shared.Application.Features.Queries.GetUsersById;

namespace POC_Architecture_CQRS.Validators;

public class GetUsersByIdQueryValidator : AbstractValidator<GetUsersByIdQueryParam>
{
    public GetUsersByIdQueryValidator()
    {
        RuleFor(x => x.UserID).NotEmpty();
    }
}