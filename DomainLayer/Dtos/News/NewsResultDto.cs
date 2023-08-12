
using Microsoft.AspNetCore.Http;

namespace DomainLayer.Dtos.News
{
    public class NewsResultDto : BaseResultDto
    {
        public string? Title { get; set; }
        public string? Html { get; set; }
        public string? Image { get; set; }
    }
}
