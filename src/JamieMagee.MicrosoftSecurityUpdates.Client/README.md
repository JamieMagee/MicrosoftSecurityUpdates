# Microsoft Security Updates Client

A .NET HTTP client for accessing the Microsoft Security Response Center (MSRC) API to retrieve security updates and vulnerability information.

## Features

- Typed HTTP client for resilient HTTP requests
- Support for dependency injection and direct instantiation
- Built-in JSON serialization with proper configuration
- Configurable base address and HTTP client options
- Full async/await support with cancellation tokens

## Installation

```xml
<PackageReference Include="JamieMagee.MicrosoftSecurityUpdates.Client" Version="x.x.x" />
```

## Usage

### With Dependency Injection (Recommended)

Register the client in your DI container:

```csharp
using JamieMagee.MicrosoftSecurityUpdates.Client;

// In Program.cs or Startup.cs
builder.Services.AddMicrosoftSecurityUpdatesClient();

// Or with custom base address
builder.Services.AddMicrosoftSecurityUpdatesClient("https://api.msrc.microsoft.com/cvrf/v2.0");

// Or with custom HttpClient configuration
builder.Services.AddMicrosoftSecurityUpdatesClient(httpClient =>
{
    httpClient.BaseAddress = new Uri("https://api.msrc.microsoft.com/cvrf/v2.0");
    httpClient.Timeout = TimeSpan.FromSeconds(30);
    // Add custom headers, configure policies, etc.
});
```

Then inject and use the client:

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

### Direct Instantiation

You can also create instances directly:

```csharp
// Using default API endpoint
using var client = new MicrosoftSecurityUpdatesClient();

// Using custom base address
using var client = new MicrosoftSecurityUpdatesClient("https://api.msrc.microsoft.com/cvrf/v2.0");

// Using your own HttpClient (for advanced scenarios)
using var httpClient = new HttpClient();
httpClient.BaseAddress = new Uri("https://api.msrc.microsoft.com/cvrf/v2.0");
var client = new MicrosoftSecurityUpdatesClient(httpClient);

// Get updates
var updates = await client.GetUpdatesAsync();
```

## Advanced Configuration

### Adding Polly for Resilience

```csharp
using Polly;
using Polly.Extensions.Http;

builder.Services.AddMicrosoftSecurityUpdatesClient()
    .AddPolicyHandler(HttpPolicyExtensions
        .HandleTransientHttpError()
        .WaitAndRetryAsync(3, retryAttempt => 
            TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))));
```

### Custom HttpClient Configuration

```csharp
builder.Services.AddMicrosoftSecurityUpdatesClient(httpClient =>
{
    // Custom timeout
    httpClient.Timeout = TimeSpan.FromMinutes(5);
    
    // Custom headers
    httpClient.DefaultRequestHeaders.Add("X-Custom-Header", "Value");
    
    // Configure base address
    httpClient.BaseAddress = new Uri("https://api.msrc.microsoft.com/cvrf/v2.0");
});
```

## API Methods

### GetUpdatesAsync()
Retrieves all available security updates.

```csharp
var updates = await client.GetUpdatesAsync();
```

### GetUpdateByIdAsync(string id)
Retrieves a specific security update by ID.

```csharp
var update = await client.GetUpdateByIdAsync("2024-Jan");
```

### GetCvrfByIdAsync(string id)
Retrieves a CVRF (Common Vulnerability Reporting Framework) document by ID.

```csharp
var cvrfDocument = await client.GetCvrfByIdAsync("2024-Jan");
```

## Migration from RestSharp

If you're migrating from the previous RestSharp-based version:

1. The API methods remain the same
2. Constructor signatures have changed to support HttpClient injection
3. Add the new NuGet packages and remove RestSharp dependency
4. Update your DI registration to use `AddMicrosoftSecurityUpdatesClient()`

## Benefits

- **Better Resource Management**: HttpClient lifetime is managed by HttpClientFactory
- **Resilience**: Built-in support for Polly policies
- **Performance**: Connection pooling and DNS change handling
- **Testability**: Easy to mock with `IMicrosoftSecurityUpdatesClient`
- **Configuration**: Flexible configuration through DI
- **Standards Compliant**: Uses System.Text.Json for serialization
