using AutoMapper;
using DomainLayer.Dtos.Cart;
using DomainLayer.Dtos.Product;
using DomainLayer.Models;
using Infrastructure.Repositories.CartRepository;


namespace ApplicationLayer.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _repository;
        private readonly IMapper _mapper;
        public CartService(ICartRepository repository,IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<Cart> Add(Cart Cart)
        {
            try
            {
                Cart.Active = "Y";
                var res = await _repository.Add(Cart);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<Cart>> AddRange(List<Cart> list)
        {
            try
            {
                foreach (var item in list)
                {
                    item.Active = "Y";
                }
                 await _repository.AddRange(list);
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<Cart>> UpdateRange(List<Cart> list)
        {
            try
            {
                foreach (var item in list)
                {
                    item.Active = "Y";
                }
                 await _repository.UpdateRange(list);
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<Cart>> RemoveRange(List<Cart> list)
        {
            try
            {
                foreach (var item in list)
                {
                    item.Active = "N";
                }
                 await _repository.UpdateRange(list);
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Cart>> GetAll()
        {
            try
            {
                var Cart = await _repository.GetAll();
                return (from u in Cart.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public async Task<IEnumerable<Cart>> GetByProductId(Guid Id)
        {
            try
            {
                var Cart = await _repository.GetByProductId(Id);
                return (from u in Cart.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public async Task<IEnumerable<CartResultDto>> GetByUsersId(Guid Id)
        {
            try
            {
                var Cart = await _repository.GetByUsersId(Id);
                List<CartResultDto> lst = new();
                foreach (var item in Cart)
                {
                    if (item.Active =="Y")
                    {

                        var obj = _mapper.Map<CartResultDto>(item);
                        if (item.Product != null)
                        {
                            obj.Product = _mapper.Map<ProductResultDto>(item.Product);
                        }
                        lst.Add(obj);
                    }
                }
                return lst;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Cart> GetById(Guid id)
        {
            Cart res = await _repository.GetById(id);
            if (res == null || res.Active != "Y")
            {
                return null;
            }
            return res;
        }

        public async Task<Cart> Remove(Cart Cart)
        {
            try
            {
                Cart.Active = "N";
                var res = await _repository.Update(Cart);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Cart> Update(Cart Cart)
        {
            try
            {
                Cart.Active = "Y";
                var res = await _repository.Update(Cart);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
