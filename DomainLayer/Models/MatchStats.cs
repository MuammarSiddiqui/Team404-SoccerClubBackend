using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class MatchStats : BaseModal
    {
        public DateTime? Date { get; set; }
        public string? Stadium { get; set; }
        public string? Attendance { get; set; }
        public Guid? MatchesId { get; set; }
        public Matches? Matches { get; set; }
    }
}
