namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record ProductTreeGroup
{
    [JsonPropertyName("Description")]
    public required ProductTreeGroupDescription Description { get; init; }

    [JsonPropertyName("ProductID")]
    public required IEnumerable<string> ProductId { get; init; }

    [JsonPropertyName("GroupID")]
    public required string GroupId { get; init; }
}
