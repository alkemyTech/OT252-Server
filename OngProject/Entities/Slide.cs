using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OngProject.Entities
{
    public class Slide : Entity
    {
        [MaxLength(255)]
        [Required]
        public string ImageUrl { get; set; }

        [MaxLength(500)]
        [Required]
        public string Text { get; set; }

        [MaxLength(255)]
        [Required]
        public int Order { get; set; }

        [ForeignKey("Organization")]
        [Required]
        public int OrganizationId { get; set; }
        [JsonIgnore]
        public Organization Organization { get; set; }
    }
}
