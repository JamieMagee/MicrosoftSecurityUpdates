namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record FullProductName
{
    [JsonPropertyName("ProductID")]
    public string ProductId { get; init; }

    [JsonPropertyName("CPE")]
    public string Cpe { get; init; }

    [JsonPropertyName("Value")]
    public string Value { get; init; }
}
