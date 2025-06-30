namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record CvrfDocumentPublisher
{
    [JsonPropertyName("ContactDetails")]
    public required CvrfDocumentPublisherContactDetails ContactDetails { get; init; }

    [JsonPropertyName("IssuingAuthority")]
    public required CvrfDocumentPublisherIssuingAuthority IssuingAuthority { get; init; }

    [JsonPropertyName("Type")]
    public PublisherType Type { get; init; }

    [JsonPropertyName("VendorID")]
    public CvrfDocumentPublisherIssuingAuthority? VendorId { get; init; }
}
