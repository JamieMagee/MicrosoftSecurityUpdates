namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record CvrfDocumentReference
{
    [JsonPropertyName("URL")]
    public required string Url { get; init; }

    [JsonPropertyName("Description")]
    public required CvrfDocumentReferenceDescription Description { get; init; }

    [JsonPropertyName("Type")]
    public ReferenceType Type { get; init; }
}
