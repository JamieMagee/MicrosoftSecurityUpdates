namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record FullProductName
{
    [JsonPropertyName("ProductID")]
    public required string ProductId { get; init; }

    [JsonPropertyName("CPE")]
    public required string Cpe { get; init; }

    [JsonPropertyName("Value")]
    public required string Value { get; init; }
}
