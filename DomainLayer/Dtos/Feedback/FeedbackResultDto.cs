using DomainLayer.Models;

namespace DomainLayer.Dtos.Feedback
{
    public class FeedbackResultDto : BaseModal
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Comments { get; set; }
    }
}
