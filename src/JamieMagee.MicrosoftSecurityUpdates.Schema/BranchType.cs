namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record BranchType
{
    [JsonPropertyName("Items")]
    public required IEnumerable<object> Items { get; init; }

    [JsonPropertyName("Type")]
    public BranchTypeType Type { get; init; }

    [JsonPropertyName("Name")]
    public required string Name { get; init; }
}
