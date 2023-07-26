using MediatR;
using Microsoft.EntityFrameworkCore;
using POC_Architecture_CQRS.Shared.Application.DTOs;
using POC_Architecture_CQRS.Shared.Application.Features.Commands.CreateUser;
using POC_Architecture_CQRS.Shared.Application.Mappers;
using POC_Architecture_CQRS.Shared.Domain.ContextDatabase;

namespace POC_Architecture_CQRS.Shared.Application.Features.Commands.CreateAddress;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandParam, UserDto>
{
    public readonly CqrsPocDbContext _context;

    public CreateUserCommandHandler(CqrsPocDbContext _context)
    {
        this._context = _context;
    }

    public async Task<UserDto> Handle(CreateUserCommandParam request, CancellationToken cancellationToken)
    {
        var response = await _context.Users.AddAsync(request.ToUsers(), cancellationToken);
        int nbreLine = await _context.SaveChangesAsync(cancellationToken);

        if (nbreLine > 0)
        {
            var user = this._context.Users.Include(u => u.Address).Where(u => u.Id == response.Entity.Id).FirstOrDefault();

            return user?.ToUsersDto() ?? response.Entity?.ToUsersDto();
        }

        return response.Entity?.ToUsersDto();
    }
}