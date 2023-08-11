using DomainLayer.Dtos.Product;
using DomainLayer.Models;

namespace ApplicationLayer.Services.ProductService
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(Guid id);
        Task<Product> GetByIdWithCategory(Guid id);
        Task<Product> Add(Product Product);
        Task<Product> Update(Product Product);
        Task<Product> Remove(Product Product);
        Task<IEnumerable<Product>> GetByCategoryId(Guid id);
        Task<IEnumerable<ProductResultDto>> GetAllWithRelationship();
   
    }
}
