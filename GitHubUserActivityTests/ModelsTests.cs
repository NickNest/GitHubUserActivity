using GitHubUserActivity.Models.Root;

namespace GitHubUserActivityTests;

[TestFixture]
public class ModelsTests
{
    private List<GitHubEvent> _events = null!;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "TestData.json");
        var json = File.ReadAllText(path);
        _events = GitHubEventDeserializer.DeserializeEvents(json);
    }

    [Test]
    public void GitHubEvent_MapsRootFields()
    {
        var watchEvent = _events.Single(e => e.Type == "WatchEvent");

        Assert.Multiple(() =>
        {
            Assert.That(watchEvent.Id, Is.EqualTo("12345"));
            Assert.That(watchEvent.Public, Is.False);
            Assert.That(watchEvent.CreatedAt, Is.EqualTo(new DateTime(2011, 9, 6, 17, 26, 27, DateTimeKind.Utc)));
            Assert.That(watchEvent.Actor, Is.Not.Null);
            Assert.That(watchEvent.Repo, Is.Not.Null);
            Assert.That(watchEvent.Org, Is.Not.Null);
        });
    }

    [Test]
    public void CommonModels_MapExpectedFields()
    {
        var watchEvent = _events.Single(e => e.Type == "WatchEvent");

        Assert.Multiple(() =>
        {
            Assert.That(watchEvent.Actor!.Id, Is.EqualTo(1));
            Assert.That(watchEvent.Actor.Login, Is.EqualTo("octocat"));
            Assert.That(watchEvent.Actor.DisplayLogin, Is.EqualTo("octocat"));
            Assert.That(watchEvent.Repo!.Id, Is.EqualTo(3));
            Assert.That(watchEvent.Repo.Name, Is.EqualTo("octocat/Hello-World"));
            Assert.That(watchEvent.Org!.Login, Is.EqualTo("github"));
        });
    }

    [Test]
    public void PushEvent_MapsPushModels()
    {
        var pushEvent = _events.Single(e => e.Type == "PushEvent");
        var commit = pushEvent.Payload!.Commits!.Single();

        Assert.Multiple(() =>
        {
            Assert.That(pushEvent.Payload.RepositoryId, Is.EqualTo(3));
            Assert.That(pushEvent.Payload.PushId, Is.EqualTo(30425949));
            Assert.That(pushEvent.Payload.Ref, Is.EqualTo("refs/heads/main"));
            Assert.That(commit.Sha, Is.EqualTo("abc123def456"));
            Assert.That(commit.Author!.Name, Is.EqualTo("Octocat"));
            Assert.That(commit.Author.Email, Is.EqualTo("octocat@github.com"));
            Assert.That(commit.Distinct, Is.True);
        });
    }

    [Test]
    public void PullRequestReviewCommentEvent_MapsCommentSpecificFields()
    {
        var prCommentEvent = _events.Single(e => e.Type == "PullRequestReviewCommentEvent");
        var comment = prCommentEvent.Payload!.Comment!;

        Assert.Multiple(() =>
        {
            Assert.That(prCommentEvent.Payload.PullRequest, Is.Not.Null);
            Assert.That(comment.CommitId, Is.EqualTo("abc123def456"));
            Assert.That(comment.Path, Is.EqualTo("file.js"));
            Assert.That(comment.Position, Is.EqualTo(4));
        });
    }

    [Test]
    public void DiscussionAndForkAndReleaseEvents_MapNestedModels()
    {
        var discussionEvent = _events.Single(e => e.Type == "DiscussionEvent");
        var forkEvent = _events.Single(e => e.Type == "ForkEvent");
        var releaseEvent = _events.Single(e => e.Type == "ReleaseEvent");

        Assert.Multiple(() =>
        {
            Assert.That(discussionEvent.Payload!.Discussion!.Title, Is.EqualTo("Welcome to our new Discussion!"));
            Assert.That(discussionEvent.Payload.Discussion.Locked, Is.False);
            Assert.That(forkEvent.Payload!.Forkee!.FullName, Is.EqualTo("octocat/Hello-World"));
            Assert.That(forkEvent.Payload.Forkee.Owner!.Login, Is.EqualTo("octocat"));
            Assert.That(releaseEvent.Payload!.Release!.TagName, Is.EqualTo("v1.0.0"));
            Assert.That(releaseEvent.Payload.Release.Prerelease, Is.False);
        });
    }

    [Test]
    public void IssueAndLabelAndPageModels_MapExpectedFields()
    {
        var issuesEvent = _events.Single(e => e.Type == "IssuesEvent");
        var gollumEvent = _events.Single(e => e.Type == "GollumEvent");

        Assert.Multiple(() =>
        {
            Assert.That(issuesEvent.Payload!.Issue!.Number, Is.EqualTo(1347));
            Assert.That(issuesEvent.Payload.Assignee!.Login, Is.EqualTo("octocat"));
            Assert.That(issuesEvent.Payload.Labels!.Single().Name, Is.EqualTo("bug"));
            Assert.That(gollumEvent.Payload!.Pages!.Single().PageName, Is.EqualTo("Home"));
            Assert.That(gollumEvent.Payload.Pages!.Single().Action, Is.EqualTo("edited"));
        });
    }
}
