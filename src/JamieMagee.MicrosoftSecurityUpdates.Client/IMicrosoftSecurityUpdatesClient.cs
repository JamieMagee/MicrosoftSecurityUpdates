namespace JamieMagee.MicrosoftSecurityUpdates.Client;

public interface IMicrosoftSecurityUpdatesClient
{
    public Task<CvrfDocument> GetCvrfByIdAsync(string id, CancellationToken cancellationToken = default);

    public Task<IEnumerable<Update>> GetUpdatesAsync(CancellationToken cancellationToken = default);

    public Task<IEnumerable<Update>> GetUpdateByIdAsync(string id, CancellationToken cancellationToken = default);
}
