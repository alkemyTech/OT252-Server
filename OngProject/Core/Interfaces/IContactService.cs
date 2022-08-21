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
        Task<IEnumerable<ViewContactDTO>> GetAll();

        Task<ViewContactDTO> GetById(int? id);

        IEnumerable<ViewContactDTO> Find(Expression<Func<Contact, bool>> predicate);

        public Task<ViewContactDTO> Insert(ContactDTO contactDto);
        public Task<ViewContactDTO> Update(ContactDTO contactDto, int id);
        Task<bool> Delete(int id);
        

    }
}
