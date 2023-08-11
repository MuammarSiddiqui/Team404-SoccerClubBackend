using ApplicationLayer.Services.MatchesService;
using ApplicationLayer.Services.OrderService;
using ApplicationLayer.Services.TeamService;
using AutoMapper;
using DomainLayer.Dtos.Matches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Team404_SoccerClubBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountsController : ControllerBase
    {
        private readonly IMatchesService _match;
        private readonly ITeamService _teams;
        private readonly IOrderService _orders;
        private readonly IMapper _mapper;

        public CountsController(IMatchesService matches,
            ITeamService team,IOrderService order,IMapper mapper)
        {
            _mapper = mapper;
            _match= matches;
            _teams= team;   
            _orders= order;
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> GetAllCounts()
        {
            var res = await _match.GetAllWithRelationship();
            var teams = await _teams.GetAll();
            var orders = await _orders.GetAll();
            var obj = new
            {
                Today = res.Where(x => x.DateTime.Date == DateTime.Now.Date).Count(),
                Upcoming = res.Where(x => x.DateTime.Date > DateTime.Now.Date).Count(),
                Previous = res.Where(x => x.DateTime.Date < DateTime.Now.Date).Count(),
                Teams = teams.Count(),
                Orders = orders.Count()
            };
            return Ok(obj);
        }

    }
}
