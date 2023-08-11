using DomainLayer.Models;
using Infrastructure.Repositories.MatchStatsRepository;
using System.Text.RegularExpressions;


namespace ApplicationLayer.Services.MatchStatsService
{
    public class MatchStatsService : IMatchStatsService
    {
        private readonly IMatchStatsRepository _repository;

        public MatchStatsService(IMatchStatsRepository repository)
        {
            _repository = repository;
        }
        public async Task<MatchStats> Add(MatchStats MatchStats)
        {
            try
            {
                MatchStats.Active = "Y";
                var res = await _repository.Add(MatchStats);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<MatchStats>> GetAll()
        {
            try
            {
                var MatchStats = await _repository.GetAll();
                return (from u in MatchStats.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<MatchStats>> GetByMatchId(Guid Id)
        {
            try
            {
                var MatchStats = await _repository.GetByMatchId(Id);
                return (from u in MatchStats.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MatchStats> GetById(Guid id)
        {
            MatchStats res = await _repository.GetById(id);
            if (res == null || res.Active != "Y")
            {
                return null;
            }
            return res;
        }

        public async Task<MatchStats> Remove(MatchStats MatchStats)
        {
            try
            {
                MatchStats.Active = "N";
                var res = await _repository.Update(MatchStats);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MatchStats> Update(MatchStats MatchStats)
        {
            try
            {
                MatchStats.Active = "Y";
                var res = await _repository.Update(MatchStats);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
