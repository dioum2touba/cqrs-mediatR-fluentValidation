using POC_Architecture_CQRS.Shared.Application.DTOs;

namespace POC_Architecture_CQRS.Shared.Application.Services.SmartSearch;

public interface ISmartSearchService
{
    Task<SmartSearchDto> GetDocumentByFieldValue(string fieldName, string value);

    Task<bool> CreateOrUpdateUserAddress(SmartSearchDto param);

    Task<IEnumerable<SmartSearchDto>> GetAllDocument();
}