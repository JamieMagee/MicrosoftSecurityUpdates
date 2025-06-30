namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record ProductTree
{
    [JsonPropertyName("Branch")]
    public required IEnumerable<BranchType> Branch { get; init; }

    [JsonPropertyName("FullProductName")]
    public required IEnumerable<FullProductName> FullProductName { get; init; }

    [JsonPropertyName("Relationship")]
    public required IEnumerable<ProductTreeRelationship> Relationship { get; init; }

    [JsonPropertyName("ProductGroups")]
    public required IEnumerable<ProductTreeGroup> ProductGroups { get; init; }
}
