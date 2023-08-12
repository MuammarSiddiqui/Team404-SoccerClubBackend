using ApplicationLayer.Services.FeedbackService;
using AutoMapper;
using DomainLayer.Dtos.Feedback;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Team404_SoccerClubBackend.Config;

namespace Team404_SoccerClubBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {

        private readonly IFeedbackService _service;
        private readonly IMapper _mapper;

        public FeedbackController(IMapper mapper, IFeedbackService service)
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
            var Feedback = await _service.GetAll();
            return Ok(_mapper.Map<IEnumerable<FeedbackResultDto>>(Feedback));
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
            var FeedbackResult = await _service.GetById(id);

            if (FeedbackResult == null) return BadRequest();

            return Ok(_mapper.Map<FeedbackResultDto>(FeedbackResult));
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(FeedbackDto FeedbackDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var FeedbackResult = _mapper.Map<Feedback>(FeedbackDto);
            FeedbackResult.CreatedDate = LocalTime.GetTime();
            var result = await _service.Add(FeedbackResult);

            if (result == null) return BadRequest();

            return Ok(_mapper.Map<FeedbackResultDto>(result));
        }


        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(FeedbackDto FeedbackDto)
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
            var ResultNew = _mapper.Map<Feedback>(FeedbackDto);
            var Result = await _service.GetById((Guid)FeedbackDto.Id);
            ResultNew.UpdatedBy = UserId;
            ResultNew.UpdateDate = LocalTime.GetTime();
            ResultNew.CreatedBy = Result.CreatedBy;
            ResultNew.CreatedDate = Result.CreatedDate;
            await _service.Update(_mapper.Map<Feedback>(ResultNew));

            return Ok(FeedbackDto);
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
            var FeedbackResult = await _service.GetById(id);
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
            if (FeedbackResult == null) return BadRequest();
            FeedbackResult.UpdatedBy = UserId;
            FeedbackResult.UpdateDate = LocalTime.GetTime();


            var result = await _service.Remove(FeedbackResult);

            if (result == null) return BadRequest();

            return Ok();
        }
    }
}
