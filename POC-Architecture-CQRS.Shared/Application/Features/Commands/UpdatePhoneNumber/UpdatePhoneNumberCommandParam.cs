using MediatR;
using POC_Architecture_CQRS.Shared.Application.DTOs;
using POC_Architecture_CQRS.Shared.Domain.Models;

namespace POC_Architecture_CQRS.Shared.Application.Features.Commands.UpdatePhoneNumber;

public record UpdatePhoneNumberCommandParam(Guid UserID, string PhoneNumber) : IRequest<UserDto>
{
}