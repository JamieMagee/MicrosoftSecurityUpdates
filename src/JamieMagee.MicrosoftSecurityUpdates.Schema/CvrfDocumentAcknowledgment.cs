namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record CvrfDocumentAcknowledgment
{
    [JsonPropertyName("Name")]
    public IEnumerable<CvrfDocumentAcknowledgmentName> Name { get; init; }

    [JsonPropertyName("Organization")]
    public IEnumerable<CvrfDocumentAcknowledgmentOrganization> Organization { get; init; }

    [JsonPropertyName("Description")]
    public CvrfDocumentAcknowledgmentDescription Description { get; init; }

    [JsonPropertyName("URL")]
    public IEnumerable<string> Url { get; init; }
}
