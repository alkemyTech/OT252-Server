using OngProject.Core.Models.DTOs;
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

        Task<ActivityDto> GetById(int? id);

        IEnumerable<Activity> Find(Expression<Func<Activity, bool>> predicate);

        Task<ActivityDto> Insert(CreationActivityDto creationActivityDto);
        Task<ActivityDto> Update(int id,ActivityDto activity);
        bool Delete(int id);
    }
}
