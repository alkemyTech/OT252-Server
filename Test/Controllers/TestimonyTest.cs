using FakeItEasy;
using OngProject.Controllers;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using Xunit;

namespace Test_Ong.Controllers
{
    public class TestimonyTest
    {
        private readonly ITestimonialsService _context = A.Fake<ITestimonialsService>();

        [Fact]
        public void Post_Testimony()
        {
            //Arrange
            CreationTestimonyDTO testimony = new CreationTestimonyDTO()
            {
                Name = "Test",
                Content = "Contenido test post",
            };


            var controller = new TestimonialsController(_context);

            //Act
            var result = controller.Post(testimony);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Get_Testimony()
        {
            var controler = new TestimonialsController(_context);

            var test = controler.Get(1);
            Assert.NotNull(test);
        }


        [Fact]
        public void Delete_Testimony()
        {
            var controler = new TestimonialsController(_context);
            var result = controler.Delete(1);
            Assert.NotNull(result);
        }
    }
}


