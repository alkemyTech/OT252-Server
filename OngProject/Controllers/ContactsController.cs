using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Business;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {

        private readonly IContactService _contactService;

        public ContactsController(ContactService contactService)
        {
           _contactService = contactService;
        }

       
        [HttpGet]
        //[Authorize(Roles = "Administrador")]
        public ActionResult<IEnumerable<ContactDTO>> GetAll()
        {
            try
            {
                var contactsList = _contactService.GetAll();
                return Ok(contactsList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Contact> Get(int id)
        {
            try
            {
                var contact = _contactService.GetById(id);
                return Ok(contact);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Contact> Post([FromBody] Contact contact)
        {
            try
            {
                var newContact = _contactService.Insert(contact);

                return Ok(newContact);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public ActionResult<Contact> Put([FromBody] Contact contact)
        {
            try
            {
                var editContact = _contactService.Update(contact);

                return Ok(editContact);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                var deleteContact = _contactService.Delete(id);

                return Ok(true);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
