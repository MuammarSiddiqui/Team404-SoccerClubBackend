using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Dtos.OrderItem
{
    public class OrderItemDto
    {
        public Guid? Id { get; set; }
        public Guid? OrderId { get; set; }
        public int? Quantity { get; set; }
        public Guid? ProductId { get; set; }
    }
}
