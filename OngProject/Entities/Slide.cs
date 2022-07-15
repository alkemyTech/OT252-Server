using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OngProject.Entities
{
    public class Slide : Entity
    {
        [MaxLength(255)]
        [Required]
        public String ImageUrl { get; set; }

        [MaxLength(500)]
        [Required]
        public String Text { get; set; }

        [MaxLength(255)]
        [Required]
        public String Order { get; set; }  //¡¡¡Chequear que sea de tipo String!!!, no se de que se trata la variable Order

        [ForeignKey("Organization")]
        [Required]
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}
