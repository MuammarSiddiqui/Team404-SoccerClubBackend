using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;

namespace Infrastructure.Repositories.PlayerAchievementRepository
{
    public interface IPlayerAchievementRepository : IRepository<PlayerAchievement>
    {
        Task<IEnumerable<PlayerAchievement>> GetByMatchId(Guid id);
        Task<IEnumerable<PlayerAchievement>> GetByPlayerId(Guid id);
    }
}
