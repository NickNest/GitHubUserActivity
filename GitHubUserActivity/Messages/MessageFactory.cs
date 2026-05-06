using GitHubUserActivity.Models;

namespace GitHubUserActivity.Messages;

public static class MessageFactory
{
    public static IEnumerable<string> GetMessages(IEnumerable<HandledEvent> events)
    {
        return events.Select(BuildMessageForEvent);
    }
    
    private static string BuildMessageForEvent(HandledEvent gitHubEvent)
    {
        if (gitHubEvent.GitHubEvent == null)
        {
            Console.WriteLine("Warning: GitHubEvent is null. Skipping this event.");
            return string.Empty;
        }
        
        var actor = gitHubEvent.GitHubEvent.Actor?.Login ?? "Someone";
        var repo = gitHubEvent.GitHubEvent.Repo?.Name ?? "unknown repository";
        var action = gitHubEvent.GitHubEvent.Payload?.Action;

        switch (gitHubEvent.GitHubEvent.Type)
        {
            case "PushEvent":
                return $"- pushed {gitHubEvent.Count} commit(s) to {repo}";
            case "PullRequestEvent":
                return $"- {action ?? "updated"} a pull request {gitHubEvent.Count} times in {repo}";
            case "PullRequestReviewEvent":
                return $"- {action ?? "reviewed"} a pull request {gitHubEvent.Count} times in {repo}";
            case "PullRequestReviewCommentEvent":
                return $"- {action ?? "left"} {gitHubEvent.Count} comment(s) on the pull request in {repo}";
            case "IssuesEvent":
                return $"- {action ?? "updated"} an issue {gitHubEvent.Count} times in {repo}";
            case "IssueCommentEvent":
                return $"- {action ?? "commented on"} an issue {gitHubEvent.Count} times in {repo}";
            case "WatchEvent":
                return $"- starred {repo} {gitHubEvent.Count} times";
            case "ForkEvent":
                return $"- forked {repo} {gitHubEvent.Count} times";
            case "CreateEvent":
                return $"- created {gitHubEvent.GitHubEvent.Payload?.RefType ?? "a reference"} {gitHubEvent.Count} times in {repo}".Trim();
            case "DeleteEvent":
                return $"- deleted {gitHubEvent.GitHubEvent.Payload?.RefType ?? "a reference"} {gitHubEvent.Count} times in {repo}".Trim();
            case "ReleaseEvent":
                return $"- {action ?? "published"} release {gitHubEvent.GitHubEvent.Payload?.Release?.TagName ?? string.Empty} {gitHubEvent.Count} times in {repo}".Trim();
            case "PublicEvent":
                return $"- made {repo} public";
            default:
                return $"- performed {gitHubEvent.GitHubEvent.Type ?? "an action"} {gitHubEvent.Count} times in {repo}";
        }
    }
}
