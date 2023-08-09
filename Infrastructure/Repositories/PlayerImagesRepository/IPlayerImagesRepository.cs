using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;

namespace Infrastructure.Repositories.PlayerImagesRepository
{
    public interface IPlayerImagesRepository : IRepository<PlayerImages>
    {
        Task<IEnumerable<PlayerImages>> AddRange(List<PlayerImages> playerImages);
        Task<IEnumerable<PlayerImages>> GetByPlayerId(Guid id);
    }
}
