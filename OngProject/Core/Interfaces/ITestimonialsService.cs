using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ITestimonialsService
    {
        IEnumerable<Testimony> GetAll();

        Testimony GetById(int? id);

        IEnumerable<Testimony> Find(Expression<Func<Testimony, bool>> predicate);

        Testimony Insert(Testimony testimony);
        Testimony Update(Testimony testimony);
        bool Delete(int id);
        

    }
}
