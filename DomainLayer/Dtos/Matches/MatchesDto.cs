

namespace DomainLayer.Dtos.Matches
{
    public class MatchesDto
    {
        public Guid? Id { get; set; }
        public string Date { get; set; }
        public string? Time { get; set; }
        public Guid? TeamId { get; set; }
        public Guid? CompetitionId { get; set; }
    }
}
