namespace JamieMagee.MicrosoftSecurityUpdates.Client;

using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using JamieMagee.MicrosoftSecurityUpdates.Client.Models;

/// <summary>
/// Client for interacting with the Microsoft Security Updates API.
/// </summary>
public sealed partial class MicrosoftSecurityUpdatesClient : IMicrosoftSecurityUpdatesClient, IDisposable
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

        if (!CvrfIdFormatRegex().IsMatch(id))
        {
            throw new ArgumentException("ID must be in the format yyyy-MMM (e.g., 2022-Jun, 2024-May, 2023-Dec).", nameof(id));
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

        if (!UpdateIdFormatRegex().IsMatch(id))
        {
            throw new ArgumentException("ID must be in one of the following formats: yyyy-MMM (e.g., 2024-May), CVE-yyyy-nnnn (e.g., CVE-2024-1234), or yyyy (e.g., 2024).", nameof(id));
        }

        var response = await this.httpClient.GetAsync($"updates/{id}", cancellationToken).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        var jsonContent = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        var wrapper = JsonSerializer.Deserialize<OdataWrapper<Update>>(jsonContent, this.jsonSerializerOptions)
            ?? throw new InvalidOperationException("Failed to deserialize response.");

        return wrapper.Value;
    }

    /// <summary>
    /// Gets a regex for validating CVRF ID format (yyyy-MMM, e.g., 2022-Jun, 2024-May, 2023-Dec).
    /// </summary>
    /// <returns>A compiled regex for CVRF ID validation.</returns>
    [GeneratedRegex(@"^\d{4}-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)$")]
    private static partial Regex CvrfIdFormatRegex();

    /// <summary>
    /// Gets a regex for validating Update ID format. Supports:
    /// - Update ID: yyyy-MMM (e.g., 2024-May, 2022-Jun)
    /// - CVE ID: CVE-yyyy-nnnn (e.g., CVE-2024-1234)
    /// - Year: yyyy (e.g., 2024, 2023)
    /// </summary>
    /// <returns>A compiled regex for Update ID validation.</returns>
    [GeneratedRegex(@"^(\d{4}-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)|CVE-\d{4}-\d+|\d{4})$")]
    private static partial Regex UpdateIdFormatRegex();

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
