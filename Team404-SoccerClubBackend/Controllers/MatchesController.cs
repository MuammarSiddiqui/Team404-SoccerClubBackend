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
            var res = _mapper.Map<IEnumerable<MatchesResultDto>>(Matches);

            
            return Ok(res);
        }
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> GetAllWithRelationship()
        {
            var res = await _service.GetAllWithRelationship();

            
            return Ok(res);
        }
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> GetAllMatches()
        {
            var Matches = await _service.GetAllWithRelationship();
            var res = _mapper.Map<IEnumerable<MatchesResultDto>>(Matches);
            var upcoming = res.Where(x => x.DateTime.Date >= DateTime.Now.Date).ToList();
            var obj = new
            {
                Today = res.Where(x => x.DateTime.Date == DateTime.Now.Date),
                Upcoming = res.Where(x => x.DateTime.Date > DateTime.Now.Date),
                Previous = res.Where(x => x.DateTime.Date < DateTime.Now.Date),
                UpcomingRecent = upcoming.OrderByDescending(x => x.DateTime).FirstOrDefault()
            };
            return Ok(obj);
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
        public async Task<IActionResult> GetByIdWithRelationship(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var MatchesResult = await _service.GetByIdWithRelationship(id);

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
            if (MatchesDto.DateTime.Date < DateTime.Now.Date)
            {
             //   return BadRequest("Matches Cannot be scheduled on past dates");
            }
            var check = await _service.GetByCurrentDate(MatchesDto.DateTime);
            if (check != null)
            {
                return BadRequest("thers already a match fixed on " + MatchesDto.DateTime.Day);
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
            if (MatchesDto.DateTime.Date < DateTime.Now.Date)
            {
             //   return BadRequest("Matches Cannot be scheduled on past dates");
            }
            var check = await _service.GetByCurrentDate(MatchesDto.DateTime);
            if (check != null)
            {
                if (check.Id != MatchesDto.Id)
                {
                    return BadRequest("there is already a match fixed on " + MatchesDto.DateTime.Day);
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
