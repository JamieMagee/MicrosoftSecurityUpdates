namespace JamieMagee.MicrosoftSecurityUpdates.Client.Test;

using FluentAssertions;

public class MicrosoftSecurityUpdatesClientTest
{
    private static readonly MicrosoftSecurityUpdatesClient Client = new();

    private static readonly string[] ValidUpdateYears = ["2022", "2023", "2024", "2025"];

    public static readonly TheoryData<string> ValidUpdateYearsData = [.. ValidUpdateYears];

    public static readonly MatrixTheoryData<string, string> ValidCvrfIdsData = new(
        ValidUpdateYears,
        ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"]);

    [Fact]
    public async Task GetUpdatesAsync()
    {
        var updates = await Client.GetUpdatesAsync(TestContext.Current.CancellationToken);
        updates.Should().NotBeEmpty();
    }

    [Theory]
    [MemberData(nameof(ValidUpdateYearsData))]
    public async Task GetUpdatesByKeyAsync(string id)
    {
        var updates = await Client.GetUpdateByIdAsync(id, TestContext.Current.CancellationToken);
        updates.Should().NotBeEmpty();
    }

    [Theory]
    [MemberData(nameof(ValidCvrfIdsData))]
    public async Task GetUpdatesByCvrfIdAsync(string year, string month)
    {
        var cvrfId = $"{year}-{month}";
        var updates = await Client.GetUpdateByIdAsync(cvrfId, TestContext.Current.CancellationToken);
        updates.Should().NotBeEmpty();
    }
}
