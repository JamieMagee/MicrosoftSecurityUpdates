namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record CvrfDocument
{
    [JsonPropertyName("DocumentTitle")]
    public required CvrfDocumentTitle DocumentTitle { get; init; }

    [JsonPropertyName("DocumentType")]
    public required CvrfDocumentType DocumentType { get; init; }

    [JsonPropertyName("DocumentPublisher")]
    public required CvrfDocumentPublisher DocumentPublisher { get; init; }

    [JsonPropertyName("DocumentTracking")]
    public required CvrfDocumentTracking DocumentTracking { get; init; }

    [JsonPropertyName("DocumentNotes")]
    public required IEnumerable<CvrfDocumentNote> DocumentNotes { get; init; }

    [JsonPropertyName("DocumentDistribution")]
    public required CvrfDocumentDistribution DocumentDistribution { get; init; }

    [JsonPropertyName("AggregateSeverity")]
    public required CvrfDocumentAggregateSeverity AggregateSeverity { get; init; }

    [JsonPropertyName("DocumentReferences")]
    public required IEnumerable<CvrfDocumentReference> DocumentReferences { get; init; }

    [JsonPropertyName("Acknowledgments")]
    public required IEnumerable<CvrfDocumentAcknowledgment> Acknowledgments { get; init; }

    [JsonPropertyName("ProductTree")]
    public required ProductTree ProductTree { get; init; }

    [JsonPropertyName("Vulnerability")]
    public required IEnumerable<Vulnerability> Vulnerability { get; init; }
}
