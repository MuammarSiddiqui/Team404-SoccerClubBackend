using ApplicationLayer.Services.TeamStatsService;
using AutoMapper;
using DomainLayer.Dtos.TeamStats;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Team404_SoccerClubBackend.Config;

namespace Team404_SoccerClubBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TeamStatsController : ControllerBase
    {

        private readonly ITeamStatsService _service;
        private readonly IMapper _mapper;

        public TeamStatsController(IMapper mapper, ITeamStatsService service)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
       
        public async Task<IActionResult> GetAll()
        {
            var TeamStats = await _service.GetAll();
            return Ok(_mapper.Map<IEnumerable<TeamStatsResultDto>>(TeamStats));
        }
        
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
       
        public async Task<IActionResult> GetByMatchId(Guid Id)
        {
            var TeamStats = await _service.GetByMatchId(Id);
            return Ok(_mapper.Map<IEnumerable<TeamStatsResultDto>>(TeamStats));
        }
        
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
       
        public async Task<IActionResult> GetByTeamId(Guid Id)
        {
            var TeamStats = await _service.GetByTeamId(Id);
            return Ok(_mapper.Map<IEnumerable<TeamStatsResultDto>>(TeamStats));
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
            var TeamStatsResult = await _service.GetById(id);

            if (TeamStatsResult == null) return BadRequest();

            return Ok(_mapper.Map<TeamStatsResultDto>(TeamStatsResult));
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByMatchAndTeam(Guid MatchId,Guid TeamId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var TeamStatsResult = await _service.GetByMatchAndTeam(MatchId, TeamId);

            if (TeamStatsResult == null) return Ok(null);

            return Ok(_mapper.Map<TeamStatsResultDto>(TeamStatsResult));
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Add(TeamStatsDto TeamStatsDto)
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
            var TeamStatsResult = _mapper.Map<TeamStats>(TeamStatsDto);
            TeamStatsResult.CreatedDate = LocalTime.GetTime();
            TeamStatsResult.CreatedBy = UserId;
            var result = await _service.Add(TeamStatsResult);

            if (result == null) return BadRequest();

            return Ok(_mapper.Map<TeamStatsResultDto>(result));
        }


        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Update(TeamStatsDto TeamStatsDto)
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
            var ResultNew = _mapper.Map<TeamStats>(TeamStatsDto);
            var Result = await _service.GetById((Guid)TeamStatsDto.Id);
            ResultNew.UpdatedBy = UserId;
            ResultNew.UpdateDate = LocalTime.GetTime();
            ResultNew.CreatedBy = Result.CreatedBy;
            ResultNew.CreatedDate = Result.CreatedDate;
            await _service.Update(_mapper.Map<TeamStats>(ResultNew));

            return Ok(TeamStatsDto);
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
            var TeamStatsResult = await _service.GetById(id);
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
            if (TeamStatsResult == null) return BadRequest();
            TeamStatsResult.UpdatedBy = UserId;
            TeamStatsResult.UpdateDate = LocalTime.GetTime();


            var result = await _service.Remove(TeamStatsResult);

            if (result == null) return BadRequest();

            return Ok();
        }
    }
}
