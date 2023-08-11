using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;

namespace Infrastructure.Repositories.ProductRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetByCategoryId(Guid id);
        Task<IEnumerable<Product>> GetAllWithRelationship();
        Task<Product> GetByIdWithCategory(Guid id);
    }
}
