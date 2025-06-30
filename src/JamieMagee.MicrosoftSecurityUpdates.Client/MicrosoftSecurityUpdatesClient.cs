namespace JamieMagee.MicrosoftSecurityUpdates.Client;

using System.Reflection;
using System.Text.Json;
using JamieMagee.MicrosoftSecurityUpdates.Client.Models;

public sealed class MicrosoftSecurityUpdatesClient : IMicrosoftSecurityUpdatesClient, IDisposable
{
    private readonly HttpClient httpClient;
    private readonly bool shouldDisposeHttpClient;
    private readonly JsonSerializerOptions jsonSerializerOptions;

    public MicrosoftSecurityUpdatesClient(HttpClient httpClient)
    {
        this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        this.shouldDisposeHttpClient = false;
        this.jsonSerializerOptions = CreateJsonSerializerOptions();

        this.ConfigureHttpClient();
    }

    public MicrosoftSecurityUpdatesClient(string baseUri = "https://api.msrc.microsoft.com/cvrf/v3.0/")
    {
        this.httpClient = new HttpClient();
        this.shouldDisposeHttpClient = true;
        this.jsonSerializerOptions = CreateJsonSerializerOptions();

        this.httpClient.BaseAddress = new Uri(baseUri);
        this.ConfigureHttpClient();
    }

    public void Dispose()
    {
        if (this.shouldDisposeHttpClient)
        {
            this.httpClient.Dispose();
        }
    }

    public async Task<CvrfDocument> GetCvrfByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException("ID cannot be null or whitespace.", nameof(id));
        }

        var response = await this.httpClient.GetAsync($"cvrf/{id}", cancellationToken).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        var jsonContent = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        return JsonSerializer.Deserialize<CvrfDocument>(jsonContent, this.jsonSerializerOptions)
            ?? throw new InvalidOperationException("Failed to deserialize response.");
    }

    public async Task<IEnumerable<Update>> GetUpdatesAsync(CancellationToken cancellationToken = default)
    {
        var response = await this.httpClient.GetAsync("updates", cancellationToken).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        var jsonContent = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        var wrapper = JsonSerializer.Deserialize<OdataWrapper<Update>>(jsonContent, this.jsonSerializerOptions)
            ?? throw new InvalidOperationException("Failed to deserialize response.");

        return wrapper.Value;
    }

    public async Task<IEnumerable<Update>> GetUpdateByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException("ID cannot be null or whitespace.", nameof(id));
        }

        var response = await this.httpClient.GetAsync($"updates/{id}", cancellationToken).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        var jsonContent = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        var wrapper = JsonSerializer.Deserialize<OdataWrapper<Update>>(jsonContent, this.jsonSerializerOptions)
            ?? throw new InvalidOperationException("Failed to deserialize response.");

        return wrapper.Value;
    }

    private static JsonSerializerOptions CreateJsonSerializerOptions() => new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true,
    };

    private void ConfigureHttpClient()
    {
        var version = typeof(MicrosoftSecurityUpdatesClient).GetTypeInfo().Assembly.GetName().Version;

        this.httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        this.httpClient.DefaultRequestHeaders.Add("User-Agent", $"JamieMagee.MicrosoftSecurityUpdates.Client/{version}");
    }
}
