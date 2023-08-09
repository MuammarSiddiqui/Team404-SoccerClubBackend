using DomainLayer.Models;
using Infrastructure.Repositories.CompetitionRepository;


namespace ApplicationLayer.Services.CompetitionService
{
    public class CompetitionService : ICompetitionService
    {
        private readonly ICompetitionRepository _repository;

        public CompetitionService(ICompetitionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Competition> Add(Competition Competition)
        {
            try
            {
                Competition.Active = "Y";
                var res = await _repository.Add(Competition);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Competition>> GetAll()
        {
            try
            {
                var Competition = await _repository.GetAll();
                return (from u in Competition.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Competition> GetById(Guid id)
        {
            Competition res = await _repository.GetById(id);
            if (res == null || res.Active != "Y")
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            return res;
        }

        public async Task<Competition> Remove(Competition Competition)
        {
            try
            {
                Competition.Active = "N";
                var res = await _repository.Update(Competition);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Competition> Update(Competition Competition)
        {
            try
            {
                Competition.Active = "Y";
                var res = await _repository.Update(Competition);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
