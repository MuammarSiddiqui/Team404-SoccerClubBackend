using DomainLayer.Models;

namespace DomainLayer.Dtos.Cart
{
    public class CartDto
    {
        public Guid? Id { get; set; }
        public Guid? UsersId { get; set; }
        public int? Quantity { get; set; }
        public Guid? ProductId { get; set; }
    }
}
