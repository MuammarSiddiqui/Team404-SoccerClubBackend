namespace DomainLayer.Dtos.UserAddresses
{
    public class UserAddressesResultDto : BaseResultDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Address1 { get; set; }
        public string? ZipCode { get; set; }
        public Guid? UsersId { get; set; }
        public string? Users { get; set; }
    }
}
