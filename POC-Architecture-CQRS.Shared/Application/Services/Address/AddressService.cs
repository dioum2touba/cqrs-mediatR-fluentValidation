using MediatR;
using POC_Architecture_CQRS.Shared.Application.DTOs;
using POC_Architecture_CQRS.Shared.Application.Features.Commands.CreateAddress;
using POC_Architecture_CQRS.Shared.Application.Features.Commands.UpdateSmartSearch;
using POC_Architecture_CQRS.Shared.Application.Features.Queries.GetAllAddress;
using POC_Architecture_CQRS.Shared.Application.Mappers;

namespace POC_Architecture_CQRS.Shared.Application.Services.Address;

public class AddressService : IAddressService
{
    private readonly IMediator _mediator;

    public AddressService(IMediator mediator)
        => _mediator = mediator;

    public async Task<AddressDto> CreateAddressAsync(CreateAddressCommandParam commandParam)
    {
        var response = await _mediator.Send(commandParam);

        if (response != null)
        {
            await this._mediator.Publish(new UpdateSmartSearchCommandParam(response.ToAddressSmartSearchDto()));
        }

        return response;
    }

    public async Task<IEnumerable<AddressDto>> GetAllAddressesAsync()
    {
        var response = await _mediator.Send(new GetAllAddressQueryParam());

        return response;
    }
}