using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.OrderRepository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(MyContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Order>> GetByUserId(Guid id)
        {
            return await DbSet.Where(x => x.UsersId == id).ToListAsync();
        }
    }
}
