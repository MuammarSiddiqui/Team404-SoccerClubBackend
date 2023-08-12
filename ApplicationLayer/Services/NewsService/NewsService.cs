using DomainLayer.Models;
using Infrastructure.Repositories.NewsRepository;


namespace ApplicationLayer.Services.NewsService
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _repository;

        public NewsService(INewsRepository repository)
        {
            _repository = repository;
        }
        public async Task<News> Add(News News)
        {
            try
            {
                News.Active = "Y";
                var res = await _repository.Add(News);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<News>> GetAll()
        {
            try
            {
                var News = await _repository.GetAll();
                return (from u in News.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<News> GetById(Guid id)
        {
            News res = await _repository.GetById(id);
            if (res == null || res.Active != "Y")
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            return res;
        }

        public async Task<News> Remove(News News)
        {
            try
            {
                News.Active = "N";
                var res = await _repository.Update(News);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<News> Update(News News)
        {
            try
            {
                News.Active = "Y";
                var res = await _repository.Update(News);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
