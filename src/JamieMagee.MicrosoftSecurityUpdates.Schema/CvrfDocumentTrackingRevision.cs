namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record CvrfDocumentTrackingRevision
{
    [JsonPropertyName("Number")]
    public required string Number { get; init; }

    [JsonPropertyName("Date")]
    public DateTimeOffset Date { get; init; }

    [JsonPropertyName("Description")]
    public required CvrfDocumentTrackingRevisionDescription Description { get; init; }
}
