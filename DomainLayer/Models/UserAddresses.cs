
namespace DomainLayer.Models
{
    public class UserAddresses : BaseModal
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Address1 { get; set; }
        public string? ZipCode { get; set; }
        public Guid? UsersId { get; set; }
        public Users? Users { get; set; }
    }
}
