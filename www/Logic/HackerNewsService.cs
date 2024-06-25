using CapitoleSantander.Logic.Dtos;
using System.Text.Json;

namespace CapitoleSantander.Domain.Logic;

public class HackerNewsService : IHackerNewsService
{
    private readonly HttpClient _httpClient;

    public HackerNewsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    private async Task<List<int>> GetBestStoryIdsAsync(int count, CancellationToken cancellationToken)
    {
        var storiesUri = "https://hacker-news.firebaseio.com/v0/beststories.json";
        var response = await _httpClient.GetAsync(storiesUri);
        if (response.IsSuccessStatusCode)
        {
            List<int> storyIds = JsonSerializer.Deserialize<List<int>>(await response.Content.ReadAsStringAsync());
            return storyIds.Take(count).ToList();
        }
        throw new Exception("Failed to retrieve top stories");
    }

    private async Task<HackerStory> GetStoryDetailsAsync(int storyId, CancellationToken cancellationToken)
    {
        var storyUri = $"https://hacker-news.firebaseio.com/v0/item/{storyId}.json";
        var response = await _httpClient.GetAsync(storyUri);

        if (response.IsSuccessStatusCode)
        {
            return JsonSerializer.Deserialize<HackerStory>(await response.Content.ReadAsStringAsync());
        }

        throw new Exception($"Failed to retrieve story details for id: {storyId}");
    }

    public async Task<IEnumerable<HackerStory>> GetBestStoryDetails(int count, CancellationToken cancellationToken)
    {
        List<int> bestStoriesId = await GetBestStoryIdsAsync(count, cancellationToken);
        int batchSize = 100;
        int numberOfBatches = (int)Math.Ceiling((double)bestStoriesId.Count / batchSize);

        var tasks = new List<Task<HackerStory>>();

        for (int i = 0; i < numberOfBatches; i++)
        {
            var currentIds = bestStoriesId.Skip(i * batchSize).Take(batchSize);

            var result = currentIds.Select(async id => await GetStoryDetailsAsync(id, cancellationToken));
        }
        return await Task.WhenAll(tasks);
    }
}
