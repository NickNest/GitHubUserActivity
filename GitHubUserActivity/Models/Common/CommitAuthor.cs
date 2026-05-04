using Newtonsoft.Json;

namespace GitHubUserActivity.Models.Common;

public class CommitAuthor
{
    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("email")]
    public string? Email { get; set; }
}
