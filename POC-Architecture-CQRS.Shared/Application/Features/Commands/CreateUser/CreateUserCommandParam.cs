using MediatR;
using POC_Architecture_CQRS.Shared.Application.DTOs;

namespace POC_Architecture_CQRS.Shared.Application.Features.Commands.CreateUser;

public record CreateUserCommandParam(string FirstName, string LastName, string PhoneNumber, string Gender, Guid AddressId) : IRequest<UserDto>
{ }