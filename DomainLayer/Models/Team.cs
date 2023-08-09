
namespace DomainLayer.Models
{
    public class Team : BaseModal
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Country { get; set; }
        public string? Logo { get; set; }
    }
}
