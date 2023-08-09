using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;

namespace Infrastructure.Repositories.ProductCategoryRepository
{
    public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(MyContext db) : base(db)
        {
        }
    }
}
