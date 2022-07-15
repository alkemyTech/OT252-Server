using Microsoft.EntityFrameworkCore;
using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        protected readonly ApplicationDbContext context;
        protected DbSet<T> entities;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.entities = context.Set<T>();
        }

        public async Task Insert(T entity)
        {
           await entities.AddAsync(entity);
        }
        public async Task Update(T entity)
        {
             entities.Update(entity);    
        }
        public async Task Delete(T entity)
        {     
            await entities.Remove(entity);
        }

        public async Task<T> GetById(int? id) => await entities.FindAsync(id);
        public async Task<IEnumerable<T>> find(Expression<Func<T, bool>> predicate) => await entities.Where(predicate);
        public async Task<IEnumerable<T>> GetAll() => await entities.ToListAsync();
    }
}

