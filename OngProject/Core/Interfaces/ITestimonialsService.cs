using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ITestimonialsService
    {
        IEnumerable<TestimonyDTO> GetAll();

        TestimonyDTO GetById(int? id);

        IEnumerable<TestimonyDTO> Find(Expression<Func<Testimony, bool>> predicate);

        TestimonyDTO Insert(TestimonyDTO testimony);
        TestimonyDTO Update(TestimonyDTO testimony);
        Task<bool> Delete(int id);
        

    }
}
