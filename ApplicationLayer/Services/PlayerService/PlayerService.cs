using DomainLayer.Models;
using Infrastructure.Repositories.PlayerRepository;


namespace ApplicationLayer.Services.PlayerService
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _repository;

        public PlayerService(IPlayerRepository repository)
        {
            _repository = repository;
        }
        public async Task<Player> Add(Player Player)
        {
            try
            {
                Player.Active = "Y";
                var res = await _repository.Add(Player);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Player>> GetAll()
        {
            try
            {
                var Player = await _repository.GetAll();
                return (from u in Player.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<Player>> GetByTeamId(Guid Id)
        {
            try
            {
                var Player = await _repository.GetByTeamId(Id);
                return (from u in Player.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Player> GetById(Guid id)
        {
            Player res = await _repository.GetById(id);
            if (res == null || res.Active != "Y")
            {
                return null;
            }
            return res;
        }

        public async Task<Player> Remove(Player Player)
        {
            try
            {
                Player.Active = "N";
                var res = await _repository.Update(Player);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Player> Update(Player Player)
        {
            try
            {
                Player.Active = "Y";
                var res = await _repository.Update(Player);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
