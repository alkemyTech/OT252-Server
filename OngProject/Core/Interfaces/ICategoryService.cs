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

        Task<ViewCategoryDto> GetById(int? id);

        IEnumerable<Category> Find(Expression<Func<Category, bool>> predicate);

        public Task<ViewCategoryDto> Insert(CreationCategoryDto categoryDto);
        Task<ViewCategoryDto> Update(int id, CreationCategoryDto category);
        Task<bool> Delete(int id);
        

    }
}
