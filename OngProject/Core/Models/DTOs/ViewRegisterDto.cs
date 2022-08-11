using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Models.DTOs
{
    public class ViewRegisterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public int RoleId { get; set; }
        public string Token { get; set; }
    }
}
