using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;

namespace Infrastructure.Repositories.SoccerInfoRepository
{
    public class SoccerInfoRepository : Repository<SoccerInfo>, ISoccerInfoRepository
    {
        public SoccerInfoRepository(MyContext db) : base(db)
        {
        }
    }
}
