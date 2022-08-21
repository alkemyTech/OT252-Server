using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Models.DTOs
{
    public class ViewContactDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Phone { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }
    }
}
