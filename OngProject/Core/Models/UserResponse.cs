using OngProject.Entities;

namespace OngProject.Core.Models
{
    public class UserResponse
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        public string Token { get; set; }
    }
}
