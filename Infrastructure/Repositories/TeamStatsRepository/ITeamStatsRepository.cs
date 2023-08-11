using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;

namespace Infrastructure.Repositories.TeamStatsRepository
{
    public interface ITeamStatsRepository : IRepository<TeamStats>
    {
        Task<TeamStats> GetByMatchAndTeam(Guid matchId, Guid teamId);
        Task<IEnumerable<TeamStats>> GetByMatchId(Guid id);
        Task<IEnumerable<TeamStats>> GetByTeamId(Guid id);
    }
}
