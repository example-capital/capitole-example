using System.Text.Json.Serialization;

namespace CapitoleSantander.Logic.Dtos;

public class HackerStory
{
    [JsonPropertyName("by")]
    public string By { get; init; } = default!;

    [JsonPropertyName("descendants")]
    public int Descendants { get; init; }

    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("kids")]
    public List<int> Kids { get; init; } = new List<int>();

    [JsonPropertyName("score")]
    public int Score { get; init; }

    [JsonPropertyName("time")]
    public int Time { get; init; }

    [JsonPropertyName("title")]
    public string Title { get; init; } = default!;

    [JsonPropertyName("type")]
    public string Type { get; init; } = default!;

    [JsonPropertyName("url")]
    public string Url { get; init; } = default!;
}

