using GitHubUserActivity.Messages;
using GitHubUserActivity.Models;
using GitHubUserActivity.Models.Common;
using GitHubUserActivity.Models.Payloads;
using GitHubUserActivity.Models.Payloads.Releases;
using GitHubUserActivity.Models.Root;

namespace GitHubUserActivityTests;

[TestFixture]
public class MessageFactoryTests
{
    [Test]
    public void GetMessages_ForPushEvent_BuildsExpectedMessage()
    {
        var handledEvents = new[]
        {
            CreateHandledEvent("PushEvent", "octocat", "octo/repo", 3)
        };

        var messages = MessageFactory.GetMessages(handledEvents).ToList();

        Assert.That(messages, Is.EqualTo(new[] { "- pushed 3 commit(s) to octo/repo" }));
    }

    [Test]
    public void GetMessages_UsesFallbacks_WhenActorRepoAndActionAreMissing()
    {
        var handledEvents = new[]
        {
            new HandledEvent
            {
                GitHubEvent = new GitHubEvent
                {
                    Type = "PullRequestEvent",
                    Payload = new EventPayload()
                },
                Count = 2
            }
        };

        var messages = MessageFactory.GetMessages(handledEvents).ToList();

        Assert.That(messages, Is.EqualTo(new[] { "- updated a pull request 2 times in unknown repository" }));
    }

    [Test]
    public void GetMessages_ForCreateEventWithoutRef_ProducesTrimmedMessage()
    {
        var handledEvents = new[]
        {
            new HandledEvent
            {
                GitHubEvent = new GitHubEvent
                {
                    Type = "CreateEvent",
                    Actor = new Actor { Login = "octocat" },
                    Repo = new RepoInfo { Name = "octo/repo" },
                    Payload = new EventPayload()
                },
                Count = 1
            }
        };

        var message = MessageFactory.GetMessages(handledEvents).Single();

        Assert.That(message, Is.EqualTo("- created a reference 1 times in octo/repo"));
        Assert.That(message.StartsWith(" "), Is.False);
        Assert.That(message.EndsWith(" "), Is.False);
    }

    [Test]
    public void GetMessages_ForReleaseEvent_UsesTagNameAndFallbackAction()
    {
        var handledEvents = new[]
        {
            new HandledEvent
            {
                GitHubEvent = new GitHubEvent
                {
                    Type = "ReleaseEvent",
                    Actor = new Actor { Login = "octocat" },
                    Repo = new RepoInfo { Name = "octo/repo" },
                    Payload = new EventPayload
                    {
                        Release = new ReleaseDetails { TagName = "v1.2.3" }
                    }
                },
                Count = 4
            }
        };

        var message = MessageFactory.GetMessages(handledEvents).Single();

        Assert.That(message, Is.EqualTo("- published release v1.2.3 4 times in octo/repo"));
    }

    [Test]
    public void GetMessages_ForUnknownEventType_UsesDefaultTemplate()
    {
        var handledEvents = new[]
        {
            CreateHandledEvent("MysteryEvent", "octocat", "octo/repo", 7)
        };

        var message = MessageFactory.GetMessages(handledEvents).Single();

        Assert.That(message, Is.EqualTo("- performed MysteryEvent 7 times in octo/repo"));
    }

    [Test]
    public void GetMessages_WhenGitHubEventIsNull_ReturnsEmptyString()
    {
        var handledEvents = new[]
        {
            new HandledEvent
            {
                GitHubEvent = null,
                Count = 1
            }
        };

        var message = MessageFactory.GetMessages(handledEvents).Single();

        Assert.That(message, Is.EqualTo(string.Empty));
    }

    private static HandledEvent CreateHandledEvent(string type, string actor, string repo, int count)
    {
        return new HandledEvent
        {
            GitHubEvent = new GitHubEvent
            {
                Type = type,
                Actor = new Actor { Login = actor },
                Repo = new RepoInfo { Name = repo }
            },
            Count = count
        };
    }
}
