using DomainLayer.Models;

namespace ApplicationLayer.Services.UserAddressesService
{
    public interface IUserAddressesService
    {
        Task<IEnumerable<UserAddresses>> GetAll();
        Task<UserAddresses> GetById(Guid id);
        Task<UserAddresses> Add(UserAddresses UserAddresses);
        Task<UserAddresses> Update(UserAddresses UserAddresses);
        Task<UserAddresses> Remove(UserAddresses UserAddresses);
        Task<IEnumerable<UserAddresses>> GetByUserId(Guid id);
    }
}
