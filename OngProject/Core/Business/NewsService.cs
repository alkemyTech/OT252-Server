using OngProject.Core.Interfaces;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class NewsService : INewsService
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<News> Find(Expression<Func<News, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<News> GetAll()
        {
            throw new NotImplementedException();
        }

        public News GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public News Insert(News news)
        {
            throw new NotImplementedException();
        }

        public News Update(News news)
        {
            throw new NotImplementedException();
        }
    }
}
