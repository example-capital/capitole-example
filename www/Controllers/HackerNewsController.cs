using CapitoleSantander.Domain.Logic;
using CapitoleSantander.Logic.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CapitoleSantander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HackerNewsController : ControllerBase
    {
        private readonly IHackerNewsService _hackerNewsService;

        public HackerNewsController(IHackerNewsService hackerNewsService)
        {
            _hackerNewsService = hackerNewsService;
        }

        [HttpGet("beststories/{n:int}")]
        public async Task<List<HackerStory>> GetBestStories(CancellationToken cancellationToken, int n = 10)
        {
            var result = await _hackerNewsService.GetBestStoryDetails(n, cancellationToken);

            return result.OrderByDescending(q => q.Score).ToList();
        }
    }
}
