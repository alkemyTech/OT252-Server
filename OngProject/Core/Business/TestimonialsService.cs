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
    public class TestimonialsService : ITestimonialsService
    {

        private IUnitOfWork _unitOfWork;

        public TestimonialsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Testimony> Find(Expression<Func<Testimony, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Testimony> GetAll()
        {
            throw new NotImplementedException();
        }

        public Testimony GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Testimony Insert(Testimony testimony)
        {
            throw new NotImplementedException();
        }

        public Testimony Update(Testimony testimony)
        {
            throw new NotImplementedException();
        }
    }
}
