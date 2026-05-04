using GitHubUserActivity.Models.Common;
using Newtonsoft.Json;

namespace GitHubUserActivity.Models.Payloads.Comments;

public class CommentDetails
{
    [JsonProperty("url")]
    public string? Url { get; set; }

    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("body")]
    public string? Body { get; set; }

    [JsonProperty("user")]
    public UserRef? User { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [JsonProperty("commit_id")]
    public string? CommitId { get; set; }

    [JsonProperty("path")]
    public string? Path { get; set; }

    [JsonProperty("position")]
    public int? Position { get; set; }
}
