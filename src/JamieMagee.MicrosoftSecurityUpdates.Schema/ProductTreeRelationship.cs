namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record ProductTreeRelationship
{
    [JsonPropertyName("FullProductName")]
    public required IEnumerable<FullProductName> FullProductName { get; init; }

    [JsonPropertyName("ProductReference")]
    public required string ProductReference { get; init; }

    [JsonPropertyName("RelationType")]
    public RelationType RelationType { get; init; }

    [JsonPropertyName("RelatesToProductReference")]
    public required string RelatesToProductReference { get; init; }
}
