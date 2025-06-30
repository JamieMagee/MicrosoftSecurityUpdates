namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record AffectedFile
{
    [JsonPropertyName("ProductId")]
    public required string ProductId { get; init; }

    [JsonPropertyName("FileName")]
    public required string FileName { get; init; }

    [JsonPropertyName("FileVersion")]
    public required string FileVersion { get; init; }

    [JsonPropertyName("FilePath")]
    public required string FilePath { get; init; }

    [JsonPropertyName("FileLastModified")]
    public DateTimeOffset FileLastModified { get; init; }

    [JsonPropertyName("FileArchitecture")]
    public required string FileArchitecture { get; init; }
}
