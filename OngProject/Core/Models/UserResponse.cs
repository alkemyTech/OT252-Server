using OngProject.Entities;

namespace OngProject.Core.Models
{
    public class UserResponse
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}
