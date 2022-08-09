using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models.DTOs
{
    public class TestimonyDTO
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

       
        public string Content { get; set; }

        public string Image { get; set; }

        
        
    }
}
