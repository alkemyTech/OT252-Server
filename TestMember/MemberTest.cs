using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OngProject.Controllers;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using System.Collections.Generic;
using Xunit;

namespace Test
{
    [TestClass]
    public class MemberTest
    {

        private readonly IMemberService _context = A.Fake<IMemberService>();

        [TestMethod]
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
            Xunit.Assert.NotNull(result);
        }
        [Fact]
        public void Put_Member ()
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
            var result = controler.Put(member,1);
            Xunit.Assert.NotNull(result);

        }
        [Fact]
        public void Get_Test()
        {
            var controler = new MemberController(_context);
           
            var test = controler.Get(1);
           Xunit.Assert.NotNull(test);
        }

       

        [Fact]
        public void Delete_Test()
        {
            var controler = new MemberController(_context);
            var result = controler.Delete(1);
            Xunit.Assert.NotNull(result);
        }

    }
}
