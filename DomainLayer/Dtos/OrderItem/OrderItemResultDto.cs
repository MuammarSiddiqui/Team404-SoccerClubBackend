﻿

using DomainLayer.Dtos.Product;

namespace DomainLayer.Dtos.OrderItem
{
    public class OrderItemResultDto : BaseResultDto
    {
        public Guid? OrderId { get; set; }
        public string? Order { get; set; }
        public int? Quantity { get; set; }
        public Guid? ProductId { get; set; }
        public ProductResultDto? Product { get; set; }
    }
}
