using DomainLayer.Models;

namespace ApplicationLayer.Services.OrderItemService
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItem>> GetAll();
        Task<OrderItem> GetById(Guid id);
        Task<OrderItem> Add(OrderItem OrderItem);
        Task<OrderItem> Update(OrderItem OrderItem);
        Task<OrderItem> Remove(OrderItem OrderItem);
        Task<IEnumerable<OrderItem>> GetByProductId(Guid id);
        Task<IEnumerable<OrderItem>> GetByOrderId(Guid id);
        Task<IEnumerable<OrderItem>> AddRange(IEnumerable<OrderItem> orderItemResult);
    }
}
