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
#pragma warning disable CS8603 // Possible null reference return.
            return await DbSet.Where(x => x.Username == username).FirstOrDefaultAsync();
        }

        public async Task<Users> GetByEmail(string? email)
        {
            return await DbSet.Where(x => x.Email == email).FirstOrDefaultAsync();
        }
#pragma warning restore CS8603 // Possible null reference return.
    }
}
