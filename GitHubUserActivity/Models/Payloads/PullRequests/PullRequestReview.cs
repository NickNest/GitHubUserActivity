using GitHubUserActivity.Models.Common;
using Newtonsoft.Json;

namespace GitHubUserActivity.Models.Payloads.PullRequests;

public class PullRequestReview
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("body")]
    public string? Body { get; set; }

    [JsonProperty("state")]
    public string? State { get; set; }

    [JsonProperty("user")]
    public UserRef? User { get; set; }

    [JsonProperty("commit_id")]
    public string? CommitId { get; set; }

    [JsonProperty("submitted_at")]
    public DateTime? SubmittedAt { get; set; }
}
