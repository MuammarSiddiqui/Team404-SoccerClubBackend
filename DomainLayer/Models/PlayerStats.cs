using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class PlayerStats : BaseModal
    {
        public int? Goals { get; set; }
        public int? Assists { get; set; }
        public int? YellowCards { get; set; }
        public int? RedCards { get; set; }
        public decimal? MinutesPlayed { get; set; }
        public Guid? PlayerId { get; set; }
        public Player? Player { get; set; }
        public Guid? MatchesId { get; set; }
        public Matches? Matches { get; set; }
    }
}
