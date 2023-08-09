using DomainLayer.Models;
using Infrastructure.Repositories.ProductCategoryRepository;


namespace ApplicationLayer.Services.ProductCategoryService
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _repository;

        public ProductCategoryService(IProductCategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<ProductCategory> Add(ProductCategory ProductCategory)
        {
            try
            {
                ProductCategory.Active = "Y";
                var res = await _repository.Add(ProductCategory);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ProductCategory>> GetAll()
        {
            try
            {
                var ProductCategory = await _repository.GetAll();
                return (from u in ProductCategory.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ProductCategory> GetById(Guid id)
        {
            ProductCategory res = await _repository.GetById(id);
            if (res == null || res.Active != "Y")
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            return res;
        }

        public async Task<ProductCategory> Remove(ProductCategory ProductCategory)
        {
            try
            {
                ProductCategory.Active = "N";
                var res = await _repository.Update(ProductCategory);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ProductCategory> Update(ProductCategory ProductCategory)
        {
            try
            {
                ProductCategory.Active = "Y";
                var res = await _repository.Update(ProductCategory);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
