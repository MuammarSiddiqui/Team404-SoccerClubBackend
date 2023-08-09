using ApplicationLayer.Services.SoccerInfoService;
using AutoMapper;
using DomainLayer.Dtos.Product;
using DomainLayer.Dtos.SoccerInfo;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Team404_SoccerClubBackend.Config;
using Team404_SoccerClubBackend.Config.File;

namespace SoccerInfo404_SoccerClubBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SoccerInfoController : ControllerBase
    {

        private readonly ISoccerInfoService _service;
        private readonly IMapper _mapper;
        private readonly IFileUpload _file;

        public SoccerInfoController(IMapper mapper, ISoccerInfoService service,IFileUpload file)
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
            var SoccerInfo = await _service.GetAll();
            return Ok(_mapper.Map<IEnumerable<SoccerInfoResultDto>>(SoccerInfo));
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
            var SoccerInfoResult = await _service.GetById(id);

            if (SoccerInfoResult == null) return BadRequest();

            return Ok(_mapper.Map<SoccerInfoResultDto>(SoccerInfoResult));
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Add([FromForm]SoccerInfoDto SoccerInfoDto)
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
            var SoccerInfoResult = _mapper.Map<SoccerInfo>(SoccerInfoDto);
            SoccerInfoResult.CreatedDate = LocalTime.GetTime();
            SoccerInfoResult.CreatedBy = UserId;
            if (SoccerInfoDto.Image != null)
            {
                SoccerInfoResult.Image = _file.Upload(SoccerInfoDto.Image, "SoccerInfo");
            }
            var result = await _service.Add(SoccerInfoResult);

            if (result == null) return BadRequest();

            return Ok(_mapper.Map<SoccerInfoResultDto>(result));
        }


        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Update([FromForm]SoccerInfoDto SoccerInfoDto)
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
            var ResultNew = _mapper.Map<SoccerInfo>(SoccerInfoDto);
            var Result = await _service.GetById((Guid)SoccerInfoDto.Id);
            ResultNew.UpdatedBy = UserId;
            ResultNew.UpdateDate = LocalTime.GetTime();
            ResultNew.CreatedBy = Result.CreatedBy;
            ResultNew.CreatedDate = Result.CreatedDate;
            if (SoccerInfoDto.Image != null)
            {
                ResultNew.Image = _file.Upload(SoccerInfoDto.Image, "SoccerInfo");
            }
            await _service.Update(_mapper.Map<SoccerInfo>(ResultNew));

            return Ok(SoccerInfoDto);
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
            var SoccerInfoResult = await _service.GetById(id);
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
            if (SoccerInfoResult == null) return BadRequest();
            SoccerInfoResult.UpdatedBy = UserId;
            SoccerInfoResult.UpdateDate = LocalTime.GetTime();


            var result = await _service.Remove(SoccerInfoResult);

            if (result == null) return BadRequest();

            return Ok();
        }
    }
}
