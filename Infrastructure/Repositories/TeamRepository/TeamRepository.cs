using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.TeamRepository
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(MyContext db) : base(db)
        {
        }

        public async Task<Team> GetMyTeam()
        {
            return await DbSet.Where(x => x.Club == true).FirstOrDefaultAsync();
        }
    }
}
