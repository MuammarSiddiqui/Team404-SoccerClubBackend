using Microsoft.AspNetCore.Http;

namespace DomainLayer.Dtos.Team
{
    public class TeamDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Country { get; set; }
        public IFormFile? Logo { get; set; }
    }
}
