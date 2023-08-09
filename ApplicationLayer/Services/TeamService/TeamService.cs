using DomainLayer.Models;
using Infrastructure.Repositories.TeamRepository;


namespace ApplicationLayer.Services.TeamService
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _repository;

        public TeamService(ITeamRepository repository)
        {
            _repository = repository;
        }
        public async Task<Team> Add(Team Team)
        {
            try
            {
                Team.Active = "Y";
                var res = await _repository.Add(Team);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Team>> GetAll()
        {
            try
            {
                var Team = await _repository.GetAll();
                return (from u in Team.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Team> GetById(Guid id)
        {
            Team res = await _repository.GetById(id);
            if (res == null || res.Active != "Y")
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            return res;
        }

        public async Task<Team> Remove(Team Team)
        {
            try
            {
                Team.Active = "N";
                var res = await _repository.Update(Team);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Team> Update(Team Team)
        {
            try
            {
                Team.Active = "Y";
                var res = await _repository.Update(Team);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
