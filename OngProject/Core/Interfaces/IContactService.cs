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

        public Task<ContactDTO> Insert(ContactDTO contactDto);
        public Task<ContactDTO> Update(ContactDTO contactDto, int id);
        Task<bool> Delete(int id);
        

    }
}
