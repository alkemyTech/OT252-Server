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
    public class ActivityService : IActivityService
    {
        private UnitOfWork _unitOfWork;

        public ActivityService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Activity> Find(Expression<Func<Activity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Activity> GetAll()
        {
            throw new NotImplementedException();
        }

        public Activity GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Activity Insert(Activity activity)
        {
            throw new NotImplementedException();
        }

        public Activity Update(Activity activity)
        {
            throw new NotImplementedException();
        }
    }
}
