namespace DomainLayer.Dtos.Order
{
    public class OrderResultDto : BaseResultDto
    {
        public Guid? UsersId { get; set; }
        public string? Users { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
