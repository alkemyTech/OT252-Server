using OngProject.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OngProject.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using OngProject.DataAccess;
using OngProject.Repositories;
using OngProject.Core.Business;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using OngProject.Core.Models.DTOs;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OngProject.Core.Helper;
using Microsoft.Extensions.Configuration;

namespace OngProject.Controllers.Tests
{
    [TestClass()]
    public class ContactsControllerTests
    {
        public static ApplicationDbContext _context;
        public static UnitOfWork _unitOfWork;
        public static ContactService _contactsServices;
        public static ContactsController _contactsController;

   



        [TestInitialize]
        public async Task Initialized()
        {
            Mock<ISendGrid> _sendGrid = new Mock<ISendGrid>();

            _sendGrid.Setup(s => s.ContactEmail("correo@correo.com")).Returns(Task.CompletedTask);

            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "MemoryDBTest").Options;
            _context = new ApplicationDbContext(options);
            _unitOfWork = new(_context);
            _contactsServices = new(_unitOfWork, _sendGrid.Object);
            _contactsController = new(_contactsServices);


            List<Contact> listContacts = (List<Contact>)await _unitOfWork.ContactsRepository.GetAll();

            if(!(listContacts.Count>0))
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


        [TestMethod()]
        public async Task GetAll_shouldGetAllContact()
        {
            //Arrange

            

            //Act

            var result = await _contactsController.GetAll();
            OkObjectResult okResult = (OkObjectResult)result.Result;

            List<ContactDTO> contacts = (List<ContactDTO>)okResult.Value;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.IsTrue(contacts.Count > 0);
            
        }

        [TestMethod()]
        [DataRow(200, 2)]
        [DataRow(404, 8)]
        public async Task Get_ShouldGetContactById(int statusCode, int contactId)
        {
            //Arrange

            //Act

            ObjectResult result = (ObjectResult)(await _contactsController.Get(contactId)).Result;
            
            
            //Assert

            Assert.AreEqual(statusCode, result.StatusCode);
            
        }

        [TestMethod()]
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

            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod()]
        public async Task PutTest()
        {
            //Arrange

            Contact contact = new Contact
            {
                Id = 3,
                Name = "Juan Perez",
                Phone = 115433764,
                Email = "juan.perez@correo.com",
                Message = "Este es el mensaje modificado",
                TimeStamps = DateTime.Now,
                SoftDelete = false
            };

            //Act

            ObjectResult result = (ObjectResult)await _contactsController.Put(contact);

            //Assert

            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }
    }
}
