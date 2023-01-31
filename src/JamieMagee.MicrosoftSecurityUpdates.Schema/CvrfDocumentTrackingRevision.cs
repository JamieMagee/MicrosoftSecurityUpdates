namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record CvrfDocumentTrackingRevision
{
    [JsonPropertyName("Number")]
    public string Number { get; init; }

    [JsonPropertyName("Date")]
    public DateTimeOffset Date { get; init; }

    [JsonPropertyName("Description")]
    public CvrfDocumentTrackingRevisionDescription Description { get; init; }
}
