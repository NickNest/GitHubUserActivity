using Newtonsoft.Json;

namespace GitHubUserActivity.Models.Common;

public class RepoInfo
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("url")]
    public string? Url { get; set; }
}
