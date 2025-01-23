using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json.Serialization;

public class HackerNewsService {

    private readonly HttpClient _httpClient;
    private readonly IMemoryCache _cache;

    public HackerNewsService(HttpClient httpClient, IMemoryCache cache){
        _httpClient = httpClient;
        _cache = cache;
    }


    public async Task<IEnumerable<int>> GetBestStoryIdsAsync(){
    const string cacheKey = "BestStoryIds";
    if (!_cache.TryGetValue(cacheKey, out IEnumerable<int> bestStoryIds)){
        var response = await _httpClient.GetStringAsync("https://hacker-news.firebaseio.com/v0/beststories.json");
        try{
            bestStoryIds = JsonSerializer.Deserialize<IEnumerable<int>>(response) ?? new List<int>();
            _cache.Set(cacheKey, bestStoryIds, TimeSpan.FromMinutes(3));
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Error deserializando JSON: {ex.Message}");
            return Enumerable.Empty<int>(); // Devuelve una lista vacía en caso de error
        }
    }

    // Retorna los IDs de la cache o los recién obtenidos
    return bestStoryIds ?? Enumerable.Empty<int>();
}

    
    public async Task<HackerNewsStory> GetStoryDetailAsync(int id)
{
    string cacheKey = $"StoryDetail_{id}";

        if (!_cache.TryGetValue(cacheKey, out HackerNewsStory story))
        {
            var response = await _httpClient.GetStringAsync($"https://hacker-news.firebaseio.com/v0/item/{id}.json");
            //Console.WriteLine($"Respuesta de la API para ID {id}: {response}");
            try
            {
                story = JsonSerializer.Deserialize<HackerNewsStory>(response) ?? new HackerNewsStory();

                _cache.Set(cacheKey, story, TimeSpan.FromMinutes(5));
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error deserializando JSON: {ex.Message}");
                return new HackerNewsStory();
            }
        }
        return story;
}


public class HackerNewsStory
{
[JsonPropertyName("by")]
    public string? By { get; set; }

    [JsonPropertyName("descendants")]
    public int Descendants { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("kids")]
    public List<int>? Kids { get; set; }

    [JsonPropertyName("score")]
    public int Score { get; set; }

    [JsonPropertyName("time")]
    public long Time { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}
}
