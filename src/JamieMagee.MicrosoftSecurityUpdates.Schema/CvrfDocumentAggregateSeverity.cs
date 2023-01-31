namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record CvrfDocumentAggregateSeverity
{
    [JsonPropertyName("Namespace")]
    public string Namespace { get; init; }

    [JsonPropertyName("lang")]
    public string? Lang { get; init; }

    [JsonPropertyName("Value")]
    public string Value { get; init; }
}
