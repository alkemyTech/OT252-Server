using Microsoft.AspNetCore.Http;
using OngProject.Core.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Models.DTOs
{
    public class CreationUserDto
    {
        [Required(ErrorMessage = "Debe ingresar el nombre del usuario")]
        [MaxLength(255, ErrorMessage = "El nombre no puede tener más de 255 caracteres")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Debe ingresar el apellido del usuario")]
        [MaxLength(255, ErrorMessage = "El apellido no puede tener más de 255 caracteres")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Debe ingresar un email")]
        [MaxLength(320, ErrorMessage = "El email no puede tener más de 320 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        [MaxLength(255, ErrorMessage = "La contraseña no puede tener más de 255 caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Debe ingresar la foto del usuario")]
        [ExtensionFile(new[] { "image/png", "image/jpeg", "image/gif" })]
        [WeightFile(1024)]
        public IFormFile Photo { get; set; }

        [Required(ErrorMessage = "Debe ingresar el rol del usuario")]
        public int RoleId { get; set; }
    }
}
