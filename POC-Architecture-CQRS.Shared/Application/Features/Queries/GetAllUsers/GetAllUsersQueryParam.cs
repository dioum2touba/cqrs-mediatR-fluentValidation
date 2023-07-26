using MediatR;
using POC_Architecture_CQRS.Shared.Application.DTOs;
using POC_Architecture_CQRS.Shared.Domain.Models;

namespace POC_Architecture_CQRS.Shared.Application.Features.Queries.GetAllUsers;

public record GetAllUsersQueryParam : IRequest<IEnumerable<UserDto>>
{
}