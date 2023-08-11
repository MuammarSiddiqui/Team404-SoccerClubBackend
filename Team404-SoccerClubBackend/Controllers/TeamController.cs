using ApplicationLayer.Services.TeamService;
using AutoMapper;
using DomainLayer.Dtos.SoccerInfo;
using DomainLayer.Dtos.Team;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Team404_SoccerClubBackend.Config;
using Team404_SoccerClubBackend.Config.File;

namespace Team404_SoccerClubBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {

        private readonly ITeamService _service;
        private readonly IMapper _mapper;
        private readonly IFileUpload _file;

        public TeamController(IMapper mapper, ITeamService service,IFileUpload file)
        {
            _file= file;
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
       
        public async Task<IActionResult> GetAll()
        {
            var Team = await _service.GetAll();
            var res = _mapper.Map<IEnumerable<TeamResultDto>>(Team);
            res = res.OrderByDescending(x => x.Club).ToList();
            return Ok(res);
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
            var TeamResult = await _service.GetById(id);

            if (TeamResult == null) return BadRequest();

            return Ok(_mapper.Map<TeamResultDto>(TeamResult));
        }
        
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMyTeam()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var TeamResult = await _service.GetMyTeam();

            if (TeamResult == null) return BadRequest();

            return Ok(_mapper.Map<TeamResultDto>(TeamResult));
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Add([FromForm]TeamDto TeamDto)
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
            var TeamResult = _mapper.Map<Team>(TeamDto);
            TeamResult.CreatedDate = LocalTime.GetTime();
            TeamResult.CreatedBy = UserId;
            if (TeamDto.Logo != null)
            {
                TeamResult.Logo = _file.Upload(TeamDto.Logo, "Team");
            }
            var result = await _service.Add(TeamResult);

            if (result == null) return BadRequest();

            return Ok(_mapper.Map<TeamResultDto>(result));
        }


        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Update([FromForm]TeamDto TeamDto)
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
            var ResultNew = _mapper.Map<Team>(TeamDto);
            var Result = await _service.GetById((Guid)TeamDto.Id);
            ResultNew.UpdatedBy = UserId;
            ResultNew.UpdateDate = LocalTime.GetTime();
            ResultNew.CreatedBy = Result.CreatedBy;
            ResultNew.CreatedDate = Result.CreatedDate;
            if (TeamDto.Logo != null)
            {
                ResultNew.Logo = _file.Upload(TeamDto.Logo, "Team");
            }
            else
            {
                ResultNew.Logo = Result.Logo;
            }
            await _service.Update(_mapper.Map<Team>(ResultNew));

            return Ok(TeamDto);
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
            var TeamResult = await _service.GetById(id);
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
            if (TeamResult == null) return BadRequest();
            TeamResult.UpdatedBy = UserId;
            TeamResult.UpdateDate = LocalTime.GetTime();


            var result = await _service.Remove(TeamResult);

            if (result == null) return BadRequest();

            return Ok();
        }
    }
}
