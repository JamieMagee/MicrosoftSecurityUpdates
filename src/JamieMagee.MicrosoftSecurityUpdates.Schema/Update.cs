namespace JamieMagee.MicrosoftSecurityUpdates.Schema;

public sealed record Update
{
    /// <summary>
    ///     Alternative ID for CVRF document.
    /// </summary>
    [JsonPropertyName("Alias")]
    public required string Alias { get; init; }

    /// <summary>
    ///     Date that the CVRF document was last modified.
    /// </summary>
    public DateTimeOffset CurrentReleaseDate { get; init; }

    /// <summary>
    ///     URL of CVRF document (for CVRF endpoint).
    /// </summary>
    public required string CvrfUrl { get; init; }

    /// <summary>
    ///     Title of CVRF document.
    /// </summary>
    public required string DocumentTitle { get; init; }

    /// <summary>
    ///     Unique identifier for CVRF document, often yyyy-mmm.
    /// </summary>
    public required string Id { get; init; }

    /// <summary>
    ///     Date that the CVRF document was initially released.
    /// </summary>
    public DateTimeOffset InitialReleaseDate { get; init; }

    /// <summary>
    ///     Aggregate severity.
    /// </summary>
    public required string Severity { get; init; }
}
