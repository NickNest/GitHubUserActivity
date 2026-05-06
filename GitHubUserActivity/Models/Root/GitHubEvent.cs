using GitHubUserActivity.Models.Common;
using GitHubUserActivity.Models.Payloads;
using Newtonsoft.Json;

namespace GitHubUserActivity.Models.Root;

public class GitHubEvent
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("type")]
    public string? Type { get; set; }

    [JsonProperty("actor")]
    public Actor? Actor { get; set; }

    [JsonProperty("repo")]
    public RepoInfo? Repo { get; set; }

    [JsonProperty("payload")]
    public EventPayload? Payload { get; set; }

    [JsonProperty("public")]
    public bool Public { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("org")]
    public OrgInfo? Org { get; set; }
}

public static class GitHubEventExtensions
{
    public static string GetEventName(this GitHubEvent gitHubEvent)
    {
        var eventType = gitHubEvent.Type ?? "unknown";
        var repo = gitHubEvent.Repo?.Name ?? "unknown repo";
        return string.Concat(eventType, " ", repo);
    }
}
