using AutoMapper;
using DomainLayer.Dtos.Order;
using DomainLayer.Dtos.UserAddresses;
using DomainLayer.Dtos.UsersDto;
using DomainLayer.Models;
using Infrastructure.Repositories.OrderRepository;


namespace ApplicationLayer.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository repository, IMapper mapper)
        {
            _mapper = mapper;
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
        public async Task<IEnumerable<OrderResultDto>> GetByUserId(Guid Id)
        {
            try
            {
                var Order = await _repository.GetByUserId(Id);
                var lst = new List<OrderResultDto>();
                foreach (var item in Order)
                {
                    if (item.Active == "Y")
                    {
                        var obj = _mapper.Map<OrderResultDto>(item);
                        if (item.UserAddresses != null)
                        {
                            if (item.UserAddresses.Active == "Y")
                            {
                                obj.UserAddresses = _mapper.Map<UserAddressesResultDto>(item.UserAddresses);

                            }
                            if (item.Users.Active == "Y")
                            {
                                obj.Users = _mapper.Map<UsersResultDto>(item.Users);
                            }

                        }
                        lst.Add(obj);
                    }
                }
                return lst;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<OrderResultDto> GetByIdWithRelationship(Guid Id)
        {
            try
            {
                var Order = await _repository.GetByIdWithRelationship(Id);
                if (Order == null || Order.Active != "Y")
                {
                    return null;
                }
                var obj = _mapper.Map<OrderResultDto>(Order);
                if (Order.UserAddresses != null)
                {

                    obj.UserAddresses = _mapper.Map<UserAddressesResultDto>(Order.UserAddresses);
                }
                if (obj.Users.Active == "Y")
                {
                    obj.Users = _mapper.Map<UsersResultDto>(Order.Users);
                }
                return obj;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<OrderResultDto>> GetAllWithRelationship()
        {
            try
            {
                var Order = await _repository.GetAllWithRelationship();
                var lst = new List<OrderResultDto>();
                foreach (var item in Order)
                {
                    if (item.Active == "Y")
                    {
                        var obj = _mapper.Map<OrderResultDto>(item);
                        if (item.UserAddresses != null)
                        {
                            if (item.UserAddresses.Active == "Y")
                            {
                                obj.UserAddresses = _mapper.Map<UserAddressesResultDto>(item.UserAddresses);
                            }

                            if (item.Users.Active == "Y")
                            {
                                obj.Users = _mapper.Map<UsersResultDto>(item.Users);
                            }
                        }
                        lst.Add(obj);
                    }
                }
                return lst;
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
