using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.MatchesRepository
{
    public class MatchesRepository : Repository<Matches>, IMatchesRepository
    {
        public MatchesRepository(MyContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Matches>> GetByCompetitionId(Guid id)
        {
            return await DbSet.Where(x => x.CompetitionId == id).ToListAsync();
        }

        public async Task<IEnumerable<Matches>> GetByTeamId(Guid id)
        {
            return await DbSet.Where(x => x.TeamId == id).ToListAsync();
        }
    }
}
