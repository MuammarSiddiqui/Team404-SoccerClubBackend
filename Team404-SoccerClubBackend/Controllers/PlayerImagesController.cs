using ApplicationLayer.Services.PlayerImagesService;
using AutoMapper;
using Azure.Core;
using DomainLayer.Dtos.PlayerImages;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Team404_SoccerClubBackend.Config;
using Team404_SoccerClubBackend.Config.File;

namespace PlayerImages404_SoccerClubBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PlayerImagesController : ControllerBase
    {

        private readonly IPlayerImagesService _service;
        private readonly IMapper _mapper;
        private readonly IFileUpload _file;

        public PlayerImagesController(IMapper mapper, IPlayerImagesService service, IFileUpload file)
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
            var PlayerImages = await _service.GetAll();
            return Ok(_mapper.Map<IEnumerable<PlayerImagesResultDto>>(PlayerImages));
        }
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> GetByPlayerId(Guid Id)
        {
            var PlayerImages = await _service.GetByPlayerId(Id);
            return Ok(_mapper.Map<IEnumerable<PlayerImagesResultDto>>(PlayerImages));
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
            var PlayerImagesResult = await _service.GetById(id);

            if (PlayerImagesResult == null) return BadRequest();

            return Ok(_mapper.Map<PlayerImagesResultDto>(PlayerImagesResult));
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Add([FromForm] PlayerImagesDto PlayerImagesDto)
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
            var PlayerImagesResult = _mapper.Map<PlayerImages>(PlayerImagesDto);
            PlayerImagesResult.CreatedDate = LocalTime.GetTime();
            PlayerImagesResult.CreatedBy = UserId;
            if (PlayerImagesDto.ImageUrl != null)
            {
                PlayerImagesResult.ImageUrl = _file.Upload(PlayerImagesDto.ImageUrl, "PlayerImages");
            }
            var result = await _service.Add(PlayerImagesResult);

            if (result == null) return BadRequest();

            return Ok(_mapper.Map<PlayerImagesResultDto>(result));
        }


        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> AddRange([FromForm] IEnumerable<PlayerImagesDto> req)
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
            var lst = new List<PlayerImages>();
            foreach (var PlayerImagesDto in req)
            {
                var PlayerImagesResult = _mapper.Map<PlayerImages>(PlayerImagesDto);
                PlayerImagesResult.CreatedDate = LocalTime.GetTime();
                PlayerImagesResult.CreatedBy = UserId;
                if (PlayerImagesDto.ImageUrl != null)
                {
                    PlayerImagesResult.ImageUrl = _file.Upload(PlayerImagesDto.ImageUrl, "PlayerImages");
                }
                lst.Add(PlayerImagesResult);
            }
            var result = await _service.AddRange(lst);

            if (result == null) return BadRequest();

            return Ok(_mapper.Map<IEnumerable<PlayerImagesResultDto>>(result));
        }


        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Update([FromForm] PlayerImagesDto PlayerImagesDto)
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
            var ResultNew = _mapper.Map<PlayerImages>(PlayerImagesDto);
            var Result = await _service.GetById((Guid)PlayerImagesDto.Id);
            ResultNew.UpdatedBy = UserId;
            ResultNew.UpdateDate = LocalTime.GetTime();
            ResultNew.CreatedBy = Result.CreatedBy;
            ResultNew.CreatedDate = Result.CreatedDate;
            if (PlayerImagesDto.ImageUrl != null)
            {
                ResultNew.ImageUrl = _file.Upload(PlayerImagesDto.ImageUrl, "PlayerImages");
            }
            await _service.Update(_mapper.Map<PlayerImages>(ResultNew));

            return Ok(PlayerImagesDto);
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
            var PlayerImagesResult = await _service.GetById(id);
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
            if (PlayerImagesResult == null) return BadRequest();
            PlayerImagesResult.UpdatedBy = UserId;
            PlayerImagesResult.UpdateDate = LocalTime.GetTime();


            var result = await _service.Remove(PlayerImagesResult);

            if (result == null) return BadRequest();

            return Ok();
        }
    }
}
