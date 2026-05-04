using GitHubUserActivity.Models.Common;
using Newtonsoft.Json;

namespace GitHubUserActivity.Models.Payloads.Forks;

public class ForkeeDetails
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("full_name")]
    public string? FullName { get; set; }

    [JsonProperty("owner")]
    public UserRef? Owner { get; set; }

    [JsonProperty("private")]
    public bool Private { get; set; }

    [JsonProperty("description")]
    public string? Description { get; set; }

    [JsonProperty("fork")]
    public bool Fork { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [JsonProperty("pushed_at")]
    public DateTime? PushedAt { get; set; }

    [JsonProperty("homepage")]
    public string? Homepage { get; set; }
}
