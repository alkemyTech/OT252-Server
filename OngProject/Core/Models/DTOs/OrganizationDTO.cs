using System.Collections.Generic;

namespace OngProject.Core.Models.DTOs
{
    public class OrganizationDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string WelcomeText { get; set; }

        public string AboutUsText { get; set; }

        public string FacebookUrl { get; set; }

        public string InstagramUrl { get; set; }

        public string LinkedinUrl { get; set; }
        
        public List<SlideDto> Slides { get; set; }

    }
}
