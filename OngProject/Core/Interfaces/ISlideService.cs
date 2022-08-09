using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ISlideService
    {
        Task<IEnumerable<SlideDto>> GetAll();

        Task<SlideDto> GetById(int? id);
        Task<IEnumerable<SlideDto>> GetByOrganization(int? id);

        IEnumerable<Slide> Find(Expression<Func<Slide, bool>> predicate);

        Task<bool> Insert(SlideDto slide);
        Task<SlideDto> Update(int id,SlideDto slide);
        Task<bool> Delete(int id);
    }
}
