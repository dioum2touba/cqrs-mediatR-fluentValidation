using MediatR;
using POC_Architecture_CQRS.Shared.Application.DTOs;
using POC_Architecture_CQRS.Shared.Application.Mappers;
using POC_Architecture_CQRS.Shared.Domain.ContextDatabase;

namespace POC_Architecture_CQRS.Shared.Application.Features.Commands.CreateAddress;

public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommandParam, AddressDto>
{
    public readonly CqrsPocDbContext _context;

    public CreateAddressCommandHandler(CqrsPocDbContext _context)
        => this._context = _context;

    public async Task<AddressDto> Handle(CreateAddressCommandParam request, CancellationToken cancellationToken)
    {
        var response = await _context.Address.AddAsync(request.ToAddress(), cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return response.Entity.ToAddressDto();
    }
}