using DomainLayer.Models;
using Infrastructure.Repositories.RoleRepository;


namespace ApplicationLayer.Services.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;

        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Role> Add(Role Role)
        {
            try
            {
                Role.Active = "Y";
                var res = await _repository.Add(Role);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            try
            {
                var Role = await _repository.GetAll();
                return (from u in Role.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Role> GetById(Guid id)
        {
            Role res = await _repository.GetById(id);
            if (res == null || res.Active != "Y")
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            return res;
        }

        public async Task<Role> Remove(Role Role)
        {
            try
            {
                Role.Active = "N";
                var res = await _repository.Update(Role);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Role> Update(Role Role)
        {
            try
            {
                Role.Active = "Y";
                var res = await _repository.Update(Role);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
