namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record CvrfDocument
{
    [JsonPropertyName("DocumentTitle")]
    public CvrfDocumentTitle DocumentTitle { get; init; }
}

public sealed record CvrfDocumentTitle
{
    [JsonPropertyName("lang")]
    public string? Lang { get; init; }

    [JsonPropertyName("Value")]
    public string Value { get; init; } = null!;
}
