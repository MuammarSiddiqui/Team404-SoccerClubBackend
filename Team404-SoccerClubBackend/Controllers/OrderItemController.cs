using ApplicationLayer.Services.OrderItemService;
using ApplicationLayer.Services.ProductService;
using AutoMapper;
using DomainLayer.Dtos.OrderItem;
using DomainLayer.Dtos.Product;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Team404_SoccerClubBackend.Config;

namespace OrderItem404_SoccerClubBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {

        private readonly IOrderItemService _service;
        private readonly IMapper _mapper;
        private readonly IProductService _product;
        public OrderItemController(IMapper mapper, IOrderItemService service,IProductService product)
        {
            _mapper = mapper;
            _service = service;
            _product = product;
        }
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> GetAll()
        {
            var OrderItem = await _service.GetAll();
            return Ok(_mapper.Map<IEnumerable<OrderItemResultDto>>(OrderItem));
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> GetByOrderId(Guid Id)
        {
            var OrderItem = await _service.GetByOrderId(Id);
            var lst = new List<OrderItemResultDto>();
            foreach (var item in OrderItem)
            {
                var obj = _mapper.Map<OrderItemResultDto>(item);
               
                obj.Product = _mapper.Map<ProductResultDto>(item.Product);
                lst.Add(obj);
            }
            return Ok(lst);
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> GetByProductId(Guid Id)
        {
            var OrderItem = await _service.GetByProductId(Id);
            return Ok(_mapper.Map<IEnumerable<OrderItemResultDto>>(OrderItem));
        }


        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var OrderItemResult = await _service.GetById(id);

            if (OrderItemResult == null) return BadRequest();

            return Ok(_mapper.Map<OrderItemResultDto>(OrderItemResult));
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Add(OrderItemDto OrderItemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Guid UserId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                try
                {

                    UserId = Guid.Parse(identity.FindFirst(ClaimTypes.Name).Value.ToString());
                }
                catch (Exception)
                {

                    return Unauthorized();
                }
            }
            var OrderItemResult = _mapper.Map<OrderItem>(OrderItemDto);
            OrderItemResult.CreatedDate = LocalTime.GetTime();
            OrderItemResult.CreatedBy = UserId;
            var product = await _product.GetById((Guid)OrderItemResult.ProductId);
            int quantity = (int)(product.StockQuantity - OrderItemResult.Quantity);
            product.StockQuantity = quantity;
            await _product.Update(product);
            var result = await _service.Add(OrderItemResult);

            if (result == null) return BadRequest();

            return Ok(_mapper.Map<OrderItemResultDto>(result));
        }
        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> AddRange(IEnumerable<OrderItemDto> OrderItemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Guid UserId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                try
                {

                    UserId = Guid.Parse(identity.FindFirst(ClaimTypes.Name).Value.ToString());
                }
                catch (Exception)
                {

                    return Unauthorized();
                }
            }
            var OrderItemResult = _mapper.Map<IEnumerable<OrderItem>>(OrderItemDto);
            foreach (var item in OrderItemResult)
            {
                item.CreatedDate = LocalTime.GetTime();
                item.CreatedBy = UserId;
                item.Active = "Y";
                var product = await _product.GetById((Guid)item.ProductId);
                int quantity = (int)(product.StockQuantity - item.Quantity);
                product.StockQuantity = quantity;
                await _product.Update(product);
            };
            var result = await _service.AddRange(OrderItemResult);

            if (result == null) return BadRequest();

            return Ok(_mapper.Map<IEnumerable<OrderItemResultDto>>(result));
        }


        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Update(OrderItemDto OrderItemDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Guid UserId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                try
                {

                    UserId = Guid.Parse(identity.FindFirst(ClaimTypes.Name).Value.ToString());
                }
                catch (Exception)
                {

                    return Unauthorized();
                }
            }
            var ResultNew = _mapper.Map<OrderItem>(OrderItemDto);
            var Result = await _service.GetById((Guid)OrderItemDto.Id);
            ResultNew.UpdatedBy = UserId;
            ResultNew.UpdateDate = LocalTime.GetTime();
            ResultNew.CreatedBy = Result.CreatedBy;
            ResultNew.CreatedDate = Result.CreatedDate;
            await _service.Update(_mapper.Map<OrderItem>(ResultNew));

            return Ok(OrderItemDto);
        }


        [HttpDelete]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> Remove(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var OrderItemResult = await _service.GetById(id);
            Guid UserId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                try
                {

                    UserId = Guid.Parse(identity.FindFirst(ClaimTypes.Name).Value.ToString());
                }
                catch (Exception)
                {

                    return Unauthorized();
                }
            }
            if (OrderItemResult == null) return BadRequest();
            OrderItemResult.UpdatedBy = UserId;
            OrderItemResult.UpdateDate = LocalTime.GetTime();


            var result = await _service.Remove(OrderItemResult);

            if (result == null) return BadRequest();

            return Ok();
        }
    }
}
