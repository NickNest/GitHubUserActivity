using GitHubUserActivity;
using GitHubUserActivity.Messages;
using GitHubUserActivity.Models.Root;
using GitHubUserActivity.RequestService;
using Microsoft.Extensions.DependencyInjection;

if (args.Length == 0 || string.IsNullOrWhiteSpace(args[0]))
{
    Console.WriteLine("Usage: GitHubUserActivity <github-username>");
    return;
}

var services = new ServiceCollection();

services.AddHttpClient();
services.AddSingleton<IUserActivityRequester, GitHubUserActivityRequester>();

await using var provider = services.BuildServiceProvider();
        
var requester = provider.GetRequiredService<IUserActivityRequester>();

try
{
    var json = await requester.GetUserActivityAsync(args[0]);

    var rawEvents = GitHubEventDeserializer.DeserializeEvents(json);

    rawEvents.Sort(((@event1, @event2) => string.Compare(@event2.Type!, @event1.Type, StringComparison.Ordinal)));
     
    var events = EventsOrganizer.OrganizeEvents(rawEvents);
    
    foreach (var message in MessageFactory.GetMessages(events))
    {
        Console.WriteLine(message);
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}