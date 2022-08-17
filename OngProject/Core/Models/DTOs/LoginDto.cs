using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Models.DTOs
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public int RoleId { get; set; }
    }
}
