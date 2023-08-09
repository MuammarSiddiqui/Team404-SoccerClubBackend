
namespace DomainLayer.Dtos.TeamStats
{
    public class TeamStatsResultDto : BaseResultDto
    {
        public int GoalsScored { get; set; }
        public int GoalsConceded { get; set; }
        public int Shots { get; set; }
        public int Fouls { get; set; }
        public decimal Possession { get; set; }
        public Guid? TeamId { get; set; }
        public string? Team { get; set; }
        public Guid? MatchesId { get; set; }
        public string? Matches { get; set; }
    }
}
