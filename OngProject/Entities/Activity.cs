using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OngProject.Entities
{
    [Table("Activities")]
    public class Activity : Entity
    {
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName ="text")]
        public string Content { get; set; }

        [Required]
        [Column(TypeName ="varchar(255)")]
        public string Image { get; set; }

        public DateTime DeletedAt { get; set; }
    }
}
