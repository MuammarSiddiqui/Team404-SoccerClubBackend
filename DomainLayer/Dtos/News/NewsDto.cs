
using Microsoft.AspNetCore.Http;

namespace DomainLayer.Dtos.News
{
    public class NewsDto
    {
        public Guid? Id { get; set; }
        public string? Title { get; set; }
        public string? Html { get; set; }
        public IFormFile? Image { get; set; }
    }
}
