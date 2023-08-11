using ApplicationLayer.Services.UserAddressesService;
using AutoMapper;
using DomainLayer.Dtos.Product;
using DomainLayer.Dtos.UserAddresses;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Team404_SoccerClubBackend.Config;
using Team404_SoccerClubBackend.Config.File;

namespace UserAddresses404_SoccerClubBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserAddressesController : ControllerBase
    {

        private readonly IUserAddressesService _service;
        private readonly IMapper _mapper;
        private readonly IFileUpload _file;

        public UserAddressesController(IMapper mapper, IUserAddressesService service,IFileUpload file)
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
            var UserAddresses = await _service.GetAll();
            return Ok(_mapper.Map<IEnumerable<UserAddressesResultDto>>(UserAddresses));
        }
        
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
       
        public async Task<IActionResult> GetByUserId(Guid Id)
        {
            var UserAddresses = await _service.GetByUserId(Id);
            return Ok(_mapper.Map<IEnumerable<UserAddressesResultDto>>(UserAddresses));
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
            var UserAddressesResult = await _service.GetById(id);

            if (UserAddressesResult == null) return BadRequest();

            return Ok(_mapper.Map<UserAddressesResultDto>(UserAddressesResult));
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Add(UserAddressesDto UserAddressesDto)
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
            var UserAddressesResult = _mapper.Map<UserAddresses>(UserAddressesDto);
            UserAddressesResult.CreatedDate = LocalTime.GetTime();
            UserAddressesResult.CreatedBy = UserId;
          
            var result = await _service.Add(UserAddressesResult);

            if (result == null) return BadRequest();

            return Ok(_mapper.Map<UserAddressesResultDto>(result));
        }


        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Update(UserAddressesDto UserAddressesDto)
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
            var ResultNew = _mapper.Map<UserAddresses>(UserAddressesDto);
            var Result = await _service.GetById((Guid)UserAddressesDto.Id);
            ResultNew.UpdatedBy = UserId;
            ResultNew.UpdateDate = LocalTime.GetTime();
            ResultNew.CreatedBy = Result.CreatedBy;
            ResultNew.CreatedDate = Result.CreatedDate;
          
            await _service.Update(_mapper.Map<UserAddresses>(ResultNew));

            return Ok(UserAddressesDto);
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
            var UserAddressesResult = await _service.GetById(id);
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
            if (UserAddressesResult == null) return BadRequest();
            UserAddressesResult.UpdatedBy = UserId;
            UserAddressesResult.UpdateDate = LocalTime.GetTime();


            var result = await _service.Remove(UserAddressesResult);

            if (result == null) return BadRequest();

            return Ok();
        }
    }
}
