using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using OngProject.Controllers;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test_Ong.Controllers
{
    
    public class MemberTest
    {

        private readonly IMemberService _context = A.Fake<IMemberService>();

        
        [Fact]
        public void Post_Member()
        {

            MemberDto member = new MemberDto()
            {
                Name = "Test",
                FacebookUrl = "TestFacebook.com",
                InstagramUrl = "TestInstagram.com",
                LinkedinUrl = "TestLinkedin.com",
                Image = "TestImage",
            };

            var controler = new MemberController(_context);
            var result = controler.Post(member);
            Assert.NotNull(result);
        }
        
        [Theory]
        [InlineData(200, 2)]
        
        public async void Put_Member(int statusCode, int Id)
        {
            MemberDto member = new MemberDto()
            {
                Name = "Test",
                FacebookUrl = "TestFacebook.com",
                InstagramUrl = "TestInstagram.com",
                LinkedinUrl = "TestLinkedin.com",
                Image = "TestImage",
            };

            var controler =  new MemberController(_context);
            ObjectResult result = (ObjectResult)(controler.Put(member, Id)).Result;
            Assert.Equal(statusCode, result.StatusCode);
            
        }
        [Fact]
        public void Get_Test()
        {
            var controler = new MemberController(_context);

            var test = controler.Get(1);
            Assert.NotNull(test);
        }



        [Fact]
        public void Delete_Test()
        {
            var controler = new MemberController(_context);
            var result = controler.Delete(1);
            Assert.NotNull(result);
        }

    }
}

