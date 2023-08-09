using DomainLayer.Models;
using Infrastructure.Repositories.ProductRepository;


namespace ApplicationLayer.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<Product> Add(Product Product)
        {
            try
            {
                Product.Active = "Y";
                var res = await _repository.Add(Product);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            try
            {
                var Product = await _repository.GetAll();
                return (from u in Product.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public async Task<IEnumerable<Product>> GetByCategoryId(Guid Id)
        {
            try
            {
                var Product = await _repository.GetByCategoryId(Id);
                return (from u in Product.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Product> GetById(Guid id)
        {
            Product res = await _repository.GetById(id);
            if (res == null || res.Active != "Y")
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            return res;
        }

        public async Task<Product> Remove(Product Product)
        {
            try
            {
                Product.Active = "N";
                var res = await _repository.Update(Product);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Product> Update(Product Product)
        {
            try
            {
                Product.Active = "Y";
                var res = await _repository.Update(Product);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
