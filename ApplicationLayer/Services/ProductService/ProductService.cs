using AutoMapper;
using DomainLayer.Dtos.Product;
using DomainLayer.Models;
using Infrastructure.Repositories.ProductRepository;


namespace ApplicationLayer.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository repository,IMapper mapper )
        {
            _mapper = mapper;
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
        public async Task<IEnumerable<ProductResultDto>> GetAllWithRelationship()
        {
            try
            {
                var lst = new List<ProductResultDto>();
                var Product = await _repository.GetAllWithRelationship();
                foreach (var item in Product)
                {
                    if (item.Active == "Y")
                    {
                        var obj = _mapper.Map<ProductResultDto>(item);
                        if (item.ProductCategory != null)
                        {
                            obj.ProductCategory = item.ProductCategory.Name;
                            if (item.ProductCategory.Active =="Y")
                            {
                                lst.Add(obj);
                            }
                        }
                        
                    }
                }
                return lst;
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
                return null;
            }
            return res;
        }
        
        public async Task<Product> GetByIdWithCategory(Guid id)
        {
            Product res = await _repository.GetByIdWithCategory(id);
            if (res == null || res.Active != "Y")
            {
                return null;
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
