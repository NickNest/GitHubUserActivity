using GitHubUserActivity.RequestService;

namespace GitHubUserActivityTests;

[TestFixture]
public class GitHubUserActivityRequesterTests
{
    [Test]
    public async Task GetUserActivityAsync_WhenResponseIsSuccessful_ReturnsResponseBody()
    {
        var handler = new StubHttpMessageHandler((request, _) =>
        {
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent("[{\"id\":\"1\"}]")
            };
            return Task.FromResult(response);
        });

        var requester = CreateRequester(handler);

        var result = await requester.GetUserActivityAsync("octocat");

        Assert.That(result, Is.EqualTo("[{\"id\":\"1\"}]"));
    }

    [Test]
    public async Task GetUserActivityAsync_UsesExpectedRequestUrl()
    {
        Uri? capturedUri = null;
        var handler = new StubHttpMessageHandler((request, _) =>
        {
            capturedUri = request.RequestUri;
            return Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent("[]")
            });
        });

        var requester = CreateRequester(handler);

        _ = await requester.GetUserActivityAsync("octocat");

        Assert.That(capturedUri, Is.Not.Null);
        Assert.That(capturedUri!.ToString(), Is.EqualTo("https://api.github.com/users/octocat/events"));
    }

    [Test]
    public void GetUserActivityAsync_WhenCanceled_ReturnsCanceledTask()
    {
        var handler = new StubHttpMessageHandler((_, cancellationToken) =>
            Task.FromCanceled<HttpResponseMessage>(cancellationToken));

        var requester = CreateRequester(handler);
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        Assert.That(
            async () => await requester.GetUserActivityAsync("octocat", cts.Token),
            Throws.TypeOf<TaskCanceledException>());
    }

    private static GitHubUserActivityRequester CreateRequester(HttpMessageHandler handler)
    {
        var client = new HttpClient(handler);
        var factory = new StubHttpClientFactory(client);
        return new GitHubUserActivityRequester(factory);
    }

    private sealed class StubHttpClientFactory(HttpClient httpClient) : IHttpClientFactory
    {
        public HttpClient CreateClient(string name) => httpClient;
    }

    private sealed class StubHttpMessageHandler(
        Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> handlerFunc) : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            return handlerFunc(request, cancellationToken);
        }
    }
}
