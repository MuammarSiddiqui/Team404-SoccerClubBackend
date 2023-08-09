using DomainLayer.Models;

namespace ApplicationLayer.Services.MatchesService
{
    public interface IMatchesService
    {
        Task<IEnumerable<Matches>> GetAll();
        Task<Matches> GetById(Guid id);
        Task<Matches> Add(Matches Matches);
        Task<Matches> Update(Matches Matches);
        Task<Matches> Remove(Matches Matches);
        Task<IEnumerable<Matches>> GetByTeamId(Guid id);
        Task<IEnumerable<Matches>> GetByCompetitionId(Guid id);
    }
}
