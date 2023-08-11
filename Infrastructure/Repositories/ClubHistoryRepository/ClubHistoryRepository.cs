using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;

namespace Infrastructure.Repositories.ClubHistoryRepository
{
    public class ClubHistoryRepository : Repository<ClubHistory>, IClubHistoryRepository
    {
        public ClubHistoryRepository(MyContext db) : base(db)
        {
        }
    }
}
