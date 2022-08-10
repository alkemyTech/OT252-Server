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

        public ContactsController(IContactService contactService)
        {
           _contactService = contactService;
        }

       
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ContactDTO>>> GetAll()
        {
            try
            {
                var contactsList = await _contactService.GetAll();
                return Ok(contactsList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Contact>> Get(int id)
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
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> Post([FromBody] ContactDTO contactDTO)
        {
            try
            {
                var newContact = await _contactService.Insert(contactDTO);
                ResponseContact response = new ResponseContact();
                response.Message = "Se ha guardado el registro";
                response.Contact = newContact;
                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
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

        private class ResponseContact
        {
            public string Message { get; set; }
            public object Contact { get; set; }
        }
    }
}
