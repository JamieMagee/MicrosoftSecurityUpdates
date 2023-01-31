namespace JamieMagee.MicrosoftSecurityUpdates.Client.Test;

using FluentAssertions;

public class MicrosoftSecurityUpdatesClientTest
{
    private static readonly MicrosoftSecurityUpdatesClient client = new();

    [Fact]
    public async Task GetUpdatesAsync()
    {
        var updates = await client.GetUpdatesAsync();
        updates.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetUpdatesByKeyAsync()
    {
        var updates = await client.GetUpdateByIdAsync("2022");
        updates.Should().HaveCount(12);
    }

    [Fact]
    public async Task GetCvrfByIdAsync()
    {
        var updates = await client.GetCvrfByIdAsync("2022-Dec");
        updates.Should().NotBeNull();
    }
}
