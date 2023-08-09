using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.OrderItemRepository
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(MyContext db) : base(db)
        {
        }

        public async Task<IEnumerable<OrderItem>> GetByOrderId(Guid id)
        {
            return await DbSet.Where(x => x.OrderId == id).ToListAsync();
        }

        public async Task<IEnumerable<OrderItem>> GetByProductId(Guid id)
        {
            return await DbSet.Where(x => x.ProductId == id).ToListAsync();
        }
    }
}
