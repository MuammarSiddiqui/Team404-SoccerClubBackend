using DomainLayer.Models;

namespace ApplicationLayer.Services.TeamStatsService
{
    public interface ITeamStatsService
    {
        Task<IEnumerable<TeamStats>> GetAll();
        Task<IEnumerable<TeamStats>> GetAllWithRelationShip();
        Task<TeamStats> GetById(Guid id);
        Task<TeamStats> Add(TeamStats TeamStats);
        Task<TeamStats> Update(TeamStats TeamStats);
        Task<TeamStats> Remove(TeamStats TeamStats);
        Task<IEnumerable<TeamStats>> GetByTeamId(Guid id);
        Task<IEnumerable<TeamStats>> GetByMatchId(Guid id);
        Task<TeamStats> GetByMatchAndTeam(Guid matchId, Guid teamId);
    }
}
