using DomainLayer.Models;
using Infrastructure.Repositories.ClubHistoryRepository;


namespace ApplicationLayer.Services.ClubHistoryService
{
    public class ClubHistoryService : IClubHistoryService
    {
        private readonly IClubHistoryRepository _repository;

        public ClubHistoryService(IClubHistoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<ClubHistory> Add(ClubHistory ClubHistory)
        {
            try
            {
                ClubHistory.Active = "Y";
                var res = await _repository.Add(ClubHistory);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ClubHistory>> GetAll()
        {
            try
            {
                var ClubHistory = await _repository.GetAll();
                return (from u in ClubHistory.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ClubHistory> GetById(Guid id)
        {
            ClubHistory res = await _repository.GetById(id);
            if (res == null || res.Active != "Y")
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            return res;
        }

        public async Task<ClubHistory> Remove(ClubHistory ClubHistory)
        {
            try
            {
                ClubHistory.Active = "N";
                var res = await _repository.Update(ClubHistory);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ClubHistory> Update(ClubHistory ClubHistory)
        {
            try
            {
                ClubHistory.Active = "Y";
                var res = await _repository.Update(ClubHistory);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
