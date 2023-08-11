using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;

namespace Infrastructure.Repositories.UserAddressesRepository
{
    public interface IUserAddressesRepository : IRepository<UserAddresses>
    {
        Task<IEnumerable<UserAddresses>> GetByUserId(Guid id);
    }
}
