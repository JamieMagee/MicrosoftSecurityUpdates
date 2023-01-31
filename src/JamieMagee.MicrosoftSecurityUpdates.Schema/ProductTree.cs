namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record ProductTree
{
    [JsonPropertyName("Branch")]
    public IEnumerable<BranchType> Branch { get; init; }

    [JsonPropertyName("FullProductName")]
    public IEnumerable<FullProductName> FullProductName { get; init; }

    [JsonPropertyName("Relationship")]
    public IEnumerable<ProductTreeRelationship> Relationship { get; init; }

    [JsonPropertyName("ProductGroups")]
    public IEnumerable<ProductTreeGroup> ProductGroups { get; init; }
}
