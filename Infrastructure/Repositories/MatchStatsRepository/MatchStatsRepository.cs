using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.MatchStatsRepository
{
    public class MatchStatsRepository : Repository<MatchStats>, IMatchStatsRepository
    {
        public MatchStatsRepository(MyContext db) : base(db)
        {
        }

        public async Task<IEnumerable<MatchStats>> GetByMatchId(Guid id)
        {
            return await DbSet.Where(x => x.MatchesId == id).ToListAsync();
        }
    }
}
