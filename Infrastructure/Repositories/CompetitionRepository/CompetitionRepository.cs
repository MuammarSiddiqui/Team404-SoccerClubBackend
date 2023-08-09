using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;

namespace Infrastructure.Repositories.CompetitionRepository
{
    public class CompetitionRepository : Repository<Competition>, ICompetitionRepository
    {
        public CompetitionRepository(MyContext db) : base(db)
        {
        }
    }
}
