using POC_Architecture_CQRS.Shared.Application.DTOs;
using POC_Architecture_CQRS.Shared.Application.Features.Commands.CreateAddress;

namespace POC_Architecture_CQRS.Shared.Application.Services.Address;

public interface IAddressService
{
    Task<IEnumerable<AddressDto>> GetAllAddressesAsync();

    Task<AddressDto> CreateAddressAsync(CreateAddressCommandParam commandParam);
}