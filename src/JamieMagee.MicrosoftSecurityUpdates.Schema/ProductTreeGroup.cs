namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record ProductTreeGroup
{
    [JsonPropertyName("Description")]
    public ProductTreeGroupDescription Description { get; init; }

    [JsonPropertyName("ProductID")]
    public IEnumerable<string> ProductId { get; init; }

    [JsonPropertyName("GroupID")]
    public string GroupId { get; init; }
}
