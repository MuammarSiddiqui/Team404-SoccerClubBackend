namespace Infrastructure.Repositories.BaseRepository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid Id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
    }
}
