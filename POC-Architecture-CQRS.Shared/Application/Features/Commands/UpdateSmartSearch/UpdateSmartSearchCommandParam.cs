using MediatR;
using POC_Architecture_CQRS.Shared.Application.DTOs;

namespace POC_Architecture_CQRS.Shared.Application.Features.Commands.UpdateSmartSearch;

public record UpdateSmartSearchCommandParam(SmartSearchDto Param) : INotification

{ }