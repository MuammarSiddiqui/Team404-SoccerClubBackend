using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;


namespace Infrastructure.Repositories.UsersReposiotry
{
    public interface IUsersRepository : IRepository<Users>
    {
        Task<Users> Get(string username);
        Task<Users> GetByEmail(string? email);
    }
}
