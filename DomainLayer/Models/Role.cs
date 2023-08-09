using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Role : BaseModal
    {
        public string? RoleName { get; set; }
        public string? Description { get; set; }
        public ICollection<Users>? Users { get; set; }
    }
}
