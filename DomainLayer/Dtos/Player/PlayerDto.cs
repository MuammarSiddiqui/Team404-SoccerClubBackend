using DomainLayer.Models;
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
        public DateTime? DOB { get; set; }
        public Guid? TeamId { get; set; }
    }
}
