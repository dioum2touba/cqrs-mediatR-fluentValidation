using MediatR;
using POC_Architecture_CQRS.Shared.Application.DTOs;
using POC_Architecture_CQRS.Shared.Application.Mappers;
using POC_Architecture_CQRS.Shared.Application.Services.SmartSearch;

namespace POC_Architecture_CQRS.Shared.Application.Features.Queries.GetUsersById;

public class GetUsersByIdQueryHandler : IRequestHandler<GetUsersByIdQueryParam, UserDto>
{
    public readonly ISmartSearchService _smartSearchService;

    public GetUsersByIdQueryHandler(ISmartSearchService smartSearchService)
        => _smartSearchService = smartSearchService;

    public async Task<UserDto> Handle(GetUsersByIdQueryParam request, CancellationToken cancellationToken)
    {
        var user = await _smartSearchService.GetDocumentByFieldValue("userid", request.UserID.ToString());

        return user.ToUsersDto();
    }
}