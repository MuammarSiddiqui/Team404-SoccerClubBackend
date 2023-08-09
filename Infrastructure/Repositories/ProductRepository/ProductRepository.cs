using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ProductRepository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(MyContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Product>> GetByCategoryId(Guid id)
        {
            return await DbSet.Where(x => x.ProductCategoryId == id).ToListAsync();
        }
    }
}
