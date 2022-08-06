using Microsoft.AspNetCore.Http;
using OngProject.Core.Validation;
using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models.DTOs
{
    public class CreationTestimonyDTO
    {

        [MaxLength(255, ErrorMessage = "El nombre no puede tener más de 255 caracteres")]
        [Required(ErrorMessage = "El campo nombre es requerido.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo contenido es requerido.")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Debe ingresar una imagen")]
        [ExtensionFile(new[] { "image/png", "image/jpeg", "image/gif" })]
        [WeightFile(1024)]
        public IFormFile Image { get; set; }
    }
}
