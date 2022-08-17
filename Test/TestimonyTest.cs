using FakeItEasy;
using OngProject.Controllers;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using Xunit;

namespace Test
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
            Xunit.Assert.NotNull(result);
        }


        //[Fact]
        //public void Put_Testimony()
        //{
        //    TestClass member = new MemberDto()
        //    {
        //        Name = "Test",
        //        FacebookUrl = "TestFacebook.com",
        //        InstagramUrl = "TestInstagram.com",
        //        LinkedinUrl = "TestLinkedin.com",
        //        Image = "TestImage",
        //    };

        //    var controler = new MemberController(_context);
        //    var result = controler.Put(member, 1);
        //    Xunit.Assert.NotNull(result);
        //}


        //[Fact]
        //public void Get_Test()
        //{
        //    var controler = new TestimonialsController(_context);

        //    var test = controler.Get(1);
        //    Xunit.Assert.NotNull(test);
        //}



        //[Fact]
        //public void Delete_Test()
        //{
        //    var controler = new TestimonialsController(_context);
        //    var result = controler.Delete(1);
        //    Xunit.Assert.NotNull(result);
        //}
    }
}


