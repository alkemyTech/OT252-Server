﻿using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class ContactService : IContactService
    {

        private readonly IUnitOfWork _unitOfWork;
        private ContactMapper _contactMapper;
        private readonly ISendGrid _sendgrid;

        public ContactService(IUnitOfWork unitOfWork, ISendGrid sendGrid)
        {
            _unitOfWork = unitOfWork;
            _contactMapper = new ContactMapper();
            _sendgrid = sendGrid;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var contact = await _unitOfWork.ContactsRepository.GetById(id);
                if (contact == null)
                {
                    return false;
                }
                await _unitOfWork.ContactsRepository.Delete(contact);
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception($"Error al borrar usuario: {ex}");
            }
            
        }

        public IEnumerable<ContactDTO> Find(Expression<Func<Contact, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ContactDTO>> GetAll()
        {
            try
            {
                ContactMapper mapper = new ContactMapper();

                List<Contact> contacts = (List<Contact>)await _unitOfWork.ContactsRepository.GetAll();
                               
                List<ContactDTO> contactsDTO = new List<ContactDTO>();
                

                foreach (Contact contact in contacts)
                {
                    contactsDTO.Add(mapper.ToContactDTO(contact));
                };
                
                return contactsDTO;
            }
            catch (Exception)
            {

                return new List<ContactDTO>();
            }
        }

        public async Task<ContactDTO> GetById(int? id)
        {
            var contact = await _unitOfWork.ContactsRepository.GetById(id);
            if (contact == null)
            {
                return null;
            }
            var contactDto = _contactMapper.ToContactDTO(contact);
            return contactDto;
        }

        public async Task<ContactDTO> Insert(ContactDTO contactDTO)
        {
            var contact = _contactMapper.ToContact(contactDTO);
            await _unitOfWork.ContactsRepository.Insert(contact);
            _unitOfWork.Save();
            await _sendgrid.ContactEmail(contact.Email);
            var contactDtoS = _contactMapper.ToContactDTO(contact);
            return contactDtoS;
        }

        public async Task<ContactDTO> Update(ContactDTO contactDTO, int id)
        {
            var contact = await _unitOfWork.ContactsRepository.GetById(id);
            if (contact == null)
            {
                return null;
            }

            contact.Email = contactDTO.Email;
            contact.Phone = contactDTO.Phone;
            contact.Message = contactDTO.Message;
            contact.Name = contactDTO.Name;

            await _unitOfWork.ContactsRepository.Update(contact);
            _unitOfWork.Save();

            var contactDto = _contactMapper.ToContactDTO(contact);
            return contactDto;
        }

       
    }
}
