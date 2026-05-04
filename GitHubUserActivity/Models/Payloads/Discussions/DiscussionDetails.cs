using GitHubUserActivity.Models.Common;
using Newtonsoft.Json;

namespace GitHubUserActivity.Models.Payloads.Discussions;

public class DiscussionDetails
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("node_id")]
    public string? NodeId { get; set; }

    [JsonProperty("title")]
    public string? Title { get; set; }

    [JsonProperty("body")]
    public string? Body { get; set; }

    [JsonProperty("user")]
    public UserRef? User { get; set; }

    [JsonProperty("state")]
    public string? State { get; set; }

    [JsonProperty("locked")]
    public bool Locked { get; set; }

    [JsonProperty("comments")]
    public int Comments { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}
