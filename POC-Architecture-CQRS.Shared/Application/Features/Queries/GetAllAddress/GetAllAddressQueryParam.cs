using MediatR;
using POC_Architecture_CQRS.Shared.Application.DTOs;

namespace POC_Architecture_CQRS.Shared.Application.Features.Queries.GetAllAddress;

public class GetAllAddressQueryParam : IRequest<IEnumerable<AddressDto>>
{
    public GetAllAddressQueryParam()
    { }
}