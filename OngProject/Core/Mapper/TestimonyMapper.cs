using OngProject.Core.Models.DTOs;
using OngProject.Entities;

namespace OngProject.Core.Mapper
{
    public class TestimonyMapper
    {

        public Testimony ToTestimony(TestimonyDTO testymonyDTO)
        {
            Testimony testimony = new Testimony()
            {
                Id = testymonyDTO.Id,
                Name = testymonyDTO.Name,
                Content = testymonyDTO.Content,
                Image = testymonyDTO.Image,
            };

            return testimony;
        }

        public TestimonyDTO ToTestimonyDTO(Testimony testimony)
        {
            TestimonyDTO testimonyDTO = new TestimonyDTO()
            {
                Id=testimony.Id,
                Name = testimony.Name,
                Content = testimony.Content,
                Image = testimony.Image,
            };

            return testimonyDTO;

        }

    }
}
