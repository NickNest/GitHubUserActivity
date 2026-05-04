using GitHubUserActivity.Models.Common;
using Newtonsoft.Json;

namespace GitHubUserActivity.Models.Payloads.PullRequests;

public class PullRequestDetails
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("number")]
    public int Number { get; set; }

    [JsonProperty("title")]
    public string? Title { get; set; }

    [JsonProperty("body")]
    public string? Body { get; set; }

    [JsonProperty("user")]
    public UserRef? User { get; set; }

    [JsonProperty("state")]
    public string? State { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}
