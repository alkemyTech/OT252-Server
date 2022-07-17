using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ISlideService
    {
        IEnumerable<Slide> GetAll();

        Slide GetById(int? id);

        IEnumerable<Slide> Find(Expression<Func<Slide, bool>> predicate);

        Slide Insert(Slide slide);
        Slide Update(Slide slide);
        bool Delete(int id);
    }
}
