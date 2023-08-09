using DomainLayer.Models;
using Infrastructure.Repositories.MatchesRepository;


namespace ApplicationLayer.Services.MatchesService
{
    public class MatchesService : IMatchesService
    {
        private readonly IMatchesRepository _repository;

        public MatchesService(IMatchesRepository repository)
        {
            _repository = repository;
        }
        public async Task<Matches> Add(Matches Matches)
        {
            try
            {
                Matches.Active = "Y";
                var res = await _repository.Add(Matches);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Matches>> GetAll()
        {
            try
            {
                var Matches = await _repository.GetAll();
                return (from u in Matches.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Matches>> GetByCompetitionId(Guid id)
        {
            try
            {
                var Matches = await _repository.GetByCompetitionId(id);
                return (from u in Matches.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Matches> GetById(Guid id)
        {
            Matches res = await _repository.GetById(id);
            if (res == null || res.Active != "Y")
            {
                return null;
            }
            return res;
        }

        public async Task<IEnumerable<Matches>> GetByTeamId(Guid id)
        {
            try
            {
                var Matches = await _repository.GetByTeamId(id);
                return (from u in Matches.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Matches> Remove(Matches Matches)
        {
            try
            {
                Matches.Active = "N";
                var res = await _repository.Update(Matches);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Matches> Update(Matches Matches)
        {
            try
            {
                Matches.Active = "Y";
                var res = await _repository.Update(Matches);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
