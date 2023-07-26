using MediatR;
using POC_Architecture_CQRS.Shared.Application.Services.SmartSearch;

namespace POC_Architecture_CQRS.Shared.Application.Features.Commands.UpdateSmartSearch;

public class UpdateSmartSearchCommandHandler : INotificationHandler<UpdateSmartSearchCommandParam>
{
    private readonly ISmartSearchService _smartSearchService;

    public UpdateSmartSearchCommandHandler(ISmartSearchService smartSearchService)
        => _smartSearchService = smartSearchService;

    public async Task Handle(UpdateSmartSearchCommandParam notification, CancellationToken cancellationToken)
    {
        _ = await _smartSearchService.CreateOrUpdateUserAddress(notification.Param);
    }
}