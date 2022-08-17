﻿using Microsoft.AspNetCore.Http;
using OngProject.Core.Validation;
using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models.DTOs
{
    public class CreationActivityDto
    {
        [Required(ErrorMessage = "Debe ingresar el nombre de la actividad")]
        [MaxLength(255, ErrorMessage = "El nombre no puede tener más de 255 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe ingresar el contenido de la actividad")]
        [MaxLength(255, ErrorMessage = "El contenido no puede tener más de 255 caracteres")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Debe ingresar una imagen")]
        [ExtensionFile(new[] { "image/png", "image/jpeg", "image/gif" })]
        [WeightFile(1024)]
        public IFormFile Image { get; set; }
    }
}
