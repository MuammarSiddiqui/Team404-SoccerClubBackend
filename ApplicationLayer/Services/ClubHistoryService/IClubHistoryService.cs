using DomainLayer.Models;

namespace ApplicationLayer.Services.ClubHistoryService
{
    public interface IClubHistoryService
    {
        Task<IEnumerable<ClubHistory>> GetAll();
        Task<ClubHistory> GetById(Guid id);
        Task<ClubHistory> Add(ClubHistory ClubHistory);
        Task<ClubHistory> Update(ClubHistory ClubHistory);
        Task<ClubHistory> Remove(ClubHistory ClubHistory);
    }
}
