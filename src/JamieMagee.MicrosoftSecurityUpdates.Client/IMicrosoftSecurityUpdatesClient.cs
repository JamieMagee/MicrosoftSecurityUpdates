namespace JamieMagee.MicrosoftSecurityUpdates.Client;

public interface IMicrosoftSecurityUpdatesClient
{
    Task<CvrfDocument> GetCvrfByIdAsync(string id, CancellationToken cancellationToken = default);

    Task<IEnumerable<Update>> GetUpdatesAsync(CancellationToken cancellationToken = default);

    Task<IEnumerable<Update>> GetUpdateByIdAsync(string id, CancellationToken cancellationToken = default);
}
