namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record AffectedFile
{
    [JsonPropertyName("ProductId")]
    public string? ProductId { get; init; }

    [JsonPropertyName("FileName")]
    public required string FileName { get; init; }

    [JsonPropertyName("FileVersion")]
    public string? FileVersion { get; init; }

    [JsonPropertyName("FilePath")]
    public string? FilePath { get; init; }

    [JsonPropertyName("FileLastModified")]
    public DateTimeOffset FileLastModified { get; init; }

    [JsonPropertyName("FileArchitecture")]
    public string? FileArchitecture { get; init; }
}
