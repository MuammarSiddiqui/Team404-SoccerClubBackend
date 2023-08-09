namespace DomainLayer.Dtos.PlayerImages
{
    public class PlayerImagesResultDto : BaseResultDto
    {
        public Guid? PlayerId { get; set; }
        public string? Player { get; set; }
        public string? ImageUrl { get; set; }
        public string? Caption { get; set; }
    }
}
