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
            return await DbSet.Include(x=>x.UserAddresses).Include(x=>x.Users).Where(x => x.UsersId == id).ToListAsync();
        }
        public async Task<Order> GetByIdWithRelationship(Guid id)
        {
            return await DbSet.Include(x=>x.UserAddresses).Include(x => x.Users).Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Order>> GetAllWithRelationship()
        {
            return await DbSet.Include(x=>x.UserAddresses).Include(x => x.Users).ToListAsync();
        }
    }
}
