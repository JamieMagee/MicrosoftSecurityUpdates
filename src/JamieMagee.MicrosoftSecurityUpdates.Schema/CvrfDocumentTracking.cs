namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record CvrfDocumentTracking
{
    [JsonPropertyName("Identification")]
    public CvrfDocumentTrackingIdentification Identification { get; init; }

    [JsonPropertyName("Status")]
    public CvrfDocumentTrackingStatus Status { get; init; }

    [JsonPropertyName("Version")]
    public string Version { get; init; }

    [JsonPropertyName("RevisionHistory")]
    public IEnumerable<CvrfDocumentTrackingRevision> RevisionHistory { get; init; }

    [JsonPropertyName("InitialReleaseDate")]
    public DateTimeOffset InitialReleaseDate { get; init; }

    [JsonPropertyName("CurrentReleaseDate")]
    public DateTimeOffset CurrentReleaseDate { get; init; }

    [JsonPropertyName("Generator")]
    public CvrfDocumentTrackingGenerator Generator { get; init; }
}
