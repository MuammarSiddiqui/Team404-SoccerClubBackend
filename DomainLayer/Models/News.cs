
using System.Reflection.Metadata.Ecma335;

namespace DomainLayer.Models
{
    public class News : BaseModal
    {
        public string? Title { get; set; }
        public string? Html { get; set; }
        public string? Image { get; set; }
    }
}
