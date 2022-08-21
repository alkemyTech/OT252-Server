using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Mapper
{
    public class ContactMapper
    {

        public ContactDTO ToContactDTO(Contact contacto)
        {
            ContactDTO contactDTO = new ContactDTO()
            {

               
                Name = contacto.Name,
                Email = contacto.Email,
                Message = contacto.Message,
                Phone = contacto.Phone
            };

            return contactDTO;
        }

        public ViewContactDTO ToViewContactDTO(Contact contacto)
        {
            ViewContactDTO contactDTO = new ViewContactDTO()
            {

                Id = contacto.Id,
                Name = contacto.Name,
                Email = contacto.Email,
                Message = contacto.Message,
                Phone = contacto.Phone
            };

            return contactDTO;
        }


        public Contact ToContact(ContactDTO contactoDTO)
        {
            Contact contact = new Contact()
            {
                Name = contactoDTO.Name,
                Email = contactoDTO.Email,
                Message = contactoDTO.Message,
                Phone = contactoDTO.Phone,
                TimeStamps = DateTime.Now,
                SoftDelete = false
            };

            return contact;
        }


    }
}
