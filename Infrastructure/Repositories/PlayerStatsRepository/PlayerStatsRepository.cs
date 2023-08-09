using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.PlayerStatsRepository
{
    public class PlayerStatsRepository : Repository<PlayerStats>, IPlayerStatsRepository
    {
        public PlayerStatsRepository(MyContext db) : base(db)
        {
        }

        public async Task<IEnumerable<PlayerStats>> GetByMatchId(Guid id)
        {
            return await DbSet.Where(x => x.MatchesId == id).ToListAsync();
        }

        public async Task<IEnumerable<PlayerStats>> GetByPlayerId(Guid id)
        {
            return await DbSet.Where(x => x.PlayerId == id).ToListAsync();
        }
    }
}
