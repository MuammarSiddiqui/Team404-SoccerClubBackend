using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class PlayerAchievement : BaseModal
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? DateRecieved { get; set; }
        public Guid? PlayerId { get; set; }
        public Player? Player { get; set; }
        public Guid? MatchesId { get; set; }
        public Matches? Matches { get; set; }
    }
}
