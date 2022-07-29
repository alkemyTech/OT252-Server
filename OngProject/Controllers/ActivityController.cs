using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Business;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {

        private readonly IActivityService activityService;

        public ActivityController(ActivityService activityService)
        {
            this.activityService = activityService;
        }

        [Route("GetAll")]
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<Activity>> GetAll()
        {
            try
            {
                var activityList = activityService.GetAll();
                return Ok(activityList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Activity> Get(int id)
        {
            try
            {
                var activity = activityService.GetById(id);
                return Ok(activity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/activities")]
        //[Authorize(Roles = "Administrador")]
        public ActionResult<ActivityDto> Post([FromBody] ActivityDto activityDto)
        {
            try
            {
                var newActivityDto = activityService.Insert(activityDto);

                return Ok(newActivityDto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public ActionResult<Activity> Put([FromBody] Activity activity)
        {
            try
            {
                var editActivity = activityService.Update(activity);

                return Ok(editActivity);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                var deleteActivity = activityService.Delete(id);

                return Ok(true);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
