using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Dtos.PlayerStats
{
    public class PlayerStatsDto
    {
        public Guid? Id { get; set; }
        public int? Goals { get; set; }
        public int? Assists { get; set; }
        public int? YellowCards { get; set; }
        public int? RedCards { get; set; }
        public decimal? MinutesPlayed { get; set; }
        public Guid? PlayerId { get; set; }
        public Guid? MatchesId { get; set; }
    }
}
