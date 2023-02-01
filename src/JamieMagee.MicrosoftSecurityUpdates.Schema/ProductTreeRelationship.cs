namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record ProductTreeRelationship
{
    [JsonPropertyName("FullProductName")]
    public IEnumerable<FullProductName> FullProductName { get; init; }

    [JsonPropertyName("ProductReference")]
    public string ProductReference { get; init; }

    [JsonPropertyName("RelationType")]
    public RelationType RelationType { get; init; }

    [JsonPropertyName("RelatesToProductReference")]
    public string RelatesToProductReference { get; init; }
}
