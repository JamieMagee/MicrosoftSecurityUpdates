namespace JamieMagee.MicrosoftSecurityUpdates.Client;

using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for adding Microsoft Security Updates client to the service collection.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the Microsoft Security Updates client to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="baseAddress">The base address for the Microsoft Security Updates API. Defaults to the official API endpoint.</param>
    /// <returns>An <see cref="IHttpClientBuilder"/> for further configuration.</returns>
    public static IHttpClientBuilder AddMicrosoftSecurityUpdatesClient(
        this IServiceCollection services,
        string baseAddress = "https://api.msrc.microsoft.com/cvrf/v2.0") =>
        services.AddHttpClient<IMicrosoftSecurityUpdatesClient, MicrosoftSecurityUpdatesClient>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);

            var version = typeof(MicrosoftSecurityUpdatesClient).GetTypeInfo().Assembly.GetName().Version;
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("User-Agent", $"JamieMagee.MicrosoftSecurityUpdates.Client/{version}");
        });

    /// <summary>
    /// Adds the Microsoft Security Updates client to the service collection with custom configuration.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configureClient">A delegate to configure the HttpClient.</param>
    /// <returns>An <see cref="IHttpClientBuilder"/> for further configuration.</returns>
    public static IHttpClientBuilder AddMicrosoftSecurityUpdatesClient(
        this IServiceCollection services,
        Action<HttpClient> configureClient) =>
        services.AddHttpClient<IMicrosoftSecurityUpdatesClient, MicrosoftSecurityUpdatesClient>(configureClient);
}
