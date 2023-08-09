using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Dtos.TeamStats
{
    public class TeamStatsDto
    {
        public Guid? Id { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsConceded { get; set; }
        public int Shots { get; set; }
        public int Fouls { get; set; }
        public decimal Possession { get; set; }
        public Guid? TeamId { get; set; }
        public Guid? MatchesId { get; set; }
    }
}
