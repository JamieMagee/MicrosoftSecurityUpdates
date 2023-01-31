namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record CvrfDocumentTrackingIdentification
{
    [JsonPropertyName("ID")]
    public CvrfDocumentTrackingIdentificationId Id { get; init; }

    [JsonPropertyName("Alias")]
    public CvrfDocumentTrackingIdentificationAlias Alias { get; init; }
}
