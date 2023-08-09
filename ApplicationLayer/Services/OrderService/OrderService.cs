using DomainLayer.Models;
using Infrastructure.Repositories.OrderRepository;


namespace ApplicationLayer.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }
        public async Task<Order> Add(Order Order)
        {
            try
            {
                Order.Active = "Y";
                var res = await _repository.Add(Order);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            try
            {
                var Order = await _repository.GetAll();
                return (from u in Order.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<Order>> GetByUserId(Guid Id)
        {
            try
            {
                var Order = await _repository.GetByUserId(Id);
                return (from u in Order.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Order> GetById(Guid id)
        {
            Order res = await _repository.GetById(id);
            if (res == null || res.Active != "Y")
            {
                return null;
            }
            return res;
        }

        public async Task<Order> Remove(Order Order)
        {
            try
            {
                Order.Active = "N";
                var res = await _repository.Update(Order);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Order> Update(Order Order)
        {
            try
            {
                Order.Active = "Y";
                var res = await _repository.Update(Order);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
