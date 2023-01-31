namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record CvrfDocumentPublisherIssuingAuthority
{
    [JsonPropertyName("lang")]
    public string? Lang { get; init; }

    [JsonPropertyName("Value")]
    public string Value { get; init; } = null!;
}
