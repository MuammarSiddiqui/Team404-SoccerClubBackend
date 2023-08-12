using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.UsersReposiotry
{
    public class UserRepository : Repository<Users>, IUsersRepository
    {
        public UserRepository(MyContext db) : base(db)
        {
        }

        public async Task<Users> Get(string username)
        {
            return await DbSet.Where(x => x.Username == username).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Users>> GetAllWithRelationship()
        {
            return await DbSet.Include(x=>x.Role).ToListAsync();
        }

        public async Task<Users> GetByEmail(string? email)
        {
            return await DbSet.Where(x => x.Email == email).FirstOrDefaultAsync();
        }
    }
}
