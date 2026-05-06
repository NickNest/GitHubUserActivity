using GitHubUserActivity.Models;
using GitHubUserActivity.Models.Root;

namespace GitHubUserActivity;

public static class EventsOrganizer
{
    public static List<HandledEvent> OrganizeEvents(List<GitHubEvent> events)
    {
        var countDict = new Dictionary<string, int>();
        var eventsHashSet = new HashSet<string>();
        var result = new List<HandledEvent>();
        
        foreach (var @event in events)
        {
            var name = @event.GetEventName();
            
            if (eventsHashSet.Add(name))
            {
                result.Add(new HandledEvent()
                {
                    GitHubEvent = @event,
                    Count = 0
                });
            }

            if (!countDict.TryAdd(name, 1))
            {
                countDict[name]++;
            }
        }

        foreach (var @event in result)
        {
            if (@event.GitHubEvent != null)
            {
                @event.Count = countDict[@event.GitHubEvent.GetEventName()];
            }
        }
        
        return result;
    }
}