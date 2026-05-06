using GitHubUserActivity;
using GitHubUserActivity.Models.Common;
using GitHubUserActivity.Models.Root;

namespace GitHubUserActivityTests;

[TestFixture]
public class EventsOrganizerTests
{
    [Test]
    public void OrganizeEvents_GroupsByEventName_AndCountsOccurrences()
    {
        var events = new List<GitHubEvent>
        {
            CreateEvent("PushEvent", "octo/repo-1", "1"),
            CreateEvent("PushEvent", "octo/repo-1", "2"),
            CreateEvent("WatchEvent", "octo/repo-2", "3"),
            CreateEvent("PushEvent", "octo/repo-1", "4"),
            CreateEvent("WatchEvent", "octo/repo-2", "5")
        };

        var result = EventsOrganizer.OrganizeEvents(events);

        Assert.That(result, Has.Count.EqualTo(2));
        Assert.That(result.Single(e => e.GitHubEvent!.GetEventName() == "PushEvent octo/repo-1").Count, Is.EqualTo(3));
        Assert.That(result.Single(e => e.GitHubEvent!.GetEventName() == "WatchEvent octo/repo-2").Count, Is.EqualTo(2));
    }

    [Test]
    public void OrganizeEvents_KeepsFirstEventInstanceForEachGroup()
    {
        var firstPush = CreateEvent("PushEvent", "octo/repo-1", "1");
        var secondPush = CreateEvent("PushEvent", "octo/repo-1", "2");

        var result = EventsOrganizer.OrganizeEvents(new List<GitHubEvent> { firstPush, secondPush });

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.That(result[0].GitHubEvent, Is.SameAs(firstPush));
        Assert.That(result[0].GitHubEvent, Is.Not.SameAs(secondPush));
        Assert.That(result[0].Count, Is.EqualTo(2));
    }

    [Test]
    public void OrganizeEvents_WithEmptyInput_ReturnsEmptyList()
    {
        var result = EventsOrganizer.OrganizeEvents(new List<GitHubEvent>());

        Assert.That(result, Is.Empty);
    }

    private static GitHubEvent CreateEvent(string type, string repoName, string id)
    {
        return new GitHubEvent
        {
            Id = id,
            Type = type,
            Repo = new RepoInfo { Name = repoName }
        };
    }
}
