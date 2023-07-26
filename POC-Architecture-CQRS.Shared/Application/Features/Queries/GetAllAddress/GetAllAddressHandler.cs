using MediatR;
using POC_Architecture_CQRS.Shared.Application.DTOs;
using POC_Architecture_CQRS.Shared.Application.Mappers;
using POC_Architecture_CQRS.Shared.Application.Services.SmartSearch;

namespace POC_Architecture_CQRS.Shared.Application.Features.Queries.GetAllAddress;

public class GetAllAddressHandler : IRequestHandler<GetAllAddressQueryParam, IEnumerable<AddressDto>>
{
    public readonly ISmartSearchService _smartSearchService;

    public GetAllAddressHandler(ISmartSearchService smartSearchService)
        => _smartSearchService = smartSearchService;

    public async Task<IEnumerable<AddressDto>> Handle(GetAllAddressQueryParam request, CancellationToken cancellationToken)
    {
        var addressList = await this._smartSearchService.GetAllDocument();

        if (addressList?.Any() == true)
        {
            return addressList.Select(a => a.AddressSmartSearch.ToAddressDto());
        }

        return Enumerable.Empty<AddressDto>();
    }
}