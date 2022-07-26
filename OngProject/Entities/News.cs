using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Entities
{
    public class News : Entity
    {
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }
        [MaxLength(255)]
        [Required]
        public string Content { get; set; }

        [MaxLength(255)]
        [Required]
        public string Image { get; set; }
       
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
