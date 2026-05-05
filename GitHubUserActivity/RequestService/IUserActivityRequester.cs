namespace GitHubUserActivity.RequestService;

public interface IUserActivityRequester
{
    Task<string> GetUserActivityAsync(string username, CancellationToken cancellationToken = default);
}