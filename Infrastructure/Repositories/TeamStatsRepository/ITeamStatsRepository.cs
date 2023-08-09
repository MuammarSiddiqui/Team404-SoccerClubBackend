using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;

namespace Infrastructure.Repositories.TeamStatsRepository
{
    public interface ITeamStatsRepository : IRepository<TeamStats>
    {
        Task<IEnumerable<TeamStats>> GetByMatchId(Guid id);
        Task<IEnumerable<TeamStats>> GetByTeamId(Guid id);
    }
}
