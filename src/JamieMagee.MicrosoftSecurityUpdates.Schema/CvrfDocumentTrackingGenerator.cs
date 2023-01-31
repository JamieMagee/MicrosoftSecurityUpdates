namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record CvrfDocumentTrackingGenerator
{
    [JsonPropertyName("Engine")]
    public CvrfDocumentTrackingGeneratorEngine Engine { get; init; }

    [JsonPropertyName("Date")]
    public DateTimeOffset Date { get; init; }

    [JsonPropertyName("DateSpecified")]
    public bool DateSpecified { get; init; }
}
