using DomainLayer.Dtos.Cart;
using Microsoft.AspNetCore.Http;

namespace DomainLayer.Dtos.UsersDto
{
    public class UsersDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public IFormFile? ProfilePic { get; set; }
        public string? ContactNumber { get; set; }
        public Guid? RoleId { get; set; }
    }
    public class UsersDtoWithCart
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public IFormFile? ProfilePic { get; set; }
        public string? ContactNumber { get; set; }
        public Guid? RoleId { get; set; }
        public List<CartDto>? Cart { get; set; } = new List<CartDto>();
    }
}
