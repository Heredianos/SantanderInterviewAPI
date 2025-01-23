using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class HackerNewsController : ControllerBase
{
    private readonly HackerNewsService _hackerNewsService;

    public HackerNewsController(HackerNewsService hackerNewsService)
    {
        _hackerNewsService = hackerNewsService;
    }

[HttpGet("beststories")]
    public async Task<IActionResult> GetBestStories([FromQuery] int n = 10)
    {

        if (n <= 0)
            return BadRequest("The value of 'n' must be greater than 0.");
        var storyIds = await _hackerNewsService.GetBestStoryIdsAsync();
        if (storyIds == null || !storyIds.Any())
            return NotFound("No stories found.");
        var tasks = storyIds.Take(n).Select(id => _hackerNewsService.GetStoryDetailAsync(id));
        var stories = await Task.WhenAll(tasks);

        return Ok(stories.OrderByDescending(s => s.Score).Select(s => new
        {
            title = s.Title,
            uri = s.Url,
            postedBy = s.By,
            time = DateTimeOffset.FromUnixTimeSeconds(s.Time).ToString("o"),
            score = s.Score,
            commentCount = s.Descendants
        }));
    }
}
