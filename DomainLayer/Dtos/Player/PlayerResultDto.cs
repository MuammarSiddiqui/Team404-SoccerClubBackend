
namespace DomainLayer.Dtos.Player
{
    public class PlayerResultDto : BaseResultDto
    {
        public string Name { get; set; }
        public string? Nationatilty { get; set; }
        public string? Position { get; set; }
        public DateTime? DOB { get; set; }
        public Guid? TeamId { get; set; }
        public string? Team { get; set; }
    }
}
