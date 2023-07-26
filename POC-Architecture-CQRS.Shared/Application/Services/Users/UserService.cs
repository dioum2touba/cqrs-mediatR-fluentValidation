using MediatR;
using POC_Architecture_CQRS.Shared.Application.DTOs;
using POC_Architecture_CQRS.Shared.Application.Features.Commands.CreateUser;
using POC_Architecture_CQRS.Shared.Application.Features.Commands.UpdatePhoneNumber;
using POC_Architecture_CQRS.Shared.Application.Features.Commands.UpdateSmartSearch;
using POC_Architecture_CQRS.Shared.Application.Features.Queries.GetAllUsers;
using POC_Architecture_CQRS.Shared.Application.Features.Queries.GetUsersById;
using POC_Architecture_CQRS.Shared.Application.Mappers;

namespace POC_Architecture_CQRS.Shared.Application.Services;

public class UserService : IUserService
{
    private readonly IMediator _mediator;

    public UserService(IMediator mediator)
        => _mediator = mediator;

    public async Task<UserDto> CreateUserAsync(CreateUserCommandParam commandParam)
    {
        var response = await _mediator.Send(commandParam);

        if (response != null)
        {
            await this._mediator.Publish(new UpdateSmartSearchCommandParam(response.ToSmartSearchDto()));

            return response;
        }

        return response;
    }

    public async Task<IEnumerable<UserDto>> GetAllUserAsync()
    {
        var response = await _mediator.Send(new GetAllUsersQueryParam());

        return response;
    }

    public async Task<UserDto> GetUserByIdAsync(GetUsersByIdQueryParam queryParam)
    {
        var response = await _mediator.Send(queryParam);

        return response;
    }

    public async Task<UserDto> UpdateUserPhoneNumberAsync(UpdatePhoneNumberCommandParam commandParam)
    {
        var response = await _mediator.Send(commandParam);

        if (response != null)
        {
            var result = await GetUserByIdAsync(new(response.Id));

            await this._mediator.Publish(new UpdateSmartSearchCommandParam(result.ToSmartSearchDto()));

            return result;
        }

        return response;
    }
}