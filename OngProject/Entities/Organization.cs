using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Entities
{
    public class Organization : Entity
    {
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }

        [MaxLength(255)]
        [Required]
        public string Image { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        [MaxLength(320)]
        [Required]
        public string Email { get; set; }

        [MaxLength(500)]
        [Required]
        public string WelcomeText { get; set; }

        [MaxLength(2000)]
        public string AboutUsText { get; set; }

        [MaxLength(255)]
        public string FacebookUrl { get; set; }

        [MaxLength(255)]
        public string InstagramUrl { get; set; }

        [MaxLength(255)]
        public string LinkedinUrl { get; set; }
    }
}
