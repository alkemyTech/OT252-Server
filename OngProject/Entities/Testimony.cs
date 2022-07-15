using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OngProject.Entities
{
    [Table("Testimonials")]
    public class Testimony : Entity
    {
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Image { get; set; }

        [Column(TypeName = "varchar(65535)")]
        public string Content { get; set; }
    }
}
