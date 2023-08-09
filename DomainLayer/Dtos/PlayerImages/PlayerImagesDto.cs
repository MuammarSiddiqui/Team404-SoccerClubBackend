using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Dtos.PlayerImages
{
    public class PlayerImagesDto
    {
        public Guid? Id { get; set; }
        public Guid? PlayerId { get; set; }
        public IFormFile ImageUrl { get; set; }
        public string? Caption { get; set; }
    }
}
