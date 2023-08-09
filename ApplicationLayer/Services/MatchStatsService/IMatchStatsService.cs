using DomainLayer.Models;

namespace ApplicationLayer.Services.MatchStatsService
{
    public interface IMatchStatsService
    {
        Task<IEnumerable<MatchStats>> GetAll();
        Task<MatchStats> GetById(Guid id);
        Task<MatchStats> Add(MatchStats MatchStats);
        Task<MatchStats> Update(MatchStats MatchStats);
        Task<MatchStats> Remove(MatchStats MatchStats);
        Task<IEnumerable<MatchStats>> GetByMatchId(Guid Id);
    }
}
