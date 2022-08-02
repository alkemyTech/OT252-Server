using Microsoft.AspNetCore.Http;
using OngProject.Core.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Models.DTOs
{
    public class CreationCategoryDto
    {
        [Required(ErrorMessage = "Debe ingresar el nombre de la categoría")]
        [MaxLength(255, ErrorMessage = "El nombre no puede tener más de 255 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe ingresar una descripción")]
        [MaxLength(255, ErrorMessage = "El nombre no puede tener más de 255 caracteres")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Debe ingresar una imagen")]
        [ExtensionFile(new[] { "image/png", "image/jpeg", "image/gif" })]
        [WeightFile(1024)]
        public IFormFile Image { get; set; }

    }
}
