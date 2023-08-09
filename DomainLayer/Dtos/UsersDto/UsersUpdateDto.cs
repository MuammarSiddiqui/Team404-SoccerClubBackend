using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Dtos.UsersDto
{
    public class UserUpdateDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        [Required(ErrorMessage = "Username Is Required")]
        public string Username { get; set; }
        [EmailAddress(ErrorMessage = "Please Enter a valid email")]
        public string? Email { get; set; }
        public IFormFile? ProfilePic { get; set; }
        public string? ContactNumber { get; set; }
        public string? Passsword { get; set; }
        public Guid? RoleId { get; set; }
    }
}
