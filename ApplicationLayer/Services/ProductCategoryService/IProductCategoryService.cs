using DomainLayer.Models;

namespace ApplicationLayer.Services.ProductCategoryService
{
    public interface IProductCategoryService
    {
        Task<IEnumerable<ProductCategory>> GetAll();
        Task<ProductCategory> GetById(Guid id);
        Task<ProductCategory> Add(ProductCategory ProductCategory);
        Task<ProductCategory> Update(ProductCategory ProductCategory);
        Task<ProductCategory> Remove(ProductCategory ProductCategory);
    }
}
