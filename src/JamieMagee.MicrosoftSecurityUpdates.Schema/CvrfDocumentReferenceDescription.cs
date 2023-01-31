namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record CvrfDocumentReferenceDescription
{
    [JsonPropertyName("lang")]
    public string? Lang { get; init; }

    [JsonPropertyName("Value")]
    public string Value { get; init; }
}
