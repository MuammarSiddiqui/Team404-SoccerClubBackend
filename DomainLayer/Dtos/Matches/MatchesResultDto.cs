﻿
namespace DomainLayer.Dtos.Matches
{
    public class MatchesResultDto : BaseResultDto
    {
        public string? Stadium { get; set; }
        public DateTime DateTime { get; set; }
        public Guid? TeamId { get; set; }
        public string? Team { get; set; }
        public string? TeamLogo { get; set; }
        public Guid? CompetitionId { get; set; }
        public string? Competition { get; set; }
    }
}
