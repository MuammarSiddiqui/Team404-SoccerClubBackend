
namespace DomainLayer.Models
{
    public class Player : BaseModal
    {
        public string Name { get; set; }
        public string? Nationatilty { get; set; }
        public string? Position { get; set; }
        public string? ProfilePic { get; set; }
        public DateTime? DOB { get; set; }
        public Guid? TeamId { get; set; }
        public Team? Team { get; set; }
        public List<PlayerImages>? PlayerImages { get; set; } = new List<PlayerImages>();
        public List<PlayerAchievement>? PlayerAchievements { get; set; } = new List<PlayerAchievement>();
        public List<PlayerStats>? PlayerStats { get; set; } = new List<PlayerStats>();
    }
}
