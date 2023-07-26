using Microsoft.AspNetCore.Mvc;
using POC_Architecture_CQRS.Shared.Application.DTOs;
using POC_Architecture_CQRS.Shared.Application.Features.Commands.CreateAddress;
using POC_Architecture_CQRS.Shared.Application.Services.Address;

namespace POC_Architecture_CQRS.Features;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class AddressController : ControllerBase
{
    private readonly IAddressService _addressService;

    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpPost("create-address")]
    [ProducesResponseType(typeof(AddressDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status502BadGateway)]
    public async Task<AddressDto> CreateAddressAsync([FromBody] CreateAddressCommandParam commandParam)
    {
        var response = await _addressService.CreateAddressAsync(commandParam);

        return response;
    }

    [HttpGet("all-address")]
    [ProducesResponseType(typeof(IEnumerable<AddressDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status502BadGateway)]
    public async Task<IEnumerable<AddressDto>> GetAllAddressesAsync()
    {
        var response = await this._addressService.GetAllAddressesAsync();

        return response;
    }
}