using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models
{
    public class UserRequest
    {
        public string Nombre { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
