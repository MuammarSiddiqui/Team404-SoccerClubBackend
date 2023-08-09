
namespace DomainLayer.Models
{
    public class TeamStats : BaseModal
    {
        public int GoalsScored { get; set; }
        public int GoalsConceded { get; set; }
        public int Shots { get; set; }
        public int Fouls { get; set; }
        public decimal Possession { get; set; }
        public Guid? TeamId { get; set; }
        public Team? Team { get; set; }
        public Guid? MatchesId { get; set; }
        public Matches? Matches { get; set; }
    }
}
