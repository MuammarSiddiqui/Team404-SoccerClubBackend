using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Dtos.MatchStats
{
    public class MatchStatsResultDto : BaseResultDto
    {
        public string? Goals { get; set; }
        public string? Weather { get; set; }
        public string? Details { get; set; }
        public string? Winner { get; set; }
        public string? Attendance { get; set; }
        public Guid? MatchesId { get; set; }
        public string? Matches { get; set; }
    }
}
