using Newtonsoft.Json;

namespace GitHubUserActivity.Models.Root;

public static class GitHubEventDeserializer
{
    public static List<GitHubEvent> DeserializeEvents(string json)
    {
        return JsonConvert.DeserializeObject<List<GitHubEvent>>(json) ?? new List<GitHubEvent>();
    }
}
