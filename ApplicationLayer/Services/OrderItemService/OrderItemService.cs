using DomainLayer.Models;
using Infrastructure.Repositories.OrderItemRepository;


namespace ApplicationLayer.Services.OrderItemService
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _repository;

        public OrderItemService(IOrderItemRepository repository)
        {
            _repository = repository;
        }
        public async Task<OrderItem> Add(OrderItem OrderItem)
        {
            try
            {
                OrderItem.Active = "Y";
                var res = await _repository.Add(OrderItem);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public async Task<IEnumerable<OrderItem>> AddRange(IEnumerable<OrderItem> OrderItem)
        {
            try
            {
                foreach (var item in OrderItem)
                {
                    item.Active = "Y";
                }
                await _repository.AddRange(OrderItem);
                return OrderItem;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<OrderItem>> GetAll()
        {
            try
            {
                var OrderItem = await _repository.GetAll();
                return (from u in OrderItem.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public async Task<IEnumerable<OrderItem>> GetByProductId(Guid Id)
        {
            try
            {
                var OrderItem = await _repository.GetByProductId(Id);
                return (from u in OrderItem.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public async Task<IEnumerable<OrderItem>> GetByOrderId(Guid Id)
        {
            try
            {
                var OrderItem = await _repository.GetByOrderId(Id);
                return (from u in OrderItem.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<OrderItem> GetById(Guid id)
        {
            OrderItem res = await _repository.GetById(id);
            if (res == null || res.Active != "Y")
            {
                return null;
            }
            return res;
        }

        public async Task<OrderItem> Remove(OrderItem OrderItem)
        {
            try
            {
                OrderItem.Active = "N";
                var res = await _repository.Update(OrderItem);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<OrderItem> Update(OrderItem OrderItem)
        {
            try
            {
                OrderItem.Active = "Y";
                var res = await _repository.Update(OrderItem);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
