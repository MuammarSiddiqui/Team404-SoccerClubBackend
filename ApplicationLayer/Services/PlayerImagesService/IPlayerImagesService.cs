using DomainLayer.Models;

namespace ApplicationLayer.Services.PlayerImagesService
{
    public interface IPlayerImagesService
    {
        Task<IEnumerable<PlayerImages>> GetAll();
        Task<PlayerImages> GetById(Guid id);
        Task<PlayerImages> Add(PlayerImages PlayerImages);
        Task<PlayerImages> Update(PlayerImages PlayerImages);
        Task<PlayerImages> Remove(PlayerImages PlayerImages);
        Task<IEnumerable<PlayerImages>> AddRange(List<PlayerImages> lst);
        Task<IEnumerable<PlayerImages>> GetByPlayerId(Guid id);
    }
}
