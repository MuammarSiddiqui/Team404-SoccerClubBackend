using ApplicationLayer.Services.PlayerStatsService;
using AutoMapper;
using DomainLayer.Dtos.PlayerStats;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Team404_SoccerClubBackend.Config;

namespace PlayerStats404_SoccerClubBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PlayerStatsController : ControllerBase
    {

        private readonly IPlayerStatsService _service;
        private readonly IMapper _mapper;

        public PlayerStatsController(IMapper mapper, IPlayerStatsService service)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
       
        public async Task<IActionResult> GetAll()
        {
            var PlayerStats = await _service.GetAll();
            return Ok(_mapper.Map<IEnumerable<PlayerStatsResultDto>>(PlayerStats));
        }
        
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
       
        public async Task<IActionResult> GetByPlayerId(Guid Id)
        {
            var PlayerStats = await _service.GetByPlayerId(Id);
            return Ok(_mapper.Map<IEnumerable<PlayerStatsResultDto>>(PlayerStats));
        }
        
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
       
        public async Task<IActionResult> GetByMatchId(Guid Id)
        {
            var PlayerStats = await _service.GetByMatchId(Id);
            return Ok(_mapper.Map<IEnumerable<PlayerStatsResultDto>>(PlayerStats));
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
            var PlayerStatsResult = await _service.GetById(id);

            if (PlayerStatsResult == null) return BadRequest();

            return Ok(_mapper.Map<PlayerStatsResultDto>(PlayerStatsResult));
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Add(PlayerStatsDto PlayerStatsDto)
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
            var PlayerStatsResult = _mapper.Map<PlayerStats>(PlayerStatsDto);
            PlayerStatsResult.CreatedDate = LocalTime.GetTime();
            PlayerStatsResult.CreatedBy = UserId;
            var result = await _service.Add(PlayerStatsResult);

            if (result == null) return BadRequest();

            return Ok(_mapper.Map<PlayerStatsResultDto>(result));
        }


        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Update(PlayerStatsDto PlayerStatsDto)
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
            var ResultNew = _mapper.Map<PlayerStats>(PlayerStatsDto);
            var Result = await _service.GetById((Guid)PlayerStatsDto.Id);
            ResultNew.UpdatedBy = UserId;
            ResultNew.UpdateDate = LocalTime.GetTime();
            ResultNew.CreatedBy = Result.CreatedBy;
            ResultNew.CreatedDate = Result.CreatedDate;
            await _service.Update(_mapper.Map<PlayerStats>(ResultNew));

            return Ok(PlayerStatsDto);
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
            var PlayerStatsResult = await _service.GetById(id);
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
            if (PlayerStatsResult == null) return BadRequest();
            PlayerStatsResult.UpdatedBy = UserId;
            PlayerStatsResult.UpdateDate = LocalTime.GetTime();


            var result = await _service.Remove(PlayerStatsResult);

            if (result == null) return BadRequest();

            return Ok();
        }
    }
}
