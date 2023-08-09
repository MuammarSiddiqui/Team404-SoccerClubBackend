﻿using ApplicationLayer.Services.PlayerService;
using AutoMapper;
using DomainLayer.Dtos.Player;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Team404_SoccerClubBackend.Config;

namespace Player404_SoccerClubBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {

        private readonly IPlayerService _service;
        private readonly IMapper _mapper;

        public PlayerController(IMapper mapper, IPlayerService service)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
       
        public async Task<IActionResult> GetAll()
        {
            var Player = await _service.GetAll();
            return Ok(_mapper.Map<IEnumerable<PlayerResultDto>>(Player));
        }
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
       
        public async Task<IActionResult> GetByTeamId(Guid Id)
        {
            var Player = await _service.GetByTeamId(Id);
            return Ok(_mapper.Map<IEnumerable<PlayerResultDto>>(Player));
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
            var PlayerResult = await _service.GetById(id);

            if (PlayerResult == null) return BadRequest();

            return Ok(_mapper.Map<PlayerResultDto>(PlayerResult));
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Add(PlayerDto PlayerDto)
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
            var PlayerResult = _mapper.Map<Player>(PlayerDto);
            PlayerResult.CreatedDate = LocalTime.GetTime();
            PlayerResult.CreatedBy = UserId;
            var result = await _service.Add(PlayerResult);

            if (result == null) return BadRequest();

            return Ok(_mapper.Map<PlayerResultDto>(result));
        }


        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Update(PlayerDto PlayerDto)
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
            var ResultNew = _mapper.Map<Player>(PlayerDto);
            var Result = await _service.GetById((Guid)PlayerDto.Id);
            ResultNew.UpdatedBy = UserId;
            ResultNew.UpdateDate = LocalTime.GetTime();
            ResultNew.CreatedBy = Result.CreatedBy;
            ResultNew.CreatedDate = Result.CreatedDate;
            await _service.Update(_mapper.Map<Player>(ResultNew));

            return Ok(PlayerDto);
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
            var PlayerResult = await _service.GetById(id);
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
            if (PlayerResult == null) return BadRequest();
            PlayerResult.UpdatedBy = UserId;
            PlayerResult.UpdateDate = LocalTime.GetTime();


            var result = await _service.Remove(PlayerResult);

            if (result == null) return BadRequest();

            return Ok();
        }
    }
}