using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;

namespace Infrastructure.Repositories.TeamRepository
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(MyContext db) : base(db)
        {
        }
    }
}
