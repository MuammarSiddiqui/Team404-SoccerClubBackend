using DomainLayer.Dtos.Player;
using DomainLayer.Models;

namespace ApplicationLayer.Services.PlayerService
{
    public interface IPlayerService
    {
        Task<IEnumerable<Player>> GetAll();
        Task<IEnumerable<PlayerResultDto>> GetAllWithRelationship();
        Task<Player> GetById(Guid id);
        Task<Player> Add(Player Player);
        Task<Player> Update(Player Player);
        Task<Player> Remove(Player Player);
        Task<IEnumerable<Player>> GetByTeamId(Guid id);
    }
}
