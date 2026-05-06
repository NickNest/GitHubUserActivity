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
                return $"{actor} pushed {gitHubEvent.Count} commit(s) to {repo}";
            case "PullRequestEvent":
                return $"{actor} {action ?? "updated"} a pull request {gitHubEvent.Count} times in {repo}";
            case "PullRequestReviewEvent":
                return $"{actor} {action ?? "reviewed"} a pull request {gitHubEvent.Count} times in {repo}";
            case "PullRequestReviewCommentEvent":
                return $"{actor} {action ?? "left"} {gitHubEvent.Count} comment(s) on the pull request in {repo}";
            case "IssuesEvent":
                return $"{actor} {action ?? "updated"} an issue {gitHubEvent.Count} times in {repo}";
            case "IssueCommentEvent":
                return $"{actor} {action ?? "commented on"} an issue {gitHubEvent.Count} times in {repo}";
            case "WatchEvent":
                return $"{actor} starred {repo} {gitHubEvent.Count} times";
            case "ForkEvent":
                return $"{actor} forked {repo} {gitHubEvent.Count} times";
            case "CreateEvent":
                return $"{actor} created {gitHubEvent.GitHubEvent.Payload?.RefType ?? "a reference"} {gitHubEvent.GitHubEvent.Payload?.Ref ?? string.Empty} {gitHubEvent.Count} times in {repo}".Trim();
            case "DeleteEvent":
                return $"{actor} deleted {gitHubEvent.GitHubEvent.Payload?.RefType ?? "a reference"} {gitHubEvent.GitHubEvent.Payload?.Ref ?? string.Empty} {gitHubEvent.Count} times in {repo}".Trim();
            case "ReleaseEvent":
                return $"{actor} {action ?? "published"} release {gitHubEvent.GitHubEvent.Payload?.Release?.TagName ?? string.Empty} {gitHubEvent.Count} times in {repo}".Trim();
            case "PublicEvent":
                return $"{actor} made {repo} public";
            default:
                return $"{actor} performed {gitHubEvent.GitHubEvent.Type ?? "an action"} {gitHubEvent.Count} times in {repo}";
        }
    }
}
