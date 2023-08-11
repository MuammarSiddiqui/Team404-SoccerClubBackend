using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Dtos.Player
{
    public class PlayerDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string? Nationatilty { get; set; }
        public string? Position { get; set; }
        public string? ShirtNumber { get; set; }
        public string? Height { get; set; }
        public string? Weight { get; set; }
        public IFormFile? ProfilePic { get; set; }
        public DateTime? DOB { get; set; }
        public Guid? TeamId { get; set; }
    }
}
