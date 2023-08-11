using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;

namespace Infrastructure.Repositories.PlayerStatsRepository
{
    public interface IPlayerStatsRepository : IRepository<PlayerStats>
    {
        Task<PlayerStats> GetByPlayerId(Guid id);
    }
}
