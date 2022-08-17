using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;

namespace OngProject.Core.Mapper
{
    public class ActivityMapper
    {
        public IEnumerable<ActivityDto> ConvertListToDto(IEnumerable<Activity> listActivity)
        {
            List<ActivityDto> listDtos = new List<ActivityDto>();

            foreach (Activity activity in listActivity)
            {
                ActivityDto activityDto = new ActivityDto();
                activityDto.Name = activity.Name;
                activityDto.Content = activity.Content;
                activityDto.Image = activity.Image;

                listDtos.Add(activityDto);
            }
            return listDtos;
        }

        public ActivityDto ConvertToDto(Activity activity)
        {
            ActivityDto activityDto = new ActivityDto();
            activityDto.Name = activity.Name;
            activityDto.Content = activity.Content;
            activityDto.Image = activity.Image;

            return activityDto;
        }

        public Activity ConvertToActivity(ActivityDto activityDto)
        {
            Activity activity = new Activity();
            activity.Name = activityDto.Name;
            activity.Content = activityDto.Content;
            activity.Image = activityDto.Image;

            return activity;
        }

        public Activity ConvertToActivity(CreationActivityDto creationActivityDto)
        {
            var activity = new Activity();
            activity.Name = creationActivityDto.Name;
            activity.Content = creationActivityDto.Content;
            activity.TimeStamps = DateTime.Now;
            activity.SoftDelete = false;
            return activity;
        }
    }
}
