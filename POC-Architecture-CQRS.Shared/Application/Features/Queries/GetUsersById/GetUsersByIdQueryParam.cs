using MediatR;
using POC_Architecture_CQRS.Shared.Application.DTOs;

namespace POC_Architecture_CQRS.Shared.Application.Features.Queries.GetUsersById;

public record GetUsersByIdQueryParam(Guid UserID) : IRequest<UserDto>
{ }