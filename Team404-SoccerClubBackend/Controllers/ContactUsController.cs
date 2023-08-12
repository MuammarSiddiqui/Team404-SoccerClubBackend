using ApplicationLayer.Services.ContactUsService;
using AutoMapper;
using DomainLayer.Dtos.ContactUs;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Team404_SoccerClubBackend.Config;

namespace Team404_SoccerClubBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {

        private readonly IContactUsService _service;
        private readonly IMapper _mapper;

        public ContactUsController(IMapper mapper, IContactUsService service)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[Authorize]
        public async Task<IActionResult> GetAll()
        {
            var ContactUs = await _service.GetAll();
            return Ok(_mapper.Map<IEnumerable<ContactUsResultDto>>(ContactUs));
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
            var ContactUsResult = await _service.GetById(id);

            if (ContactUsResult == null) return BadRequest();

            return Ok(_mapper.Map<ContactUsResultDto>(ContactUsResult));
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(ContactUsDto ContactUsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ContactUsResult = _mapper.Map<ContactUs>(ContactUsDto);
            ContactUsResult.CreatedDate = LocalTime.GetTime();
            var result = await _service.Add(ContactUsResult);

            if (result == null) return BadRequest();

            return Ok(_mapper.Map<ContactUsResultDto>(result));
        }


        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(ContactUsDto ContactUsDto)
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
            var ResultNew = _mapper.Map<ContactUs>(ContactUsDto);
            var Result = await _service.GetById((Guid)ContactUsDto.Id);
            ResultNew.UpdatedBy = UserId;
            ResultNew.UpdateDate = LocalTime.GetTime();
            ResultNew.CreatedBy = Result.CreatedBy;
            ResultNew.CreatedDate = Result.CreatedDate;
            await _service.Update(_mapper.Map<ContactUs>(ResultNew));

            return Ok(ContactUsDto);
        }


        [HttpDelete]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Remove(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ContactUsResult = await _service.GetById(id);
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
            if (ContactUsResult == null) return BadRequest();
            ContactUsResult.UpdatedBy = UserId;
            ContactUsResult.UpdateDate = LocalTime.GetTime();


            var result = await _service.Remove(ContactUsResult);

            if (result == null) return BadRequest();

            return Ok();
        }
    }
}
