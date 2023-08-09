using DomainLayer.Models;

namespace ApplicationLayer.Services.PlayerAchievementService
{
    public interface IPlayerAchievementService
    {
        Task<IEnumerable<PlayerAchievement>> GetAll();
        Task<PlayerAchievement> GetById(Guid id);
        Task<PlayerAchievement> Add(PlayerAchievement PlayerAchievement);
        Task<PlayerAchievement> Update(PlayerAchievement PlayerAchievement);
        Task<PlayerAchievement> Remove(PlayerAchievement PlayerAchievement);
        Task<IEnumerable<PlayerAchievement>> GetByMatchId(Guid id);
        Task<IEnumerable<PlayerAchievement>> GetByPlayerId(Guid id);
    }
}
