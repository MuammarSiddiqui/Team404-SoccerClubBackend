
namespace DomainLayer.Models
{
    public class Order : BaseModal
    {
        public Guid? UsersId { get; set; }
        public Users? Users { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }

}
