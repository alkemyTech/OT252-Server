using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IOrganizationsService
    {
        IEnumerable<Organization> GetAll();

        News GetById(int? id);

        IEnumerable<Organization> Find(Expression<Func<Organization, bool>> predicate);

        News Insert(Organization organization);
        News Update(Organization organization);
        bool Delete(int id);
        

    }
}
