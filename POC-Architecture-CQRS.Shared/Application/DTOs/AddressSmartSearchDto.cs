using Azure.Search.Documents.Indexes;
using System.Text.Json.Serialization;

namespace POC_Architecture_CQRS.Shared.Application.DTOs;

public class AddressSmartSearchDto
{
    [SearchableField(IsFilterable = true, IsSortable = true)]
    [JsonPropertyName("addressid")]
    public string AddressId { get; set; }

    [SimpleField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
    [JsonPropertyName("postalcode")]
    public int PostalCode { get; set; }

    [SearchableField(IsFilterable = true, IsSortable = true)]
    [JsonPropertyName("state")]
    public string State { get; set; }
}