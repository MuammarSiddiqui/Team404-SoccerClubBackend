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
            return await DbSet.Where(x => x.CompetitionId == id).AsNoTracking().ToListAsync();
        }
        
        public async Task<IEnumerable<Matches>> GetAllWithRelationship()
        {
            return await DbSet.Include(x=>x.Team).Include(x=>x.Competition).AsNoTracking().ToListAsync();
        }

        public async Task<Matches> GetByCurrentDate(DateTime date)
        {
            return await DbSet.Where(x=>x.DateTime.Date == date.Date).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Matches>> GetByTeamId(Guid id)
        {
            return await DbSet.Where(x => x.TeamId == id).AsNoTracking().ToListAsync();
        }
    }
}
