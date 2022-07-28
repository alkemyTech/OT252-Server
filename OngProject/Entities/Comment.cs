using System.ComponentModel.DataAnnotations;

namespace OngProject.Entities
{
    public class Comment : Entity
    {
        [Required]
        public int User_Id { get; set; }
        [MaxLength(2000)]
        [Required]
        public string Body { get; set; }
        [Required]
        public int News_Id { get; set; }
        public News? News { get; set; }
    }
}
