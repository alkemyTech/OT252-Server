using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAll();

        Task<CategoryDto> GetById(int? id);

        IEnumerable<Category> Find(Expression<Func<Category, bool>> predicate);

        public Task<CategoryDto> Insert(CreationCategoryDto categoryDto);
        Task<CategoryDto> Update(int id, CreationCategoryDto category);
        Task<bool> Delete(int id);
        

    }
}
