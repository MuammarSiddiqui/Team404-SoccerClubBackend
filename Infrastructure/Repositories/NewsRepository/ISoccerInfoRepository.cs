using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;


namespace Infrastructure.Repositories.NewsRepository
{
    public interface INewsRepository : IRepository<News>
    {
    }
}
