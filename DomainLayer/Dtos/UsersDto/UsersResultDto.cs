using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Dtos.UsersDto
{
    public class UsersResultDto : BaseResultDto
    {
        public string? Name { get; set; }
        public string Username { get; set; }
        public string? Email { get; set; }
        public string? ContactNumber { get; set; }
        public string? ProfilePic { get; set; }
        public Guid? RoleId { get; set; }
        public string? Role { get; set; }
    }
}
