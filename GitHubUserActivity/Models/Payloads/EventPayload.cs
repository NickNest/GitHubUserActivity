using GitHubUserActivity.Models.Common;
using GitHubUserActivity.Models.Payloads.Comments;
using GitHubUserActivity.Models.Payloads.Discussions;
using GitHubUserActivity.Models.Payloads.Forks;
using GitHubUserActivity.Models.Payloads.Issues;
using GitHubUserActivity.Models.Payloads.PullRequests;
using GitHubUserActivity.Models.Payloads.Push;
using GitHubUserActivity.Models.Payloads.Releases;
using Newtonsoft.Json;

namespace GitHubUserActivity.Models.Payloads;

public class EventPayload
{
    [JsonProperty("action")]
    public string? Action { get; set; }

    [JsonProperty("comment")]
    public CommentDetails? Comment { get; set; }

    [JsonProperty("ref")]
    public string? Ref { get; set; }

    [JsonProperty("ref_type")]
    public string? RefType { get; set; }

    [JsonProperty("master_branch")]
    public string? MasterBranch { get; set; }

    [JsonProperty("description")]
    public string? Description { get; set; }

    [JsonProperty("pusher_type")]
    public string? PusherType { get; set; }

    [JsonProperty("full_ref")]
    public string? FullRef { get; set; }

    [JsonProperty("discussion")]
    public DiscussionDetails? Discussion { get; set; }

    [JsonProperty("forkee")]
    public ForkeeDetails? Forkee { get; set; }

    [JsonProperty("pages")]
    public List<PageInfo>? Pages { get; set; }

    [JsonProperty("issue")]
    public IssueDetails? Issue { get; set; }

    [JsonProperty("assignee")]
    public UserRef? Assignee { get; set; }

    [JsonProperty("labels")]
    public List<LabelInfo>? Labels { get; set; }

    [JsonProperty("member")]
    public UserRef? Member { get; set; }

    [JsonProperty("number")]
    public int? Number { get; set; }

    [JsonProperty("pull_request")]
    public PullRequestDetails? PullRequest { get; set; }

    [JsonProperty("review")]
    public PullRequestReview? Review { get; set; }

    [JsonProperty("repository_id")]
    public long? RepositoryId { get; set; }

    [JsonProperty("push_id")]
    public long? PushId { get; set; }

    [JsonProperty("head")]
    public string? Head { get; set; }

    [JsonProperty("before")]
    public string? Before { get; set; }

    [JsonProperty("commits")]
    public List<PushCommit>? Commits { get; set; }

    [JsonProperty("release")]
    public ReleaseDetails? Release { get; set; }
}
