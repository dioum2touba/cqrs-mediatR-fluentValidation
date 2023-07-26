using MediatR;
using POC_Architecture_CQRS.Shared.Application.DTOs;

namespace POC_Architecture_CQRS.Shared.Application.Features.Commands.CreateAddress;

public record CreateAddressCommandParam(string State, int PostalCode) : IRequest<AddressDto>
{ }