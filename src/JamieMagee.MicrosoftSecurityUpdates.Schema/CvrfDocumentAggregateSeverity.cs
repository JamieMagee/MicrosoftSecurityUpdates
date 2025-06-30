namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record CvrfDocumentAggregateSeverity
{
    [JsonPropertyName("Namespace")]
    public required string Namespace { get; init; }

    [JsonPropertyName("lang")]
    public string? Lang { get; init; }

    [JsonPropertyName("Value")]
    public required string Value { get; init; }
}
