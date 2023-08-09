using DomainLayer.Models;
using Infrastructure.Repositories.PlayerAchievementRepository;


namespace ApplicationLayer.Services.PlayerAchievementService
{
    public class PlayerAchievementService : IPlayerAchievementService
    {
        private readonly IPlayerAchievementRepository _repository;

        public PlayerAchievementService(IPlayerAchievementRepository repository)
        {
            _repository = repository;
        }
        public async Task<PlayerAchievement> Add(PlayerAchievement PlayerAchievement)
        {
            try
            {
                PlayerAchievement.Active = "Y";
                var res = await _repository.Add(PlayerAchievement);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<PlayerAchievement>> GetAll()
        {
            try
            {
                var PlayerAchievement = await _repository.GetAll();
                return (from u in PlayerAchievement.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<PlayerAchievement>> GetByMatchId(Guid Id)
        {
            try
            {
                var PlayerAchievement = await _repository.GetByMatchId(Id);
                return (from u in PlayerAchievement.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public async Task<IEnumerable<PlayerAchievement>> GetByPlayerId(Guid Id)
        {
            try
            {
                var PlayerAchievement = await _repository.GetByPlayerId(Id);
                return (from u in PlayerAchievement.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PlayerAchievement> GetById(Guid id)
        {
            PlayerAchievement res = await _repository.GetById(id);
            if (res == null || res.Active != "Y")
            {
                return null;
            }
            return res;
        }

        public async Task<PlayerAchievement> Remove(PlayerAchievement PlayerAchievement)
        {
            try
            {
                PlayerAchievement.Active = "N";
                var res = await _repository.Update(PlayerAchievement);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PlayerAchievement> Update(PlayerAchievement PlayerAchievement)
        {
            try
            {
                PlayerAchievement.Active = "Y";
                var res = await _repository.Update(PlayerAchievement);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
