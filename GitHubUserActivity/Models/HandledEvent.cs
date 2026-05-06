using GitHubUserActivity.Models.Root;

namespace GitHubUserActivity.Models;

public class HandledEvent
{
    public GitHubEvent? GitHubEvent { get; set; }
    public int Count { get; set; }
}