using Newtonsoft.Json;

namespace GitHubUserActivity.Models.Payloads.Releases;

public class ReleaseDetails
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("tag_name")]
    public string? TagName { get; set; }

    [JsonProperty("target_commitish")]
    public string? TargetCommitish { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("body")]
    public string? Body { get; set; }

    [JsonProperty("draft")]
    public bool Draft { get; set; }

    [JsonProperty("prerelease")]
    public bool Prerelease { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("published_at")]
    public DateTime? PublishedAt { get; set; }

    [JsonProperty("url")]
    public string? Url { get; set; }

    [JsonProperty("html_url")]
    public string? HtmlUrl { get; set; }
}
