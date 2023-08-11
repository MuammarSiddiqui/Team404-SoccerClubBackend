using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.UserAddressesRepository
{
    public class UserAddressesRepository : Repository<UserAddresses>, IUserAddressesRepository
    {
        public UserAddressesRepository(MyContext db) : base(db)
        {
        }

        public async Task<IEnumerable<UserAddresses>> GetByUserId(Guid id)
        {
            return await DbSet.Where(x => x.UsersId == id).ToListAsync();
        }
    }
}
