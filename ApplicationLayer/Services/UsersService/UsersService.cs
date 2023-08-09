using DomainLayer.Models;
using Infrastructure.Repositories.UsersReposiotry;

namespace ApplicationLayer.Services.UsersService
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _repository;

        public UsersService(IUsersRepository repository)
        {
            _repository = repository;
        }
        public async Task<Users> Add(Users User)
        {
            try
            {
                User.Active = "Y";
                var res = await _repository.Add(User);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Users> Get(string Username)
        {
            Users res = await _repository.Get(Username);
            if (res == null || res.Active != "Y")
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            return res;
        }

        public async Task<Users> GetByEmail(string? email)
        {
            Users res = await _repository.GetByEmail(email);
            if (res == null || res.Active != "Y")
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            return res;
        }

        public async Task<IEnumerable<Users>> GetAll()
        {
            try
            {
                var Users = await _repository.GetAll();
                return (from u in Users.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Users> GetById(Guid id)
        {
            Users res = await _repository.GetById(id);
            if (res == null || res.Active != "Y")
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            return res;
        }

        public async Task<Users> Remove(Users User)
        {
            try
            {
                User.Active = "N";
                var res = await _repository.Update(User);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Users> Update(Users User)
        {
            try
            {
                User.Active = "Y";
                var res = await _repository.Update(User);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
