using Microsoft.AspNetCore.Http;

namespace DomainLayer.Dtos.ClubHistory
{
    public class ClubHistoryDto
    {
        public Guid? Id { get; set; }
        public DateTime? Date { get; set; }
        public string? Title { get; set; }
        public string? Title2 { get; set; }
        public string? Description { get; set; }
        public IFormFile? Image { get; set; }
    }
}
