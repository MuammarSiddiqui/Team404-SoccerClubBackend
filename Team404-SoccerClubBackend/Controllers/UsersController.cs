using ApplicationLayer.Services.CartService;
using ApplicationLayer.Services.RoleService;
using ApplicationLayer.Services.UsersService;
using AutoMapper;
using DomainLayer.Dtos.Cart;
using DomainLayer.Dtos.UsersDto;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Team404_SoccerClubBackend.Config;
using Team404_SoccerClubBackend.Config.File; 

namespace Team404_SoccerClubBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _service;
        private readonly IRoleService _rolesService;
        private readonly IMapper _mapper;
        private readonly ICartService _cart;
        private readonly IFileUpload _file;
        public UsersController(IUsersService service,
            IMapper mapper, IRoleService rolesService,IFileUpload file,ICartService cart)
        {
            _service = service;
            _cart = cart;
            _mapper = mapper;
            _file = file;
            _rolesService = rolesService;
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<object>> Login(UsersLoginDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Users Users = await _service.Get(request.Username);

            if (Users == null)

            {
                return BadRequest("Users not found");
            }
            if (!VerifyPasswordHash(request.Password, Users.PasswordHash, Users.PasswordSalt))
            {
                return BadRequest("wrong password");
            }
            var token = await CreateToken(Users);
            var tokenHandler = new JwtSecurityTokenHandler();
            var newtoken = tokenHandler.WriteToken(token);
            var cred = new
            {
                token = newtoken,
                Users = _mapper.Map<UsersResultDto>(Users),
            };
            await _service.Update(Users);
            return Ok(cred);
        }
        
        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<object>> LoginAdmin(UsersLoginDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Users Users = await _service.Get(request.Username);

            if (Users == null)

            {
                return BadRequest("Users not found");
            }
            if (!VerifyPasswordHash(request.Password, Users.PasswordHash, Users.PasswordSalt))
            {
                return BadRequest("wrong password");
            }
            var token = await CreateTokenAdmin(Users);
            if (token == null)
            {
                return BadRequest("User Not Found");
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var newtoken = tokenHandler.WriteToken(token);
            var cred = new
            {
                token = newtoken,
                Users = _mapper.Map<UsersResultDto>(Users),
            };
            await _service.Update(Users);
            return Ok(cred);
        }
        
        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<object>> LoginWithCartAdd(UsersLoginWithCartDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Users Users = await _service.Get(request.Username);

            if (Users == null)

            {
                return BadRequest("Users not found");
            }
            if (!VerifyPasswordHash(request.Password, Users.PasswordHash, Users.PasswordSalt))
            {
                return BadRequest("wrong password");
            }
            var list = new List<Cart>();
            foreach (var item in request.Cart)
            {
                var CartResult = _mapper.Map<Cart>(item);
                CartResult.CreatedDate = LocalTime.GetTime();
                CartResult.CreatedBy = Users.Id;
                CartResult.UsersId = Users.Id;
                list.Add(CartResult);
            }
            var result = await _cart.AddRange(list);

            var token = await CreateToken(Users);
            var tokenHandler = new JwtSecurityTokenHandler();
            var newtoken = tokenHandler.WriteToken(token);
            var cred = new
            {
                token = newtoken,
                Users = _mapper.Map<UsersResultDto>(Users),
                Cart = result
            };
            await _service.Update(Users);
            return Ok(cred);
        }


        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> GetById(Guid Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetById(Id);
            if (result == null)
            {
                return null;
            }
            return Ok(_mapper.Map<UsersResultDto>(result));
        }
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> Remove(Guid Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetById(Id);

            if (result == null)
            {
                return BadRequest(); ;
            }
            return Ok(_mapper.Map<UsersResultDto>(result));
        }
        
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> GetAllWithRelationship()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetAllWithRelationship();

            if (result == null)
            {
                return BadRequest(); ;
            }
            return Ok(result);
        }



        [HttpPut]
        [Route("[action]")]
        [Authorize]
        public async Task<IActionResult> Update([FromForm]UserUpdateDto obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var checkUsers = await _service.Get(obj.Username);
            var checkbyEmail = await _service.GetByEmail(obj.Email);
            var checkUsersbyid = await _service.GetById((Guid)obj.Id);
            if (checkUsers != null && checkUsersbyid != null)
            {
                if (checkUsers.Id != checkUsersbyid.Id && checkUsers.Username == checkUsersbyid.Username)
                {
                    return BadRequest("Usersname alredy exists");
                }
                if (checkUsers.Id != checkUsersbyid.Id && checkUsers.Email == checkUsersbyid.Email)
                {
                    return BadRequest("Email alredy exists");
                }
            }
            checkUsersbyid.Name = obj.Name;
            checkUsersbyid.Username = obj.Username;
            checkUsersbyid.Email = obj.Email;
            checkUsersbyid.ContactNumber = obj.ContactNumber;
            checkUsersbyid.Active = "Y";
            if (obj.ProfilePic != null)
            {
                checkUsersbyid.ProfilePic = _file.Upload(obj.ProfilePic, "Users");
            }
            var token = await CreateToken(checkUsersbyid);
            var tokenHandler = new JwtSecurityTokenHandler();
            var newtoken = tokenHandler.WriteToken(token);

            var Users = await _service.Update(checkUsersbyid);
            if (Users == null)
            {
                return BadRequest();
            }
            else
            {
                var cred = new
                {
                    token = newtoken,
                    Users = _mapper.Map<UsersResultDto>(Users),
                };
                await _service.Update(Users);
                return Ok(cred);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm]UsersDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var checkUsers = await _service.Get(request.Username);
                if (!string.IsNullOrEmpty(request.Email))
                {
                    var checkUsersbyemail = await _service.Get(request.Email);
                    if (checkUsersbyemail != null)
                    {
                        return BadRequest("Email Already Exists");
                    }
                }
                if (checkUsers == null)
                {
                    Users Users = new();
                    CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
                    Users.Username = request.Username;
                    Users.Name = request.Name;
                    Users.Email = request.Email ?? "";
                    Users.RoleId = request.RoleId;
                    Users.PasswordHash = passwordHash;
                    Users.PasswordSalt = passwordSalt;
                    Users.CreatedDate = LocalTime.GetTime();
                    Users.Active = "Y";
                    if (request.ProfilePic !=null )
                    {
                       Users.ProfilePic = _file.Upload(request.ProfilePic, "Users");
                    }
                    await _service.Add(Users);
                    var token = await CreateToken(Users);

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var newtoken = tokenHandler.WriteToken(token);

                    var cred = new
                    {
                        token = newtoken,
                        User = _mapper.Map<UsersResultDto>(Users)
                    };
                    await _service.Update(Users);
                    return Ok(cred);
                }
                else
                {
                    return BadRequest("Usersname Already Exists");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
        [HttpPost("RegisterWithCart")]
        public async Task<IActionResult> RegisterWithCart([FromForm]UsersDtoWithCart request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var checkUsers = await _service.Get(request.Username);
                if (!string.IsNullOrEmpty(request.Email))
                {
                    var checkUsersbyemail = await _service.Get(request.Email);
                    if (checkUsersbyemail != null)
                    {
                        return BadRequest("Email Already Exists");
                    }
                }
                if (checkUsers == null)
                {
                    Users Users = new();
                    CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
                    Users.Username = request.Username;
                    Users.Name = request.Name;
                    Users.Email = request.Email ?? "";
                    Users.RoleId = request.RoleId;
                    Users.PasswordHash = passwordHash;
                    Users.PasswordSalt = passwordSalt;
                    Users.CreatedDate = LocalTime.GetTime();
                    Users.Active = "Y";
                    if (request.ProfilePic !=null )
                    {
                       Users.ProfilePic = _file.Upload(request.ProfilePic, "Users");
                    }
                    await _service.Add(Users);
                    var list = new List<Cart>();
                    foreach (var item in request.Cart)
                    {
                        var CartResult = _mapper.Map<Cart>(item);
                        CartResult.CreatedDate = LocalTime.GetTime();
                        CartResult.CreatedBy = Users?.Id;
                        list.Add(CartResult);
                    }
                    var result = await _cart.AddRange(list);

                    var token = await CreateToken(Users);

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var newtoken = tokenHandler.WriteToken(token);

                    var cred = new
                    {
                        token = newtoken,
                        User = _mapper.Map<UsersResultDto>(Users)
                    };
                    await _service.Update(Users);
                    return Ok(cred);
                }
                else
                {
                    return BadRequest("Usersname Already Exists");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
        private async Task<JwtSecurityToken> CreateToken(Users Users)
        {
            var res = await _rolesService.GetById((Guid)Users.RoleId);
            List<Claim> claims = new()
            {
                    new Claim(ClaimTypes.Name, (Users.Id).ToString()),
                    new Claim(ClaimTypes.Role, res.RoleName),
                };


            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("this is a string used for encrypt and decrypt token"));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: LocalTime.GetTime().AddDays(1),
                signingCredentials: cred
                );

            return token;
        }  private async Task<JwtSecurityToken> CreateTokenAdmin(Users Users)
        {
            var res = await _rolesService.GetById((Guid)Users.RoleId);
            if (res.RoleName.ToLower().Trim()!="admin")
            {
                return null;
            }
            List<Claim> claims = new()
            {
                    new Claim(ClaimTypes.Name, (Users.Id).ToString()),
                    new Claim(ClaimTypes.Role, res.RoleName),
                };


            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("this is a string used for encrypt and decrypt token"));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: LocalTime.GetTime().AddDays(1),
                signingCredentials: cred
                );

            return token;
        }
        private Task<JwtSecurityToken> CreateToken(List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("this is a string used for encrypt and decrypt token"));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: LocalTime.GetTime().AddMinutes(20),
                signingCredentials: cred
                );

            return Task.FromResult(token);
        }
      



    }
}
