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
        IEnumerable<ContactDTO> GetAll();

        ContactDTO GetById(int? id);

        IEnumerable<Contact> Find(Expression<Func<Contact, bool>> predicate);

        Contact Insert(Contact contact);
        Contact Update(Contact contact);
        bool Delete(int id);
        

    }
}
