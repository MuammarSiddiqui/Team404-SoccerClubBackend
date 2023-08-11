using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;

namespace Infrastructure.Repositories.TeamRepository
{
    public interface ITeamRepository : IRepository<Team>
    {
        Task<Team> GetMyTeam();
    }
}
