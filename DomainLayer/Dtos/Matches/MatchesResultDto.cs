
namespace DomainLayer.Dtos.Matches
{
    public class MatchesResultDto : BaseResultDto
    {
        public string Date { get; set; }
        public string? Time { get; set; }
        public Guid? TeamId { get; set; }
        public string? Team { get; set; }
        public Guid? CompetitionId { get; set; }
        public string? Competition { get; set; }
    }
}
