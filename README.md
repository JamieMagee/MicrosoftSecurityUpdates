# Microsoft Security Updates Client

[![GitHub Workflow Status](https://img.shields.io/github/actions/workflow/status/JamieMagee/MicrosoftSecurityUpdates/build.yml?branch=main&style=for-the-badge)](https://github.com/JamieMagee/MicrosoftSecurityUpdates/actions/workflows/build.yml?query=branch%3Amain)
[![NuGet Package Version](https://img.shields.io/nuget/v/JamieMagee.MicrosoftSecurityUpdates.Client?style=for-the-badge)](https://www.nuget.org/packages/JamieMagee.MicrosoftSecurityUpdates.Client/)
[![NuGet Package Downloads](https://img.shields.io/nuget/dt/JamieMagee.MicrosoftSecurityUpdates.Client?style=for-the-badge)](https://www.nuget.org/packages/JamieMagee.MicrosoftSecurityUpdates.Client/)
[![MIT License](https://img.shields.io/github/license/JamieMagee/MicrosoftSecurityUpdates?style=for-the-badge)](https://github.com/JamieMagee/MicrosoftSecurityUpdates/blob/main/LICENSE.md)

An unofficial .NET API client for the [MSRC CVRF API][1]

## Usage

There are two main ways to use this client:

- Dependency Injection
- Manual Instantiation

### Dependency Injection

To use the client with dependency injection, register it in your `IServiceCollection`:

```csharp
using JamieMagee.MicrosoftSecurityUpdates.Client;

// In Program.cs
builder.Services.AddMicrosoftSecurityUpdatesClient();

// Or with custom HttpClient configuration
builder.Services.AddMicrosoftSecurityUpdatesClient(httpClient =>
{
    // Add custom headers, configure policies, etc.
    httpClient.Timeout = TimeSpan.FromSeconds(30);
});
```

Then inject `IMicrosoftSecurityUpdatesClient` into your services:

```csharp
public class SecurityService
{
    private readonly IMicrosoftSecurityUpdatesClient _client;

    public SecurityService(IMicrosoftSecurityUpdatesClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<Update>> GetLatestUpdatesAsync()
    {
        return await _client.GetUpdatesAsync();
    }

    public async Task<CvrfDocument> GetSecurityBulletinAsync(string id)
    {
        return await _client.GetCvrfByIdAsync(id);
    }
}
```

### Manual Instantiation

You can also create instances manually:

```csharp
// Using default HttpClient
using var client = new MicrosoftSecurityUpdatesClient();

// Using your own HttpClient (for advanced scenarios)
using var httpClient = new HttpClient();
httpClient.Timeout = TimeSpan.FromSeconds(30);
var client = new MicrosoftSecurityUpdatesClient(httpClient);

// Get updates
var updates = await client.GetUpdatesAsync();
```

## License

All packages in this repository are licensed under [the MIT license](https://opensource.org/licenses/MIT).

[1]: https://msrc.microsoft.com/update-guide
