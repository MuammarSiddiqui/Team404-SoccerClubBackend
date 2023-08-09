namespace DomainLayer.Dtos
{
    public class BaseResultDto
    {
        public Guid? Id { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? Active { get; set; }
    }
}
