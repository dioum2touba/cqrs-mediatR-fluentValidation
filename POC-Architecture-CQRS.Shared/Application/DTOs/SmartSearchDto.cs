using Azure.Search.Documents.Indexes;
using System.Text.Json.Serialization;

namespace POC_Architecture_CQRS.Shared.Application.DTOs;

public class SmartSearchDto
{
    [SimpleField(IsKey = true, IsFilterable = true)]
    [JsonPropertyName("indexid")]
    public string IndexId { get; set; }

    [SearchableField(IsFilterable = true, IsSortable = true)]
    [JsonPropertyName("address_complet")]
    public string AddressString { get; set; }

    [SearchableField(IsFilterable = true, IsSortable = true)]
    [JsonPropertyName("userid")]
    public string UserId { get; set; }

    [SearchableField(IsFilterable = true, IsSortable = true)]
    [JsonPropertyName("firstname")]
    public string FirstName { get; set; }

    [SearchableField(IsFilterable = true, IsSortable = true)]
    [JsonPropertyName("lastname")]
    public string LastName { get; set; }

    [SearchableField(IsFilterable = true, IsSortable = true)]
    [JsonPropertyName("phonenumber")]
    public string PhoneNumber { get; set; }

    [SearchableField(IsFilterable = true, IsSortable = true)]
    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    public AddressSmartSearchDto AddressSmartSearch { get; set; }
}