# Microsoft Security Updates Client

[![GitHub Workflow Status](https://img.shields.io/github/actions/workflow/status/JamieMagee/MicrosoftSecurityUpdates/build.yml?branch=main&style=for-the-badge)](https://github.com/JamieMagee/MicrosoftSecurityUpdates/actions/workflows/build.yml?query=branch%3Amain)
[![MIT License](https://img.shields.io/github/license/JamieMagee/MicrosoftSecurityUpdates?style=for-the-badge)](https://github.com/JamieMagee/MicrosoftSecurityUpdates/blob/main/LICENSE.md)

An unofficial .NET API client for the [MSRC CVRF API][1]

## Usage

1. `dotnet add package JamieMagee.MicrosoftSecurityUpdates.Client`
2. Create an instance of `MicrosoftSecurityUpdatesClient`:

```csharp
using var client = new MicrosoftSecurityUpdatesClient();
```

3. Use the client to get information about security updates:

```csharp
// Get all updates
var updates = await client.GetUpdatesAsync();
// Get all updates by year or month
var updates2022 = await client.GetUpdatesAsync("2022");
var updates2022Dec = await client.GetUpdatesAsync("2022-Dec");
// Get CVRF by month
var cvrf2022Dec = await client.GetCvrfByIdAsync("2022-Dec");
```

## License

All packages in this repository are licensed under [the MIT license](https://opensource.org/licenses/MIT).

[1]: https://api.msrc.microsoft.com/cvrf/v2.0/swagger/index
