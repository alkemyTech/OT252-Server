using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {

        private readonly IActivityService activityService;

        public ActivityController(IActivityService activityService)
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
        public async Task<ActionResult> Post([FromBody] ActivityDto activityDto)
        {
            try
            {
                var newActivityDto =await activityService.Insert(activityDto);
                return Ok(newActivityDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("/activities/")]
        //[Authorize(Roles = "Administrador")]
        public async Task<ActionResult> Put([FromBody] ActivityDto activityDto, int id)
        {
            try
            {
                var editActivity = await activityService.GetById(id);
                if (editActivity != null)
                {
                    var updatedActivity = activityService.Update(activityDto);
                    var retorno = activityService.GetById(id);
                    return Ok(retorno);
                }
                else
                {
                    return NotFound("La actividad enviada no existe");
                }
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
