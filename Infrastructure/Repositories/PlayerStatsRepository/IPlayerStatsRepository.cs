using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;

namespace Infrastructure.Repositories.PlayerStatsRepository
{
    public interface IPlayerStatsRepository : IRepository<PlayerStats>
    {
        Task<IEnumerable<PlayerStats>> GetAllWithRelationship();
        Task<PlayerStats> GetByPlayerId(Guid id);
    }
}
