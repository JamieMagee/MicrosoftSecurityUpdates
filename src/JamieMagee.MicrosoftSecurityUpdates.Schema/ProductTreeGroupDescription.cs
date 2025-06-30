namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record ProductTreeGroupDescription
{
    [JsonPropertyName("lang")]
    public string? Lang { get; init; }

    [JsonPropertyName("Value")]
    public required string Value { get; init; }
}
