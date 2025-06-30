namespace JamieMagee.MicrosoftSecurityUpdates.Client.Models;

internal sealed record OdataWrapper<T>
    where T : class
{
    [JsonPropertyName("@odata.context")]
    public Uri OdataContext { get; init; } = null!;

    [JsonPropertyName("value")]
    public IEnumerable<T> Value { get; init; } = null!;
}
