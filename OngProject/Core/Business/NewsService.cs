using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class NewsService : INewsService
    {

        private IUnitOfWork _unitOfWork;

        public NewsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public  IEnumerable<News> Find(Expression<Func<News, bool>> predicate)
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

        public async Task<IEnumerable<Comment>> FindComment(Expression<Func<Comment, bool>> predicate)
        {
            var comment = await _unitOfWork.CommentRepository.Find(predicate);
            if(comment == null)
            {
                return null;
            }
            return comment;
        }
    }
}
