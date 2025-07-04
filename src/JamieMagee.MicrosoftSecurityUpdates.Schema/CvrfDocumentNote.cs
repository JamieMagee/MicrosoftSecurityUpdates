namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record CvrfDocumentNote
{
    [JsonPropertyName("Title")]
    public required string Title { get; init; }

    [JsonPropertyName("Audience")]
    public required string Audience { get; init; }

    [JsonPropertyName("Type")]
    public NoteType Type { get; init; }

    [JsonPropertyName("Ordinal")]
    public required string Ordinal { get; init; }

    [JsonPropertyName("lang")]
    public string? Lang { get; init; }

    [JsonPropertyName("Value")]
    public required string Value { get; init; }
}
