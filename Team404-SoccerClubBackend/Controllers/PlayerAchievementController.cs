using ApplicationLayer.Services.PlayerAchievementService;
using AutoMapper;
using DomainLayer.Dtos.PlayerAchievement;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Team404_SoccerClubBackend.Config;

namespace PlayerAchievement404_SoccerClubBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PlayerAchievementController : ControllerBase
    {

        private readonly IPlayerAchievementService _service;
        private readonly IMapper _mapper;

        public PlayerAchievementController(IMapper mapper, IPlayerAchievementService service)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
       
        public async Task<IActionResult> GetAll()
        {
            var PlayerAchievement = await _service.GetAll();
            return Ok(_mapper.Map<IEnumerable<PlayerAchievementResultDto>>(PlayerAchievement));
        }
        
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
       
        public async Task<IActionResult> GetByPlayerId(Guid Id)
        {
            var PlayerAchievement = await _service.GetByPlayerId(Id);
            return Ok(_mapper.Map<IEnumerable<PlayerAchievementResultDto>>(PlayerAchievement));
        }
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
       
        public async Task<IActionResult> GetByMatchId(Guid Id)
        {
            var PlayerAchievement = await _service.GetByMatchId(Id);
            return Ok(_mapper.Map<IEnumerable<PlayerAchievementResultDto>>(PlayerAchievement));
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
            var PlayerAchievementResult = await _service.GetById(id);

            if (PlayerAchievementResult == null) return BadRequest();

            return Ok(_mapper.Map<PlayerAchievementResultDto>(PlayerAchievementResult));
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Add(PlayerAchievementDto PlayerAchievementDto)
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
            var PlayerAchievementResult = _mapper.Map<PlayerAchievement>(PlayerAchievementDto);
            PlayerAchievementResult.CreatedDate = LocalTime.GetTime();
            PlayerAchievementResult.CreatedBy = UserId;
            var result = await _service.Add(PlayerAchievementResult);

            if (result == null) return BadRequest();

            return Ok(_mapper.Map<PlayerAchievementResultDto>(result));
        }


        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Update(PlayerAchievementDto PlayerAchievementDto)
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
            var ResultNew = _mapper.Map<PlayerAchievement>(PlayerAchievementDto);
            var Result = await _service.GetById((Guid)PlayerAchievementDto.Id);
            ResultNew.UpdatedBy = UserId;
            ResultNew.UpdateDate = LocalTime.GetTime();
            ResultNew.CreatedBy = Result.CreatedBy;
            ResultNew.CreatedDate = Result.CreatedDate;
            await _service.Update(_mapper.Map<PlayerAchievement>(ResultNew));

            return Ok(PlayerAchievementDto);
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
            var PlayerAchievementResult = await _service.GetById(id);
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
            if (PlayerAchievementResult == null) return BadRequest();
            PlayerAchievementResult.UpdatedBy = UserId;
            PlayerAchievementResult.UpdateDate = LocalTime.GetTime();


            var result = await _service.Remove(PlayerAchievementResult);

            if (result == null) return BadRequest();

            return Ok();
        }
    }
}
