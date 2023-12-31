﻿

namespace DomainLayer.Dtos.ClubHistory
{
    public class ClubHistoryResultDto : BaseResultDto
    {
        public DateTime? Date { get; set; }
        public string? Title { get; set; }
        public string? Title2 { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
    }
}
