using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;

namespace Infrastructure.Repositories.OrderRepository
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetByUserId(Guid id);
        Task<IEnumerable<Order>> GetAllWithRelationship();
        Task<Order> GetByIdWithRelationship(Guid id);
    }
}
