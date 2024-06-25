using CapitoleSantander.Logic.Dtos;

namespace CapitoleSantander.Domain.Logic;

public interface IHackerNewsService
{
    Task<IEnumerable<HackerStory>> GetBestStoryDetails(int amount, CancellationToken cancellationToken);
}
