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

        public async Task<PlayerStats> GetByPlayerId(Guid id)
        {
            return await DbSet.Where(x => x.PlayerId == id).AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<PlayerStats>> GetAllWithRelationship()
        {
            return await DbSet.Include(x=>x.Player).AsNoTracking().ToListAsync();
        }
    }
}
