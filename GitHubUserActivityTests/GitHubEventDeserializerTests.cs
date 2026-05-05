using GitHubUserActivity.Models.Root;
using Newtonsoft.Json;

namespace GitHubUserActivityTests;

[TestFixture]
public class GitHubEventDeserializerTests
{
    private static string TestDataPath =>
        Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "TestData.json");

    [Test]
    public void DeserializeEvents_WithValidJson_ReturnsEvents()
    {
        var json = File.ReadAllText(TestDataPath);

        var result = GitHubEventDeserializer.DeserializeEvents(json);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.GreaterThan(0));
    }

    [Test]
    public void DeserializeEvents_WithEmptyArray_ReturnsEmptyList()
    {
        var result = GitHubEventDeserializer.DeserializeEvents("[]");

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void DeserializeEvents_WithEmptyString_ReturnsEmptyList()
    {
        var result = GitHubEventDeserializer.DeserializeEvents(string.Empty);
        
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void DeserializeEvents_WithMalformedJson_ThrowsJsonException()
    {
        const string malformedJson = "[{";

        Assert.That(
            () => GitHubEventDeserializer.DeserializeEvents(malformedJson),
            Throws.TypeOf<JsonSerializationException>());
    }
}
