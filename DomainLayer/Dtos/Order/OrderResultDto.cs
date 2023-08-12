using DomainLayer.Dtos.UserAddresses;
using DomainLayer.Dtos.UsersDto;

namespace DomainLayer.Dtos.Order
{
    public class OrderResultDto : BaseResultDto
    {
        public Guid? UsersId { get; set; }
        public UsersResultDto? Users { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid? UserAddressesId { get; set; }
        public string? Status { get; set; }
        public UserAddressesResultDto? UserAddresses { get; set; }
    }
}
