using Newtonsoft.Json;

namespace GitHubUserActivity.Models.Common;

public class LabelInfo
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("color")]
    public string? Color { get; set; }
}
