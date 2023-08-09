using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;

namespace Infrastructure.Repositories.PlayerStatsRepository
{
    public interface IPlayerStatsRepository : IRepository<PlayerStats>
    {
        Task<IEnumerable<PlayerStats>> GetByMatchId(Guid id);
        Task<IEnumerable<PlayerStats>> GetByPlayerId(Guid id);
    }
}
