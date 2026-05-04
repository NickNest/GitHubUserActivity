using Newtonsoft.Json;

namespace GitHubUserActivity.Models.Common;

public class UserRef
{
    [JsonProperty("login")]
    public string? Login { get; set; }

    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("avatar_url")]
    public string? AvatarUrl { get; set; }

    [JsonProperty("url")]
    public string? Url { get; set; }
}
