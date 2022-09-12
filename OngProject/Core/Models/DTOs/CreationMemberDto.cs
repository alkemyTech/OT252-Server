using Microsoft.AspNetCore.Http;
using OngProject.Core.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Models.DTOs
{
    public class CreationMemberDto
    {
        [Required]
        public string Name { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string LinkedinUrl { get; set; }
        [Required(ErrorMessage = "Debe ingresar una imagen")]
        [ExtensionFile(new[] { "image/png", "image/jpeg", "image/gif" })]
        [WeightFile(1024)]
        public IFormFile Image { get; set; }
    }
}
