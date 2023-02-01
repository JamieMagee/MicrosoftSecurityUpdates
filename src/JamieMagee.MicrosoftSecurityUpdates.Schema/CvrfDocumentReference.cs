namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record CvrfDocumentReference
{
    [JsonPropertyName("URL")]
    public string Url { get; init; }

    [JsonPropertyName("Description")]
    public CvrfDocumentReferenceDescription Description { get; init; }

    [JsonPropertyName("Type")]
    public ReferenceType Type { get; init; }
}
