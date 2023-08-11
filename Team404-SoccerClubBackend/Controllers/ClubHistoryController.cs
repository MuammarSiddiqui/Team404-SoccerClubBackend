using ApplicationLayer.Services.ClubHistoryService;
using AutoMapper;
using DomainLayer.Dtos.Product;
using DomainLayer.Dtos.ClubHistory;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Team404_SoccerClubBackend.Config;
using Team404_SoccerClubBackend.Config.File;

namespace ClubHistory404_SoccerClubBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClubHistoryController : ControllerBase
    {

        private readonly IClubHistoryService _service;
        private readonly IMapper _mapper;
        private readonly IFileUpload _file;

        public ClubHistoryController(IMapper mapper, IClubHistoryService service,IFileUpload file)
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
            var ClubHistory = await _service.GetAll();
            return Ok(_mapper.Map<IEnumerable<ClubHistoryResultDto>>(ClubHistory));
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
            var ClubHistoryResult = await _service.GetById(id);

            if (ClubHistoryResult == null) return BadRequest();

            return Ok(_mapper.Map<ClubHistoryResultDto>(ClubHistoryResult));
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Add([FromForm]ClubHistoryDto ClubHistoryDto)
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
            var ClubHistoryResult = _mapper.Map<ClubHistory>(ClubHistoryDto);
            ClubHistoryResult.CreatedDate = LocalTime.GetTime();
            ClubHistoryResult.CreatedBy = UserId;
            if (ClubHistoryDto.Image != null)
            {
                ClubHistoryResult.Image = _file.Upload(ClubHistoryDto.Image, "ClubHistory");
            }
            var result = await _service.Add(ClubHistoryResult);

            if (result == null) return BadRequest();

            return Ok(_mapper.Map<ClubHistoryResultDto>(result));
        }


        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Update([FromForm]ClubHistoryDto ClubHistoryDto)
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
            var ResultNew = _mapper.Map<ClubHistory>(ClubHistoryDto);
            var Result = await _service.GetById((Guid)ClubHistoryDto.Id);
            ResultNew.UpdatedBy = UserId;
            ResultNew.UpdateDate = LocalTime.GetTime();
            ResultNew.CreatedBy = Result.CreatedBy;
            ResultNew.CreatedDate = Result.CreatedDate;
            if (ClubHistoryDto.Image != null)
            {
                ResultNew.Image = _file.Upload(ClubHistoryDto.Image, "ClubHistory");
            }
            else
            {
                ResultNew.Image = Result.Image;
            }
            await _service.Update(_mapper.Map<ClubHistory>(ResultNew));

            return Ok(_mapper.Map<ClubHistoryResultDto>(ResultNew));
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
            var ClubHistoryResult = await _service.GetById(id);
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
            if (ClubHistoryResult == null) return BadRequest();
            ClubHistoryResult.UpdatedBy = UserId;
            ClubHistoryResult.UpdateDate = LocalTime.GetTime();


            var result = await _service.Remove(ClubHistoryResult);

            if (result == null) return BadRequest();

            return Ok();
        }
    }
}
