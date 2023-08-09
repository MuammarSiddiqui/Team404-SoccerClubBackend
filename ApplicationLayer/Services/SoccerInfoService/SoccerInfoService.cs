using DomainLayer.Models;
using Infrastructure.Repositories.SoccerInfoRepository;


namespace ApplicationLayer.Services.SoccerInfoService
{
    public class SoccerInfoService : ISoccerInfoService
    {
        private readonly ISoccerInfoRepository _repository;

        public SoccerInfoService(ISoccerInfoRepository repository)
        {
            _repository = repository;
        }
        public async Task<SoccerInfo> Add(SoccerInfo SoccerInfo)
        {
            try
            {
                SoccerInfo.Active = "Y";
                var res = await _repository.Add(SoccerInfo);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<SoccerInfo>> GetAll()
        {
            try
            {
                var SoccerInfo = await _repository.GetAll();
                return (from u in SoccerInfo.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<SoccerInfo> GetById(Guid id)
        {
            SoccerInfo res = await _repository.GetById(id);
            if (res == null || res.Active != "Y")
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            return res;
        }

        public async Task<SoccerInfo> Remove(SoccerInfo SoccerInfo)
        {
            try
            {
                SoccerInfo.Active = "N";
                var res = await _repository.Update(SoccerInfo);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<SoccerInfo> Update(SoccerInfo SoccerInfo)
        {
            try
            {
                SoccerInfo.Active = "Y";
                var res = await _repository.Update(SoccerInfo);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
