using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;

namespace Infrastructure.Repositories.NewsRepository
{
    public class NewsRepository : Repository<News>, INewsRepository
    {
        public NewsRepository(MyContext db) : base(db)
        {
        }
    }
}
