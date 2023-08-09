namespace DomainLayer.Dtos.PlayerAchievement
{
    public class PlayerAchievementDto
    {
        public Guid? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? DateRecieved { get; set; }
        public Guid? PlayerId { get; set; }
        public Guid? MatchesId { get; set; }
    }
}
