using DomainLayer.Models;

namespace ApplicationLayer.Services.RoleService
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAll();
        Task<Role> GetById(Guid id);
        Task<Role> Add(Role Role);
        Task<Role> Update(Role Role);
        Task<Role> Remove(Role Role);
    }
}
