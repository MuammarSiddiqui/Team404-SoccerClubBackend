
namespace DomainLayer.Dtos.Order
{
    public class OrderDto
    {
        public Guid? Id { get; set; }
        public Guid? UsersId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
