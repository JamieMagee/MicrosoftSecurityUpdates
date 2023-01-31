namespace JamieMagee.MicrosoftSecurityUpdates.Client;

using System.Reflection;
using JamieMagee.MicrosoftSecurityUpdates.Client.Models;

public sealed class MicrosoftSecurityUpdatesClient : IMicrosoftSecurityUpdatesClient, IDisposable
{
    private readonly RestClient client;

    public MicrosoftSecurityUpdatesClient(string baseUri)
    {
        var version = typeof(MicrosoftSecurityUpdatesClient).GetTypeInfo().Assembly.GetName().Version;

        var clientOptions = new RestClientOptions(baseUri)
        {
            UserAgent = $"JamieMagee.MicrosoftSecurityUpdates.Client/{version}",
        };

        this.client = new RestClient(clientOptions)
            .AddDefaultHeader("Accept", "application/json");
    }

    public MicrosoftSecurityUpdatesClient()
        : this("https://api.msrc.microsoft.com/cvrf/v2.0")
    {
    }

    public void Dispose() => this.client.Dispose();

    public Task<CvrfDocument> GetCvrfByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var request = new RestRequest($"cvrf/{id}");
        return this.ExecuteAsync<CvrfDocument>(request, cancellationToken);
    }

    public async Task<IEnumerable<Update>> GetUpdatesAsync(CancellationToken cancellationToken = default)
    {
        var request = new RestRequest("updates");
        return (await this.ExecuteAsync<OdataWrapper<Update>>(request, cancellationToken)).Value;
    }

    public async Task<IEnumerable<Update>> GetUpdateByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var request = new RestRequest($"updates('{id}')");
        return (await this.ExecuteAsync<OdataWrapper<Update>>(request, cancellationToken)).Value;
    }

    private async Task<T> ExecuteAsync<T>(RestRequest request, CancellationToken cancellationToken = default)
        where T : new()
    {
        T data;

        var response = await this.client.ExecuteAsync<T>(request, cancellationToken).ConfigureAwait(false);
        if (!response.IsSuccessful)
        {
            throw new Exception(null);
        }

        data = response.ThrowIfError().Data!;

        return data;
    }
}
