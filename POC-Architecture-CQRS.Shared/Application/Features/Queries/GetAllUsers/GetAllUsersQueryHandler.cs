using MediatR;
using POC_Architecture_CQRS.Shared.Application.DTOs;
using POC_Architecture_CQRS.Shared.Application.Mappers;
using POC_Architecture_CQRS.Shared.Application.Services.SmartSearch;

namespace POC_Architecture_CQRS.Shared.Application.Features.Queries.GetAllUsers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQueryParam, IEnumerable<UserDto>>
{
    public readonly ISmartSearchService _smartSearchService;

    public GetAllUsersQueryHandler(ISmartSearchService smartSearchService)
        => _smartSearchService = smartSearchService;

    public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQueryParam request, CancellationToken cancellationToken)
    {
        var usersList = await this._smartSearchService.GetAllDocument();

        if (usersList?.Any() == true)
        {
            return usersList.Where(u => !string.IsNullOrEmpty(u.UserId)).Select(u => u.ToUsersDto());
        }

        return Enumerable.Empty<UserDto>();
    }
}