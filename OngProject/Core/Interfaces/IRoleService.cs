using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace OngProject.Core.Interfaces
{
    public interface IRoleService
    {
        IEnumerable<Role> GetAll();

        Role GetById(int? id);

        IEnumerable<Role> Find(Expression<Func<Role, bool>> predicate);

        Role Insert(Role role);
        Role Update(Role role);
        bool Delete(int id);
    }
}
