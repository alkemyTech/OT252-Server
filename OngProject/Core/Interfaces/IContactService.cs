using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDTO>> GetAll();

        Task<ContactDTO> GetById(int? id);

        IEnumerable<ContactDTO> Find(Expression<Func<Contact, bool>> predicate);

        public Task<Contact> Insert(ContactDTO contactDto);
        Contact Update(Contact contact);
        bool Delete(int id);
        

    }
}
