using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;
using Microsoft.Extensions.Configuration;
using POC_Architecture_CQRS.Shared.Application.DTOs;
using FieldBuilder = Azure.Search.Documents.Indexes.FieldBuilder;

namespace POC_Architecture_CQRS.Shared.Application.Services.SmartSearch;

public class SmartSearchService : ISmartSearchService
{
    private readonly SearchIndexClient _searchIndexClient;
    private readonly SearchClient _searchClient;
    private readonly IConfiguration _configuration;

    public SmartSearchService(SearchClient searchClient, SearchIndexClient searchIndexClient, IConfiguration configuration)
    {
        this._searchClient = searchClient;
        this._searchIndexClient = searchIndexClient;
        _configuration = configuration;
    }

    public async Task<bool> CreateOrUpdateUserAddress(SmartSearchDto param)
    {
        var indexName = this._configuration.GetValue<string>("SearchClient:indexname");

        await this.CreateOrUpdateIndex(indexName);

        var input = new List<SmartSearchDto>() { param };
        IndexDocumentsResult result = await this._searchClient.MergeOrUploadDocumentsAsync(input.AsEnumerable());

        return result.Results.Count > 0;
    }

    public async Task<SmartSearchDto> GetDocumentByFieldValue(string fieldName, string value)
    {
        var options = new SearchOptions()
        {
            Filter = $" {fieldName} eq '{value}' "
        };

        var response = await _searchClient.SearchAsync<SmartSearchDto>("*", options);

        return response.Value.GetResults()?.FirstOrDefault()?.Document ?? new();
    }

    public async Task<IEnumerable<SmartSearchDto>> GetAllDocument()
    {
        var options = new SearchOptions
        {
            Size = 100,
            SessionId = Guid.NewGuid().ToString()
        };

        try
        {
            var response = await _searchClient.SearchAsync<SmartSearchDto>("*", options);

            return response.Value.GetResults().Select(u => u.Document);
        }
        catch
        {
            return Enumerable.Empty<SmartSearchDto>();
        }
    }

    private async Task CreateOrUpdateIndex(string indexName)
    {
        try
        {
            var response = await this._searchIndexClient.GetIndexAsync(indexName);

            if (response.Value != null)
            {
                return;
            }
        }
        catch
        {
            var fieldBuilder = new FieldBuilder();
            var searchFields = fieldBuilder.Build(typeof(SmartSearchDto));

            var definition = new SearchIndex(indexName, searchFields);
            await this._searchIndexClient.CreateOrUpdateIndexAsync(definition);
        }
    }
}