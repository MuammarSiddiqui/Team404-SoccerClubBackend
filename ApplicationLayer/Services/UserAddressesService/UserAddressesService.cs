using DomainLayer.Models;
using Infrastructure.Repositories.UserAddressesRepository;


namespace ApplicationLayer.Services.UserAddressesService
{
    public class UserAddressesService : IUserAddressesService
    {
        private readonly IUserAddressesRepository _repository;

        public UserAddressesService(IUserAddressesRepository repository)
        {
            _repository = repository;
        }
        public async Task<UserAddresses> Add(UserAddresses UserAddresses)
        {
            try
            {
                UserAddresses.Active = "Y";
                var res = await _repository.Add(UserAddresses);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<UserAddresses>> GetAll()
        {
            try
            {
                var UserAddresses = await _repository.GetAll();
                return (from u in UserAddresses.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public async Task<IEnumerable<UserAddresses>> GetByUserId(Guid Id)
        {
            try
            {
                var UserAddresses = await _repository.GetByUserId(Id);
                return (from u in UserAddresses.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserAddresses> GetById(Guid id)
        {
            UserAddresses res = await _repository.GetById(id);
            if (res == null || res.Active != "Y")
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            return res;
        }

        public async Task<UserAddresses> Remove(UserAddresses UserAddresses)
        {
            try
            {
                UserAddresses.Active = "N";
                var res = await _repository.Update(UserAddresses);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserAddresses> Update(UserAddresses UserAddresses)
        {
            try
            {
                UserAddresses.Active = "Y";
                var res = await _repository.Update(UserAddresses);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
