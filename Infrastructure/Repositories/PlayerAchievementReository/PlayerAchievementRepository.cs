using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.PlayerAchievementRepository
{
    public class PlayerAchievementRepository : Repository<PlayerAchievement>, IPlayerAchievementRepository
    {
        public PlayerAchievementRepository(MyContext db) : base(db)
        {
        }

        public async Task<IEnumerable<PlayerAchievement>> GetByMatchId(Guid id)
        {
            return await DbSet.Where(x => x.MatchesId == id).ToListAsync();
        }

        public async Task<IEnumerable<PlayerAchievement>> GetByPlayerId(Guid id)
        {
            return await DbSet.Where(x => x.PlayerId == id).ToListAsync();
        }
    }
}
