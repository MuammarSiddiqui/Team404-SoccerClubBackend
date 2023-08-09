using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class ProductCategory : BaseModal
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }

}
