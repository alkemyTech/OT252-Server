using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Entities
{
    public class Organizacion : Entity
    {
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }

        [MaxLength(255)]
        [Required]
        public string Image { get; set; }

        public string Address { get; set; }

        public ulong Phone { get; set; }

        [MaxLength(320)]
        [Required]
        public string Email { get; set; }

        [MaxLength(500)]
        [Required]
        public char[] WelcomeText { get; set; }

        [MaxLength(2000)]
        public char[] AboutUsText { get; set; }
    }
}
