using DomainLayer.Models;

namespace ApplicationLayer.Services.SoccerInfoService
{
    public interface ISoccerInfoService
    {
        Task<IEnumerable<SoccerInfo>> GetAll();
        Task<SoccerInfo> GetById(Guid id);
        Task<SoccerInfo> Add(SoccerInfo SoccerInfo);
        Task<SoccerInfo> Update(SoccerInfo SoccerInfo);
        Task<SoccerInfo> Remove(SoccerInfo SoccerInfo);
    }
}
