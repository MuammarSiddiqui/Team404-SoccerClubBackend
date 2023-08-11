
namespace DomainLayer.Models
{
    public class Matches : BaseModal
    {
        public string? Stadium { get; set; }
        public DateTime DateTime { get; set; }
        public Guid? TeamId { get; set; }
        public Team? Team { get; set; }
        public Guid? CompetitionId { get; set; }
        public Competition? Competition { get; set; }
        public List<MatchStats>? MatchStats { get; set; } = new List<MatchStats>();
    }
}
