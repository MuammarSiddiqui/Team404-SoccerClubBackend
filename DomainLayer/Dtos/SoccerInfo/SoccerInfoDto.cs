using Microsoft.AspNetCore.Http;

namespace DomainLayer.Dtos.SoccerInfo
{
    public class SoccerInfoDto
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public string? Content { get; set; }
        public IFormFile? Image { get; set; }
    }
}
