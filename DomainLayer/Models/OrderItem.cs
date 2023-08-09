﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class OrderItem : BaseModal
    {
        public Guid? OrderId { get; set; }
        public Order? Order { get; set; }
        public int? Quantity { get; set; }
        public Guid? ProductId { get; set; }
        public Product? Product { get; set; }
        public decimal? UnitPrice { get; set; }
    }

}
