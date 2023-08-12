using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;

namespace Infrastructure.Repositories.CartRepository
{
    public interface ICartRepository : IRepository<Cart>
    {
        Task<IEnumerable<Cart>> GetByUsersId(Guid id);
        Task<IEnumerable<Cart>> GetByProductId(Guid id);
        Task AddRange(List<Cart> list);
        Task UpdateRange(List<Cart> list);
    }
}
