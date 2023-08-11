using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Dtos.MatchStats
{
    public class MatchStatsDto
    {
        public Guid? Id { get; set; }
        public string? Weather { get; set; }
        public string? Winner { get; set; }
        public string? Details { get; set; }
        public string? Attendance { get; set; }
        public Guid? MatchesId { get; set; }
    }
}
