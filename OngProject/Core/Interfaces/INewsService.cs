using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface INewsService
    {
        Task<List<ViewNewsDto>> GetAll();

        Task<NewsDto> GetById(int? id);

        IEnumerable<News> Find(Expression<Func<News, bool>> predicate);

        public Task<ViewNewsDto> Insert(CreationNewsDto newsDto);
        Task<ViewNewsDto> Update(CreationNewsDto news, int id);
        Task<bool> Delete(int id);

        Task<IEnumerable<Comment>> FindComment(Expression<Func<Comment, bool>> predicate);



    }
}
