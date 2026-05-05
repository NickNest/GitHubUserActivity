namespace GitHubUserActivity.RequestService;

public class GitHubUserActivityRequester(IHttpClientFactory httpClientFactory) : IUserActivityRequester
{
    private const string BaseUrl = "https://api.github.com/users/{0}/events";

    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("GitHubUserActivityRequester");

    public async Task<string> GetUserActivityAsync(string username, CancellationToken cancellationToken = default)
    {
        if (_httpClient.DefaultRequestHeaders.UserAgent.Count == 0)
        {
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("GitHubUserActivityApp/1.0");
        }

        using var response = await _httpClient.GetAsync(string.Format(BaseUrl, username), cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync(cancellationToken);
    }
}
