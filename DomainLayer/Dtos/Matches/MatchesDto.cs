

namespace DomainLayer.Dtos.Matches
{
    public class MatchesDto
    {
        public Guid? Id { get; set; }
        public DateTime DateTime { get; set; }
        public Guid? TeamId { get; set; }
        public Guid? CompetitionId { get; set; }
        public string? Stadium { get; set; }
    }
}
