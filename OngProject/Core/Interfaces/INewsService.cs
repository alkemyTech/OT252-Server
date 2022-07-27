using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface INewsService
    {
        IEnumerable<News> GetAll();

        Task<News> GetById(int? id);

        IEnumerable<News> Find(Expression<Func<News, bool>> predicate);

        News Insert(News news);
        News Update(News news);
        bool Delete(int id);

        Task<IEnumerable<Comment>> FindComment(Expression<Func<Comment, bool>> predicate);



    }
}
