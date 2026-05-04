using GitHubUserActivity.Models.Common;
using Newtonsoft.Json;

namespace GitHubUserActivity.Models.Payloads.Push;

public class PushCommit
{
    [JsonProperty("sha")]
    public string? Sha { get; set; }

    [JsonProperty("message")]
    public string? Message { get; set; }

    [JsonProperty("author")]
    public CommitAuthor? Author { get; set; }

    [JsonProperty("url")]
    public string? Url { get; set; }

    [JsonProperty("distinct")]
    public bool Distinct { get; set; }
}
