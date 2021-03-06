using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IActivityService
    {
        IEnumerable<Activity> GetAll();

        Activity GetById(int? id);

        IEnumerable<Activity> Find(Expression<Func<Activity, bool>> predicate);

        Activity Insert(Activity activity);
        Activity Update(Activity activity);
        bool Delete(int id);
    }
}
