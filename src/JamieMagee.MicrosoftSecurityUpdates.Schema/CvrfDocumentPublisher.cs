namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record CvrfDocumentPublisher
{
    [JsonPropertyName("ContactDetails")]
    public CvrfDocumentPublisherContactDetails ContactDetails { get; init; }

    [JsonPropertyName("IssuingAuthority")]
    public CvrfDocumentPublisherIssuingAuthority IssuingAuthority { get; init; }

    [JsonPropertyName("Type")]
    public uint Type { get; init; }

    [JsonPropertyName("VendorID")]
    public CvrfDocumentPublisherIssuingAuthority VendorId { get; init; }
}
