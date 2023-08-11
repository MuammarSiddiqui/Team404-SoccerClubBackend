using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.TeamStatsRepository
{
    public class TeamStatsRepository : Repository<TeamStats>, ITeamStatsRepository
    {
        public TeamStatsRepository(MyContext db) : base(db)
        {
        }

        public async Task<TeamStats> GetByMatchAndTeam(Guid matchId, Guid teamId)
        {
            return await DbSet.Where(x => x.MatchesId == matchId && x.TeamId == teamId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TeamStats>> GetByMatchId(Guid id)
        {
            return await DbSet.Where(x => x.MatchesId == id).ToListAsync();
        }

        public async Task<IEnumerable<TeamStats>> GetByTeamId(Guid id)
        {
            return await DbSet.Where(x => x.TeamId == id).ToListAsync();
        }
    }
}
