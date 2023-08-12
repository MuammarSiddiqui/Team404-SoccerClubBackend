using DomainLayer.Models;

namespace ApplicationLayer.Services.NewsService
{
    public interface INewsService
    {
        Task<IEnumerable<News>> GetAll();
        Task<News> GetById(Guid id);
        Task<News> Add(News News);
        Task<News> Update(News News);
        Task<News> Remove(News News);
    }
}
