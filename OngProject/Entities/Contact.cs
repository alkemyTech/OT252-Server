

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OngProject.Entities
{
    [Table("Contacts")]
    public class Contact : Entity
    {
        [Required]
        [Column(TypeName ="varchar(255)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName ="varchar(20)")]
        public int Phone { get; set; }

        [Column(TypeName = "varchar(320)")]
        public string Email { get; set; }

        [Column(TypeName = "text")]
        public string Message { get; set; }
    }
}
