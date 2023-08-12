using ApplicationLayer.Services.NewsService;
using AutoMapper;
using DomainLayer.Dtos.Product;
using DomainLayer.Dtos.News;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Team404_SoccerClubBackend.Config;
using Team404_SoccerClubBackend.Config.File;

namespace News404_SoccerClubBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {

        private readonly INewsService _service;
        private readonly IMapper _mapper;
        private readonly IFileUpload _file;

        public NewsController(IMapper mapper, INewsService service,IFileUpload file)
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
            var News = await _service.GetAll();
            return Ok(_mapper.Map<IEnumerable<NewsResultDto>>(News));
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
            var NewsResult = await _service.GetById(id);

            if (NewsResult == null) return BadRequest();

            return Ok(_mapper.Map<NewsResultDto>(NewsResult));
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Add([FromForm]NewsDto NewsDto)
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
            var NewsResult = _mapper.Map<News>(NewsDto);
            NewsResult.CreatedDate = LocalTime.GetTime();
            NewsResult.CreatedBy = UserId;
            if (NewsDto.Image != null)
            {
                NewsResult.Image = _file.Upload(NewsDto.Image, "News");
            }
            var result = await _service.Add(NewsResult);

            if (result == null) return BadRequest();

            return Ok(_mapper.Map<NewsResultDto>(result));
        }


        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Update([FromForm]NewsDto NewsDto)
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
            var ResultNew = _mapper.Map<News>(NewsDto);
            var Result = await _service.GetById((Guid)NewsDto.Id);
            ResultNew.UpdatedBy = UserId;
            ResultNew.UpdateDate = LocalTime.GetTime();
            ResultNew.CreatedBy = Result.CreatedBy;
            ResultNew.CreatedDate = Result.CreatedDate;
            if (NewsDto.Image != null)
            {
                ResultNew.Image = _file.Upload(NewsDto.Image, "News");
            }
            else
            {
                ResultNew.Image = Result.Image;
            }
            await _service.Update(_mapper.Map<News>(ResultNew));

            return Ok(NewsDto);
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
            var NewsResult = await _service.GetById(id);
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
            if (NewsResult == null) return BadRequest();
            NewsResult.UpdatedBy = UserId;
            NewsResult.UpdateDate = LocalTime.GetTime();


            var result = await _service.Remove(NewsResult);

            if (result == null) return BadRequest();

            return Ok();
        }
    }
}
