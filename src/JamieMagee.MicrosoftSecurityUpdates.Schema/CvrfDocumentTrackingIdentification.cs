namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record CvrfDocumentTrackingIdentification
{
    [JsonPropertyName("ID")]
    public required CvrfDocumentTrackingIdentificationId Id { get; init; }

    [JsonPropertyName("Alias")]
    public required CvrfDocumentTrackingIdentificationAlias Alias { get; init; }
}
