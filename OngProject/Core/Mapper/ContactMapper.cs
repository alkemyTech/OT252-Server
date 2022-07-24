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
            ContactDTO contactoDTO = new ContactDTO()
            {

               
                Name = contacto.Name,
                Email = contacto.Email,
                Message = contacto.Message,
                Phone = contacto.Phone
            };

            return contactoDTO;
        }


        public Contact ToContact(ContactDTO contactoDTO)
        {
            Contact contacto = new Contact()
            {
                Name = contactoDTO.Name,
                Email = contactoDTO.Email,
                Message = contactoDTO.Message,
                Phone = contactoDTO.Phone
            };

            return contacto;
        }


    }
}
