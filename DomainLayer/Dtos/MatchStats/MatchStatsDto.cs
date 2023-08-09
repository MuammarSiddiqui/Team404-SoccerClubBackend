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
        public DateTime? Date { get; set; }
        public string? Stadium { get; set; }
        public string? Attendance { get; set; }
        public Guid? MatchesId { get; set; }
    }
}
