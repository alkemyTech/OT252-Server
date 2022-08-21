using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
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
        private IImageHelper _imageHelper;
        private ActivityMapper mapper;

        public ActivityService(IUnitOfWork unitOfWork,IImageHelper imageHelper)
        {
            _unitOfWork = unitOfWork;
            this._imageHelper = imageHelper;
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

        public async Task<ActivityDto> GetById(int? id)
        {
            var response = await _unitOfWork.ActivityRepository.GetById(id);
            if(response != null)
            {
                mapper = new ActivityMapper();
                var activityDto = mapper.ConvertToDto(response);
                return activityDto;
            }
            return null;
        }

        public async Task<ActivityDto> Insert(CreationActivityDto creationActivityDto)
        {
            mapper = new ActivityMapper();
            var imgUrl = await _imageHelper.UploadImage(creationActivityDto.Image);
            Activity activity = mapper.ConvertToActivity(creationActivityDto);
            activity.Image = imgUrl.ToString();
            await _unitOfWork.ActivityRepository.Insert(activity);
            _unitOfWork.Save();

            ActivityDto newActivityDto =  mapper.ConvertToDto(activity);
            return newActivityDto;
        }

        public async Task<ActivityDto> Update(int id,ActivityDto activityDto)
        {
            try
            {
                mapper = new ActivityMapper();
                Activity activity = await _unitOfWork.ActivityRepository.GetById(id);

                if(activity == null)
                {
                    return null;
                }

                activity.Name = activityDto.Name;
                activity.Content = activityDto.Content;
                activity.Image = activityDto.Image;

                await _unitOfWork.ActivityRepository.Update(activity);
                _unitOfWork.Save();

                ActivityDto updatedActivityDto = mapper.ConvertToDto(activity);
                return updatedActivityDto;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
