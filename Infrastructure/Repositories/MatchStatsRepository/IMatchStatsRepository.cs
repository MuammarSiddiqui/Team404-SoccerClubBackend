using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;

namespace Infrastructure.Repositories.MatchStatsRepository
{
    public interface IMatchStatsRepository : IRepository<MatchStats>
    {
        Task<IEnumerable<MatchStats>> GetByMatchId(Guid id);
    }
}
