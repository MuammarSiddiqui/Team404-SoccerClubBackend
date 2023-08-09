
namespace DomainLayer.Models
{
    public class Matches : BaseModal
    {
        public string Date { get; set; }
        public string? Time { get; set; }
        public Guid? TeamId { get; set; }
        public Team? Team { get; set; }
        public Guid? CompetitionId { get; set; }
        public Competition? Competition { get; set; }
        public List<MatchStats>? MatchStats { get; set; } = new List<MatchStats>();
    }
}
