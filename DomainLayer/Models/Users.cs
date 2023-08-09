using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Users : BaseModal
    {
        public string? Name { get; set; }
        public string Username { get; set; }
        public string? Email { get; set; }
        public string? ProfilePic { get; set; }
        public string? ContactNumber { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Guid? RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
