using ApplicationLayer.Services.MatchStatsService;
using AutoMapper;
using DomainLayer.Dtos.MatchStats;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Team404_SoccerClubBackend.Config;

namespace MatchStats404_SoccerClubBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MatchStatsController : ControllerBase
    {

        private readonly IMatchStatsService _service;
        private readonly IMapper _mapper;

        public MatchStatsController(IMapper mapper, IMatchStatsService service)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
       
        public async Task<IActionResult> GetAll()
        {
            var MatchStats = await _service.GetAll();
            return Ok(_mapper.Map<IEnumerable<MatchStatsResultDto>>(MatchStats));
        }
        
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
       
        public async Task<IActionResult> GetByMatchId(Guid Id)
        {
            var MatchStats = await _service.GetByMatchId(Id);
            return Ok(_mapper.Map<IEnumerable<MatchStatsResultDto>>(MatchStats));
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
            var MatchStatsResult = await _service.GetById(id);

            if (MatchStatsResult == null) return BadRequest();

            return Ok(_mapper.Map<MatchStatsResultDto>(MatchStatsResult));
        }


        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Add(MatchStatsDto MatchStatsDto)
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
            var MatchStatsResult = _mapper.Map<MatchStats>(MatchStatsDto);
            MatchStatsResult.CreatedDate = LocalTime.GetTime();
            MatchStatsResult.CreatedBy = UserId;
            var result = await _service.Add(MatchStatsResult);

            if (result == null) return BadRequest();

            return Ok(_mapper.Map<MatchStatsResultDto>(result));
        }


        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Update(MatchStatsDto MatchStatsDto)
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
            var ResultNew = _mapper.Map<MatchStats>(MatchStatsDto);
            var Result = await _service.GetById((Guid)MatchStatsDto.Id);
            ResultNew.UpdatedBy = UserId;
            ResultNew.UpdateDate = LocalTime.GetTime();
            ResultNew.CreatedBy = Result.CreatedBy;
            ResultNew.CreatedDate = Result.CreatedDate;
            await _service.Update(_mapper.Map<MatchStats>(ResultNew));

            return Ok(MatchStatsDto);
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
            var MatchStatsResult = await _service.GetById(id);
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
            if (MatchStatsResult == null) return BadRequest();
            MatchStatsResult.UpdatedBy = UserId;
            MatchStatsResult.UpdateDate = LocalTime.GetTime();


            var result = await _service.Remove(MatchStatsResult);

            if (result == null) return BadRequest();

            return Ok();
        }
    }
}
