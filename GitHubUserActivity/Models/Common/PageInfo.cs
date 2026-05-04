using Newtonsoft.Json;

namespace GitHubUserActivity.Models.Common;

public class PageInfo
{
    [JsonProperty("page_name")]
    public string? PageName { get; set; }

    [JsonProperty("title")]
    public string? Title { get; set; }

    [JsonProperty("summary")]
    public string? Summary { get; set; }

    [JsonProperty("action")]
    public string? Action { get; set; }

    [JsonProperty("sha")]
    public string? Sha { get; set; }

    [JsonProperty("html_url")]
    public string? HtmlUrl { get; set; }
}
