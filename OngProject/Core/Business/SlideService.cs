using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class SlideService : ISlideService
    {
        private UnitOfWork _unitOfWork;

        public SlideService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Slide> Find(Expression<Func<Slide, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Slide> GetAll()
        {
            throw new NotImplementedException();
        }

        public Slide GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Slide Insert(Slide slide)
        {
            throw new NotImplementedException();
        }

        public Slide Update(Slide slide)
        {
            throw new NotImplementedException();
        }
    }
}
