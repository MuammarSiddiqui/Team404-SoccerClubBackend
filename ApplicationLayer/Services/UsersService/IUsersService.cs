using DomainLayer.Dtos.UsersDto;
using DomainLayer.Models;

namespace ApplicationLayer.Services.UsersService
{
    public interface IUsersService
    {
        Task<IEnumerable<Users>> GetAll();
        Task<Users> GetById(Guid id);
        Task<Users> Get(string Username);
        Task<Users> GetByEmail(string? email);
        Task<Users> Add(Users User);
        Task<Users> Update(Users User);
        Task<Users> Remove(Users User);
        Task<IEnumerable<UsersResultDto>> GetAllWithRelationship();
    }
}
