﻿using DomainLayer.Dtos.Cart;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Dtos.UsersDto
{
    public class UsersLoginDto
    {
        [Required(ErrorMessage = "Username Is Required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; }
    }
    public class UsersLoginWithCartDto
    {
        [Required(ErrorMessage = "Username Is Required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; }
        public List<CartDto> Cart { get; set; } = new List<CartDto>();
    }
}
