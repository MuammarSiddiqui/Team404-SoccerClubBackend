

namespace DomainLayer.Dtos.PlayerAchievement
{
    public class PlayerAchievementResultDto : BaseResultDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? DateRecieved { get; set; }
        public Guid? PlayerId { get; set; }
        public string? Player { get; set; }
        public Guid? MatchesId { get; set; }
        public string? Matches { get; set; }
    }
}
