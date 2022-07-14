using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Entities
{
    public class Categories : Entity
    {
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }
   
        [MaxLength(255)]
        [Required]
        public string Description { get; set; }

        [MaxLength(255)]
        [Required]
        public string Image { get; set; }
    }
}
