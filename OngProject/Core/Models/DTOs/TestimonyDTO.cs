using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models.DTOs
{
    public class TestimonyDTO
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "El campo nombre es requerido.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo contenido es requerido.")]
        public string Content { get; set; }

        public string Image { get; set; }

        
        
    }
}
