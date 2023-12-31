﻿
namespace DomainLayer.Dtos.Team
{
    public class TeamResultDto : BaseResultDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Country { get; set; }
        public bool? Club { get; set; }
        public string? Logo { get; set; }
    }
}
