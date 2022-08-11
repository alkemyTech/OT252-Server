using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public IFormFile Photo { get; set; }
        [Required]
        public int RoleId { get; set; }
    }
}

