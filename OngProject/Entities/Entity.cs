using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Entities
{
    public class Entity
    {
        public int Id { get; set; }
        [Required]
        public DateTime TimeStamps { get; set; }
        [Required]
        public bool SoftDelete { get; set; }
    }
}
