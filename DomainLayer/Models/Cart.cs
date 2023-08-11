namespace DomainLayer.Models
{
    public class Cart : BaseModal
    {
        public Guid? UsersId { get; set; }
        public Users? Users { get; set; }
        public int? Quantity { get; set; }
        public Guid? ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
