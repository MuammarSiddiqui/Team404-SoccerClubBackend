using DomainLayer.Models;

namespace ApplicationLayer.Services.TeamService
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetAll();
        Task<Team> GetById(Guid id);
        Task<Team> GetMyTeam();
        Task<Team> Add(Team Team);
        Task<Team> Update(Team Team);
        Task<Team> Remove(Team Team);
    }
}
