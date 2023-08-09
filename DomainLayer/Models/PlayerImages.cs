
namespace DomainLayer.Models
{
    public class PlayerImages : BaseModal
    {
        public Guid? PlayerId { get; set; }
        public Player? Player { get; set; }
        public string? ImageUrl { get; set; }
        public string? Caption { get; set; }
    }
}
