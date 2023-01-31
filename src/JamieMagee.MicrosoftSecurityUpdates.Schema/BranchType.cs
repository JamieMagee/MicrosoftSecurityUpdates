namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record BranchType
{
    [JsonPropertyName("Items")]
    public IEnumerable<object> Items { get; init; }

    [JsonPropertyName("Type")]
    public uint Type { get; init; }

    [JsonPropertyName("Name")]
    public string Name { get; init; }
}
