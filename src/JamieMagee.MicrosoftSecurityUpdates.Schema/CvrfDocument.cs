namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record CvrfDocument
{
    [JsonPropertyName("DocumentTitle")]
    public CvrfDocumentTitle DocumentTitle { get; init; }

    [JsonPropertyName("DocumentType")]
    public CvrfDocumentType DocumentType { get; init; }

    [JsonPropertyName("DocumentPublisher")]
    public CvrfDocumentPublisher DocumentPublisher { get; init; }

    [JsonPropertyName("DocumentTracking")]
    public CvrfDocumentTracking DocumentTracking { get; init; }

    [JsonPropertyName("DocumentNotes")]
    public IEnumerable<CvrfDocumentNote> DocumentNotes { get; init; }

    [JsonPropertyName("DocumentDistribution")]
    public CvrfDocumentDistribution DocumentDistribution { get; init; }

    [JsonPropertyName("AggregateSeverity")]
    public CvrfDocumentAggregateSeverity AggregateSeverity { get; init; }

    [JsonPropertyName("DocumentReferences")]
    public IEnumerable<CvrfDocumentReference> DocumentReferences { get; init; }

    [JsonPropertyName("Acknowledgments")]
    public IEnumerable<CvrfDocumentAcknowledgment> Acknowledgments { get; init; }

    [JsonPropertyName("ProductTree")]
    public ProductTree ProductTree { get; init; }

    [JsonPropertyName("Vulnerability")]
    public IEnumerable<Vulnerability> Vulnerability { get; init; }
}
