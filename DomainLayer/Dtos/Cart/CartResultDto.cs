
using DomainLayer.Dtos.Product;
using DomainLayer.Models;

namespace DomainLayer.Dtos.Cart
{
    public class CartResultDto : BaseResultDto
    {
        public Guid? UsersId { get; set; }
        public string? Users { get; set; }
        public int? Quantity { get; set; }
        public Guid? ProductId { get; set; }
        public ProductResultDto? Product { get; set; }
    }
}
