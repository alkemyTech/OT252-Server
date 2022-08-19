using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OngProject.Controllers;
using OngProject.Core.Business;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestONGProject.Helpers;
using Xunit;

namespace Test_Ong.Controller
{
    public class ContactsControllerTest
    {
        public static ApplicationDbContext _context;
        public static UnitOfWork _unitOfWork;
        public static ContactService _contactsServices;
        public static ContactsController _contactsController;



        public ContactsControllerTest()
        {
            ISendGrid _sendGrid = new SendGridTestHelper();



            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "MemoryDBTest").Options;
            _context = new ApplicationDbContext(options);
            _unitOfWork = new(_context);
            _contactsServices = new(_unitOfWork, _sendGrid);
            _contactsController = new(_contactsServices);


            List<Contact> listContacts = (List<Contact>)_unitOfWork.ContactsRepository.GetAll().Result;

            if (!(listContacts.Count > 0))
            {
                List<Contact> list = new()
                {
                    new Contact
                    {
                        Id = 1,
                        Name = "Juan Perez",
                        Phone = 984576543,
                        Email = "juan.perez@correo.com",
                        Message = "Este es un mensaje",
                        TimeStamps = DateTime.Now,
                        SoftDelete = false
                    },
                    new Contact
                    {
                        Id = 2,
                        Name = "Maria Gomez",
                        Phone = 115433764,
                        Email = "maria.gomez@correo.com",
                        Message = "Este es otro mensaje",
                        TimeStamps = DateTime.Now,
                        SoftDelete = false
                    },
                    new Contact
                    {
                        Id = 3,
                        Name = "Juan Perez",
                        Phone = 115433764,
                        Email = "juan.perez@correo.com",
                        Message = "Este es otro mensaje",
                        TimeStamps = DateTime.Now,
                        SoftDelete = false
                    }
                };

                _context.AddRange(list);
                _context.SaveChanges();
            }
        }





        [Fact]
        public async Task GetAll_ShouldGetAllContact()
        {
            //Arrange

            //Act

            var result = await _contactsController.GetAll();
            OkObjectResult okResult = (OkObjectResult)result.Result;

            List<ContactDTO> contacts = (List<ContactDTO>)okResult.Value;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.True(contacts.Count > 0);

        }

        [Theory]
        [InlineData(200, 3)]
        [InlineData(404, 8)]
        public async Task Get_ShouldGetContactById(int statusCode, int contactId)
        {
            //Arrange

            //Act

            ObjectResult result = (ObjectResult)(await _contactsController.Get(contactId)).Result;

            //Assert

            Assert.Equal(statusCode, result.StatusCode);

        }

        [Fact]
        public async Task Post_ShouldInsertNewContact()
        {
            //Arrange

            ContactDTO contact = new ContactDTO()
            {
                Name = "Julian Gomez",
                Phone = 1122334455,
                Email = "correo@correo.com",
                Message = "Este es el mensaje"
            };

            //Act

            ObjectResult result = (ObjectResult)(await _contactsController.Post(contact));

            //Assert

            Assert.Equal(200, result.StatusCode);
        }

        [Theory]
        [InlineData(200, 2)]
        [InlineData(404, 8)]
        public async Task Put_ShouldEditContact(int statusCode, int contactId)
        {
            //Arrange

            ContactDTO contactDTO = new ContactDTO
            {

                Name = "Juan Perez",
                Phone = 115433764,
                Email = "juan.perez@correo.com",
                Message = "Este es el mensaje modificado",

            };

            //Act

            ObjectResult result = (ObjectResult)(await _contactsController.Put(contactDTO, contactId)).Result;

            //Assert

            Assert.Equal(statusCode, result.StatusCode);
        }

        [Theory]
        [InlineData(200, 2)]
        [InlineData(404, 8)]
        public async Task Delete_ShouldDeleteContact(int statusCode, int contactId)
        {
            //Arrange

            //Act

            ObjectResult result = (ObjectResult)(await _contactsController.Delete(contactId)).Result;

            //Assert

            Assert.Equal(statusCode, result.StatusCode);
        }

    }
}
