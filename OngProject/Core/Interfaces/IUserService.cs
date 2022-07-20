using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IUserService
    {
        IEnumerable<Users> GetAll();

        News GetById(int? id);

        IEnumerable<Users> Find(Expression<Func<Users, bool>> predicate);

        News Insert(Users user);
        News Update(Users user);
        bool Delete(int id);
        

    }
}
