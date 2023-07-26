using POC_Architecture_CQRS.Shared.Application.DTOs;
using POC_Architecture_CQRS.Shared.Application.Features.Commands.CreateUser;
using POC_Architecture_CQRS.Shared.Application.Features.Commands.UpdatePhoneNumber;
using POC_Architecture_CQRS.Shared.Application.Features.Queries.GetUsersById;

namespace POC_Architecture_CQRS.Shared.Application.Services;

public interface IUserService
{
    Task<UserDto> GetUserByIdAsync(GetUsersByIdQueryParam queryParam);

    Task<IEnumerable<UserDto>> GetAllUserAsync();

    Task<UserDto> CreateUserAsync(CreateUserCommandParam commandParam);

    Task<UserDto> UpdateUserPhoneNumberAsync(UpdatePhoneNumberCommandParam commandParam);
}