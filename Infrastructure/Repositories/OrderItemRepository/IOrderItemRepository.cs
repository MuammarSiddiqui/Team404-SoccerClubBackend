using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;

namespace Infrastructure.Repositories.OrderItemRepository
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        Task AddRange(IEnumerable<OrderItem> orderItem);
        Task<IEnumerable<OrderItem>> GetByOrderId(Guid id);
        Task<IEnumerable<OrderItem>> GetByProductId(Guid id);
    }
}
