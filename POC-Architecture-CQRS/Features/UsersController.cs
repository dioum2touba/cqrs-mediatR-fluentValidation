using Microsoft.AspNetCore.Mvc;
using POC_Architecture_CQRS.Shared.Application.DTOs;
using POC_Architecture_CQRS.Shared.Application.Features.Commands.CreateUser;
using POC_Architecture_CQRS.Shared.Application.Features.Commands.UpdatePhoneNumber;
using POC_Architecture_CQRS.Shared.Application.Features.Queries.GetUsersById;
using POC_Architecture_CQRS.Shared.Application.Services;

namespace POC_Architecture_CQRS.Features;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("create-user")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status502BadGateway)]
    public async Task<UserDto> CreateUserAsync([FromBody] CreateUserCommandParam commandParam)
    {
        var response = await _userService.CreateUserAsync(commandParam);

        return response;
    }

    [HttpGet("all-users")]
    [ProducesResponseType(typeof(IEnumerable<UserDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status502BadGateway)]
    public async Task<IEnumerable<UserDto>> GetAllUserAsync()
    {
        var response = await this._userService.GetAllUserAsync();

        return response;
    }

    [HttpGet("user-by-id")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status502BadGateway)]
    public async Task<UserDto> GetUserByIdAsync([FromQuery] GetUsersByIdQueryParam queryParam)
    {
        var response = await _userService.GetUserByIdAsync(queryParam);

        return response;
    }

    [HttpPut("update-phonenumber-user")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status502BadGateway)]
    public async Task<UserDto> UpdateUserPhoneNumberAsync([FromBody] UpdatePhoneNumberCommandParam commandParam)
    {
        var response = await _userService.UpdateUserPhoneNumberAsync(commandParam);

        return response;
    }
}