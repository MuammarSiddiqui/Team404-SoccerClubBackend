using DomainLayer.Models;

namespace ApplicationLayer.Services.PlayerStatsService
{
    public interface IPlayerStatsService
    {
        Task<IEnumerable<PlayerStats>> GetAll();
        Task<PlayerStats> GetById(Guid id);
        Task<PlayerStats> Add(PlayerStats PlayerStats);
        Task<PlayerStats> Update(PlayerStats PlayerStats);
        Task<PlayerStats> Remove(PlayerStats PlayerStats);
        Task<IEnumerable<PlayerStats>> GetByMatchId(Guid id);
        Task<IEnumerable<PlayerStats>> GetByPlayerId(Guid id);
    }
}
