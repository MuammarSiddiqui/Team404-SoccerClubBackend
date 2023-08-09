using DomainLayer.Models;
using Infrastructure.Repositories.TeamStatsRepository;


namespace ApplicationLayer.Services.TeamStatsService
{
    public class TeamStatsService : ITeamStatsService
    {
        private readonly ITeamStatsRepository _repository;

        public TeamStatsService(ITeamStatsRepository repository)
        {
            _repository = repository;
        }
        public async Task<TeamStats> Add(TeamStats TeamStats)
        {
            try
            {
                TeamStats.Active = "Y";
                var res = await _repository.Add(TeamStats);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<TeamStats>> GetAll()
        {
            try
            {
                var TeamStats = await _repository.GetAll();
                return (from u in TeamStats.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        

        public async Task<IEnumerable<TeamStats>> GetByTeamId(Guid Id)
        {
            try
            {
                var TeamStats = await _repository.GetByTeamId(Id);
                return (from u in TeamStats.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public async Task<IEnumerable<TeamStats>> GetByMatchId(Guid Id)
        {
            try
            {
                var TeamStats = await _repository.GetByMatchId(Id);
                return (from u in TeamStats.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TeamStats> GetById(Guid id)
        {
            TeamStats res = await _repository.GetById(id);
            if (res == null || res.Active != "Y")
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            return res;
        }

        public async Task<TeamStats> Remove(TeamStats TeamStats)
        {
            try
            {
                TeamStats.Active = "N";
                var res = await _repository.Update(TeamStats);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TeamStats> Update(TeamStats TeamStats)
        {
            try
            {
                TeamStats.Active = "Y";
                var res = await _repository.Update(TeamStats);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
