using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Models.DTOs
{
    public class ContactDTO
    {
        [Required(ErrorMessage = "Debe ingresar el nombre.")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Debe ingresar el número de teléfono.")]
        public int Phone { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Email.")]
        [EmailAddress(ErrorMessage = "Formato de correo electrónico es inválido")]
        public string Email { get; set; }

        public string Message { get; set; }
    }
}
