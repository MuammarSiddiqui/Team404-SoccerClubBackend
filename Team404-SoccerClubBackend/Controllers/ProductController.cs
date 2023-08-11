using ApplicationLayer.Services.ProductService;
using AutoMapper;
using AutoMapper.Execution;
using DomainLayer.Dtos.PlayerImages;
using DomainLayer.Dtos.Product;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;
using Team404_SoccerClubBackend.Config;
using Team404_SoccerClubBackend.Config.File;

namespace Product404_SoccerClubBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _service;
        private readonly IMapper _mapper;
        private readonly IFileUpload _file;

        public ProductController(IMapper mapper, IProductService service, IFileUpload file)
        {
            _file = file;
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> GetAll()
        {
            var Product = await _service.GetAll();
            return Ok(_mapper.Map<IEnumerable<ProductResultDto>>(Product));
        }
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> GetAllWithRelationship()
        {
            var Product = await _service.GetAllWithRelationship();
            return Ok(Product);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetProducts(
        string name = null,
        decimal? minPrice = null,
        decimal? maxPrice = null)
        {
            var query = await _service.GetAllWithRelationship();
            var res = new List<ProductResultDto>();
            if (!string.IsNullOrEmpty(name))
            {
                var text = name.Trim();
                string[] str = text.Split(" ");
                foreach (var item in str)
                {
                    
                    var record = query.Where(x => (x.Name?.ToLower().Contains(item.ToLower())) ?? false || (x.Description?.ToLower().Contains(item.ToLower()) ?? false)).ToList();
                    res.AddRange(record);
                }
            }

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.Price >= minPrice.Value);
                res.AddRange(query);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= maxPrice.Value);
                res.AddRange(query);
            }

            return Ok(res.DistinctBy(x=>x.Id).ToList());
        }



        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> GetRandomRecords()
        {
            var Product = await _service.GetAllWithRelationship();
            List<ProductResultDto> randomRecords = GetRandomRecords<ProductResultDto>((List<ProductResultDto>)Product, 4); 

            return Ok(Product);
        }

        public static List<TEntity> GetRandomRecords<TEntity>(List<TEntity> source, int count)
        {
            var totalCount = source.Count;

            var random = new Random();
            var randomIndices = Enumerable.Range(0, totalCount).OrderBy(_ => random.Next()).Take(count);

            return source.Where((_, index) => randomIndices.Contains(index)).ToList();
        }





        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]


        public async Task<IActionResult> GetByCategoryId(Guid Id)
        {
            var Product = await _service.GetByCategoryId(Id);
            return Ok(_mapper.Map<IEnumerable<ProductResultDto>>(Product));
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
            var ProductResult = await _service.GetById(id);

            if (ProductResult == null) return BadRequest();

            return Ok(_mapper.Map<ProductResultDto>(ProductResult));
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdWithCategory(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ProductResult = await _service.GetByIdWithCategory(id);

            if (ProductResult == null) return BadRequest();

            return Ok(ProductResult);
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Add([FromForm] ProductDto ProductDto)
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
            var ProductResult = _mapper.Map<Product>(ProductDto);
            ProductResult.CreatedDate = LocalTime.GetTime();
            ProductResult.CreatedBy = UserId;
            if (ProductDto.ImageUrl != null)
            {
                ProductResult.ImageUrl = _file.Upload(ProductDto.ImageUrl, "Product");
            }
            var result = await _service.Add(ProductResult);

            if (result == null) return BadRequest();

            return Ok(_mapper.Map<ProductResultDto>(result));
        }


        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Update([FromForm] ProductDto ProductDto)
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
            var ResultNew = _mapper.Map<Product>(ProductDto);
            var Result = await _service.GetById((Guid)ProductDto.Id);
            ResultNew.UpdatedBy = UserId;
            ResultNew.UpdateDate = LocalTime.GetTime();
            ResultNew.CreatedBy = Result.CreatedBy;
            ResultNew.CreatedDate = Result.CreatedDate;
            if (ProductDto.ImageUrl != null)
            {
                ResultNew.ImageUrl = _file.Upload(ProductDto.ImageUrl, "Product");
            }
            else
            {
                ResultNew.ImageUrl = Result.ImageUrl;
            }
            await _service.Update(_mapper.Map<Product>(ResultNew));

            return Ok(ProductDto);
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
            var ProductResult = await _service.GetById(id);
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
            if (ProductResult == null) return BadRequest();
            ProductResult.UpdatedBy = UserId;
            ProductResult.UpdateDate = LocalTime.GetTime();


            var result = await _service.Remove(ProductResult);

            if (result == null) return BadRequest();

            return Ok();
        }
    }
}
