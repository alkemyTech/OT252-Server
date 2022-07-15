using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Entities
{
    public class Members : Entity
    {
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }

        [MaxLength(255)]
        public string FacebookUrl { get; set; }
       
        [MaxLength(255)]
        public string InstragramUrl { get; set; }
        
        [MaxLength(255)]
        public string LinkedinUrl { get; set; }

        [MaxLength(255)]
        [Required]
        public string Image { get; set; }
    }
}
