﻿using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class ActivityService : IActivityService
    {
        private IUnitOfWork _unitOfWork;
        private ActivityMapper mapper;

        public ActivityService(IUnitOfWork unitOfWork)
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

        public async Task<ActivityDto> Insert(ActivityDto activityDto)
        {
            mapper = new ActivityMapper();
            Activity activity = mapper.ConvertToActivity(activityDto);

            await _unitOfWork.ActivityRepository.Insert(activity);
            _unitOfWork.Save();

            ActivityDto newActivityDto =  mapper.ConvertToDto(activity);
            return newActivityDto;
        }

        public Activity Update(Activity activity)
        {
            throw new NotImplementedException();
        }
    }
}
