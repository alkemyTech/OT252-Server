using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();

        Category GetById(int? id);

        IEnumerable<Category> Find(Expression<Func<Category, bool>> predicate);

        News Insert(Category category);
        News Update(Category category);
        bool Delete(int id);
        

    }
}
