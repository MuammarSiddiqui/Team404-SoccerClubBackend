using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;

namespace Infrastructure.Repositories.PlayerRepository
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Task<IEnumerable<Player>> GetByTeamId(Guid id);
        Task<IEnumerable<Player>> GetAllWithRelationship();
    }
}
