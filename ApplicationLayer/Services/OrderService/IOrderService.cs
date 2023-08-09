﻿using DomainLayer.Models;

namespace ApplicationLayer.Services.OrderService
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAll();
        Task<Order> GetById(Guid id);
        Task<Order> Add(Order Order);
        Task<Order> Update(Order Order);
        Task<Order> Remove(Order Order);
        Task<IEnumerable<Order>> GetByUserId(Guid id);
    }
}
