using DomainLayer.Models;

namespace ApplicationLayer.Services.CompetitionService
{
    public interface ICompetitionService
    {
        Task<IEnumerable<Competition>> GetAll();
        Task<Competition> GetById(Guid id);
        Task<Competition> Add(Competition Competition);
        Task<Competition> Update(Competition Competition);
        Task<Competition> Remove(Competition Competition);
    }
}
