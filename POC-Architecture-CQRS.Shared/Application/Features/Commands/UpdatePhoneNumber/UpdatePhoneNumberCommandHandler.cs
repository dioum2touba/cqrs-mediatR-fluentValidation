using MediatR;
using Microsoft.EntityFrameworkCore;
using POC_Architecture_CQRS.Shared.Application.DTOs;
using POC_Architecture_CQRS.Shared.Application.Mappers;
using POC_Architecture_CQRS.Shared.Domain.ContextDatabase;

namespace POC_Architecture_CQRS.Shared.Application.Features.Commands.UpdatePhoneNumber;

public class UpdatePhoneNumberCommandHandler : IRequestHandler<UpdatePhoneNumberCommandParam, UserDto>
{
    public readonly CqrsPocDbContext _context;

    public UpdatePhoneNumberCommandHandler(CqrsPocDbContext _context)
    {
        this._context = _context;
    }

    public async Task<UserDto> Handle(UpdatePhoneNumberCommandParam request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.UserID, cancellationToken: cancellationToken) ?? throw new Exception();
        user.PhoneNumber = request.PhoneNumber;

        await _context.SaveChangesAsync(cancellationToken);

        return user.ToUsersDto();
    }
}