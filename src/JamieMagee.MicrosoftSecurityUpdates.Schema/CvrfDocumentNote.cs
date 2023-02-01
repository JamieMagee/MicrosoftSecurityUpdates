namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record CvrfDocumentNote
{
    [JsonPropertyName("Title")]
    public string Title { get; init; }

    [JsonPropertyName("Audience")]
    public string Audience { get; init; }

    [JsonPropertyName("Type")]
    public NoteType Type { get; init; }

    [JsonPropertyName("Ordinal")]
    public string Ordinal { get; init; }

    [JsonPropertyName("lang")]
    public string? Lang { get; init; }

    [JsonPropertyName("Value")]
    public string Value { get; init; }
}
