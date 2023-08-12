using ApplicationLayer.Services.CartService;
using ApplicationLayer.Services.ProductService;
using AutoMapper;
using DomainLayer.Dtos.Cart;
using DomainLayer.Dtos.Product;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Team404_SoccerClubBackend.Config;

namespace Cart404_SoccerClubBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {

        private readonly ICartService _service;
        private readonly IMapper _mapper;
        private readonly IProductService _product;

        public CartController(IMapper mapper, ICartService service,IProductService product)
        {
            _product = product;
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> GetAll()
        {
            var Cart = await _service.GetAll();
            return Ok(_mapper.Map<IEnumerable<CartResultDto>>(Cart));
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> GetByUserId(Guid Id)
        {
            var Cart = await _service.GetByUsersId(Id);
            return Ok(Cart);
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> GetByProductId(Guid Id)
        {
            var Cart = await _service.GetByProductId(Id);
            return Ok(_mapper.Map<IEnumerable<CartResultDto>>(Cart));
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
            var CartResult = await _service.GetById(id);

            if (CartResult == null) return BadRequest();

            return Ok(_mapper.Map<CartResultDto>(CartResult));
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Add(CartDto CartDto)
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
            var CartResult = _mapper.Map<Cart>(CartDto);
            CartResult.CreatedDate = LocalTime.GetTime();
            CartResult.CreatedBy = UserId;
            var result = await _service.Add(CartResult);
            var product = await _product.GetById((Guid)(CartResult.ProductId));
            if (result == null) return BadRequest();
            var res = _mapper.Map<CartResultDto>(result);
            res.Product = _mapper.Map<ProductResultDto>(product);
            return Ok(res);
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> AddRange(List<CartDto> lst)
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
            var list = new List<Cart>();
            foreach (var item in lst)
            {
                var CartResult = _mapper.Map<Cart>(item);
                CartResult.CreatedDate = LocalTime.GetTime();
                CartResult.CreatedBy = UserId;
                list.Add(CartResult);
            }
            var result = await _service.AddRange(list);

            if (result == null) return BadRequest();

            return Ok(_mapper.Map<IEnumerable<CartResultDto>>(result));
        }
        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> UpdateRange(List<CartDto> lst)
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
            
            var list = new List<Cart>();
            var listnew = new List<CartResultDto>();
            foreach (var item in lst)
            {
                var oldcart = await _service.GetById((Guid)item.Id);
                var CartResult = _mapper.Map<Cart>(item);
                CartResult.CreatedDate = oldcart?.CreatedDate;
                CartResult.CreatedBy = oldcart?.CreatedBy;
                CartResult.UpdateDate = LocalTime.GetTime();
                CartResult.UpdatedBy = UserId;
                list.Add(CartResult);
            }
            var result = await _service.UpdateRange(list);
            foreach (var item in result)
            {
                var data = _mapper.Map<CartResultDto>(item);
                data.Product = _mapper.Map<ProductResultDto>(await _product.GetById((Guid)item.ProductId));
                listnew.Add(data);
            }
            if (result == null) return BadRequest();

            return Ok(listnew);
        }
        
        [HttpDelete]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> EmptyCart(Guid Id)
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
            var lst = await _service.GetByUsersId(Id);
            var list = new List<Cart>();
            var listnew = new List<CartResultDto>();
            foreach (var item in lst)
            {
                var oldcart = await _service.GetById((Guid)item.Id);
                var CartResult = _mapper.Map<Cart>(item);
                CartResult.CreatedDate = oldcart?.CreatedDate;
                CartResult.CreatedBy = oldcart?.CreatedBy;
                CartResult.UpdateDate = LocalTime.GetTime();
                CartResult.UpdatedBy = UserId;
                list.Add(CartResult);
            }
            var result = await _service.RemoveRange(list);
            foreach (var item in result)
            {
                var data = _mapper.Map<CartResultDto>(item);
                data.Product = _mapper.Map<ProductResultDto>(await _product.GetById((Guid)item.ProductId));
                listnew.Add(data);
            }
            if (result == null) return BadRequest();

            return Ok(listnew);
        }


        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Update(CartDto CartDto)
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
            var ResultNew = _mapper.Map<Cart>(CartDto);
            var Result = await _service.GetById((Guid)CartDto.Id);
            ResultNew.UpdatedBy = UserId;
            ResultNew.UpdateDate = LocalTime.GetTime();
            ResultNew.CreatedBy = Result.CreatedBy;
            ResultNew.CreatedDate = Result.CreatedDate;
           var res =  await _service.Update(_mapper.Map<Cart>(ResultNew));
            var result = _mapper.Map<CartResultDto>(res);
            result.Product = _mapper.Map<ProductResultDto>(await _product.GetById((Guid)res.ProductId));
            return Ok(CartDto);
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
            var CartResult = await _service.GetById(id);
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
            if (CartResult == null) return BadRequest();
            CartResult.UpdatedBy = UserId;
            CartResult.UpdateDate = LocalTime.GetTime();


            var result = await _service.Remove(CartResult);

            if (result == null) return BadRequest();

            return Ok();
        }
    }
}
