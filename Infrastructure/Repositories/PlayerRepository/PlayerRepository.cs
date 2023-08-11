using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.PlayerRepository
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(MyContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Player>> GetAllWithRelationship()
        {
            return await DbSet.Include(x=>x.Team).ToListAsync();
        }

        public async Task<IEnumerable<Player>> GetByTeamId(Guid id)
        {
            return await DbSet.Where(x => x.TeamId == id).ToListAsync();
        }
    }
}
