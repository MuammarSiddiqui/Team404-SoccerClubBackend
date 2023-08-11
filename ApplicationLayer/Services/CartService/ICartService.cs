using DomainLayer.Dtos.Cart;
using DomainLayer.Models;

namespace ApplicationLayer.Services.CartService
{
    public interface ICartService
    {
        Task<IEnumerable<Cart>> GetAll();
        Task<Cart> GetById(Guid id);
        Task<Cart> Add(Cart Cart);
        Task<Cart> Update(Cart Cart);
        Task<Cart> Remove(Cart Cart);
        Task<IEnumerable<Cart>> GetByProductId(Guid id);
        Task<IEnumerable<CartResultDto>> GetByUsersId(Guid id);
        Task<IEnumerable<Cart>> AddRange(List<Cart> list);
    }
}
