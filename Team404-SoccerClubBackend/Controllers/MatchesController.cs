using ApplicationLayer.Services.MatchesService;
using AutoMapper;
using DomainLayer.Dtos.Matches;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Team404_SoccerClubBackend.Config;

namespace Matches404_SoccerClubBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {

        private readonly IMatchesService _service;
        private readonly IMapper _mapper;

        public MatchesController(IMapper mapper, IMatchesService service)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
       
        public async Task<IActionResult> GetAll()
        {
            var Matches = await _service.GetAll();
            return Ok(_mapper.Map<IEnumerable<MatchesResultDto>>(Matches));
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
            var MatchesResult = await _service.GetById(id);

            if (MatchesResult == null) return BadRequest();

            return Ok(_mapper.Map<MatchesResultDto>(MatchesResult));
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByTeamId(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var MatchesResult = await _service.GetByTeamId(id);

            if (MatchesResult == null) return BadRequest();

            return Ok(_mapper.Map<IEnumerable<MatchesResultDto>>(MatchesResult));
        }
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByCompetitionId(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var MatchesResult = await _service.GetByCompetitionId(id);

            if (MatchesResult == null) return BadRequest();

            return Ok(_mapper.Map<IEnumerable<MatchesResultDto>>(MatchesResult));
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Add(MatchesDto MatchesDto)
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
            var MatchesResult = _mapper.Map<Matches>(MatchesDto);
            MatchesResult.CreatedDate = LocalTime.GetTime();
            MatchesResult.CreatedBy = UserId;
            var result = await _service.Add(MatchesResult);

            if (result == null) return BadRequest();

            return Ok(_mapper.Map<MatchesResultDto>(result));
        }


        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Update(MatchesDto MatchesDto)
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
            var ResultNew = _mapper.Map<Matches>(MatchesDto);
            var Result = await _service.GetById((Guid)MatchesDto.Id);
            ResultNew.UpdatedBy = UserId;
            ResultNew.UpdateDate = LocalTime.GetTime();
            ResultNew.CreatedBy = Result.CreatedBy;
            ResultNew.CreatedDate = Result.CreatedDate;
            await _service.Update(_mapper.Map<Matches>(ResultNew));

            return Ok(MatchesDto);
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
            var MatchesResult = await _service.GetById(id);
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
            if (MatchesResult == null) return BadRequest();
            MatchesResult.UpdatedBy = UserId;
            MatchesResult.UpdateDate = LocalTime.GetTime();


            var result = await _service.Remove(MatchesResult);

            if (result == null) return BadRequest();

            return Ok();
        }
    }
}
