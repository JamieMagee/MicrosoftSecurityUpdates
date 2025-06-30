namespace JamieMagee.MicrosoftSecurityUpdates.Client;

/// <summary>
/// Client for interacting with the Microsoft Security Updates API.
/// </summary>
public interface IMicrosoftSecurityUpdatesClient
{
    /// <summary>
    /// Gets a CVRF document by its ID.
    /// The ID must be in the format yyyy-MMM (e.g., 2022-Jun, 2023-May, 2024-Dec).
    /// </summary>
    /// <param name="id">The ID of the CVRF document.</param>
    /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
    /// <returns>The CVRF document.</returns>
    /// <exception cref="ArgumentException">Thrown if the ID is null, whitespace, or not in the correct format.</exception>
    /// <exception cref="HttpRequestException">Thrown if the request fails.</exception>
    public Task<CvrfDocument> GetCvrfByIdAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets updates from the Microsoft Security Updates API.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
    /// <returns>The collection of updates.</returns>
    /// <exception cref="HttpRequestException">Thrown if the request fails.</exception>
    public Task<IEnumerable<Update>> GetUpdatesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets updates by their ID.
    /// The ID can be in one of the following formats:
    /// - Update ID: yyyy-MMM (e.g., 2024-May, 2022-Jun)
    /// - CVE ID: CVE-yyyy-nnnn (e.g., CVE-2024-1234)
    /// - Year: yyyy (e.g., 2024, 2023)
    /// </summary>
    /// <param name="id">The ID of the update.</param>
    /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
    /// <returns>The collection of updates matching the ID.</returns>
    /// <exception cref="ArgumentException">Thrown if the ID is null, whitespace, or not in the correct format.</exception>
    /// <exception cref="HttpRequestException">Thrown if the request fails.</exception>
    public Task<IEnumerable<Update>> GetUpdateByIdAsync(string id, CancellationToken cancellationToken = default);
}
