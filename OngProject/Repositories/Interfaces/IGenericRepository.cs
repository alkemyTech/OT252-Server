using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace OngProject.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> GetById(int? id);
    }
}
