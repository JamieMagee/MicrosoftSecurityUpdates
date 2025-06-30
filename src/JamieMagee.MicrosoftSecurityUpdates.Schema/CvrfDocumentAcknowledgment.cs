namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record CvrfDocumentAcknowledgment
{
    [JsonPropertyName("Name")]
    public required IEnumerable<CvrfDocumentAcknowledgmentName> Name { get; init; }

    [JsonPropertyName("Organization")]
    public required IEnumerable<CvrfDocumentAcknowledgmentOrganization> Organization { get; init; }

    [JsonPropertyName("Description")]
    public required CvrfDocumentAcknowledgmentDescription Description { get; init; }

    [JsonPropertyName("URL")]
    public required IEnumerable<string> Url { get; init; }
}
