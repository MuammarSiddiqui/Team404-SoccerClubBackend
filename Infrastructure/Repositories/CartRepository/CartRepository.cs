using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CartRepository
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(MyContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Cart>> GetByUsersId(Guid id)
        {
            return await DbSet.Include(x=>x.Product).Where(x => x.UsersId == id).ToListAsync();
        }

        public async Task<IEnumerable<Cart>> GetByProductId(Guid id)
        {
            return await DbSet.Where(x => x.ProductId == id).ToListAsync();
        }

        public async Task AddRange(List<Cart> list)
        {
             await DbSet.AddRangeAsync(list);
            await SaveChanges();
        }
        public async Task UpdateRange(List<Cart> list)
        {
            Db.ChangeTracker.Clear();
            DbSet.UpdateRange(list);
            await SaveChanges();
        }
    }
}
