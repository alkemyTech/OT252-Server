using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    /// <summary>
    /// Controlador para el mantenimiento de las actividades de la ONG
    /// </summary>
    [OpenApiTag("Activity",
                Description = "Web API para el mantenimiento de actividades de la ONG.")]
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {

        private readonly IActivityService activityService;

        /// <summary>
        /// Constructor del controlador recibe IActivityService como dependencia
        /// </summary>
        public ActivityController(IActivityService activityService)
        {
            this.activityService = activityService;
        }

        /// GET: api/Activity/GetAll
        /// <summary>
        /// Obtiene todas las actividades de la ONG.
        /// </summary>
        /// <remarks>
        /// Esta api devuelve un List Activity con todas las actividades registradas por la ONG.
        /// </remarks>
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>              
        /// <response code="200">OK. Devuelve el listado de actividades.</response>        
        /// <response code="400">BadRequest. Un error al buscar los datos solicitados.</response>  
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("GetAll")]
        [HttpGet]
        //[Authorize(Roles = "Administrador")]
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

        /// GET: api/Activity/{id}
        /// <summary>
        /// Obtiene la actividad de la ONG con el id enviado.
        /// </summary>
        /// <remarks>
        /// Esta api busca todas las actividades registradas por la ONG.
        /// </remarks>
        /// <param name="id">Id (int) de la actividad.</param>
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>              
        /// <response code="200">OK. Devuelve la actividad con el id enviado.</response> 
        /// <response code="400">BadRequest. Un error al buscar los datos solicitados.</response>   
        /// <response code="404">NotFound. No se encontro la actividad con la id enviada.</response> 
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        /// POST: api/Activity
        /// <summary>
        /// Almacena una nueva actividad en la base de datos.
        /// </summary>
        /// <remarks>
        /// Esta api recibe una nueva actividad enviada en el body, y la inserta en la base de datos.
        /// </remarks>
        /// <param name="activityDto"> DTO de Actividad.</param>
        /// <response code="400">BadRequest. Un error al insertar los datos solicitados.</response>   
        /// <response code="401">Unauthorized. No se ha indicado, es incorrecto el Token JWT de acceso o no tiene rol de administrador.</response>              
        /// <response code="200">OK. Devuelve la actividad registrada.</response> 
        [HttpPost("/activities")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> Post([FromForm] CreationActivityDto creatrionActivityDto)
        {
            try
            {
                var newActivityDto =await activityService.Insert(creatrionActivityDto);
                return Ok(newActivityDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// PUT: api/Activity
        /// <summary>
        /// Actualiza una actividad registrada en la base de datos.
        /// </summary>
        /// <remarks>
        /// Esta api recibe una actividad enviada en el body, ya registrada en la base de datos y la actualiza.
        /// </remarks>
        /// <param name="activityDto"> Entidad Actividad.</param>
        /// /// <param name="id"> Id de la Actividad.</param>
        /// <response code="400">BadRequest. Un error al actualizar los datos solicitados.</response>   
        /// <response code="401">Unauthorized. No se ha indicado, es incorrecto el Token JWT de acceso o no tiene rol de administrador.</response>              
        /// <response code="404">NotFound. No se encontro la actividad con la id enviada para actualizar.</response> 
        /// <response code="200">OK. Devuelve la actividad actualizada.</response> 
        [HttpPut("/activities/")]
        //[Authorize(Roles = "Administrador")]
        public async Task<ActionResult<ActivityDto>> Put([FromBody] ActivityDto activityDto, int id)
        {
            try
            {
                var editActivity = await activityService.Update(id,activityDto);
                if (editActivity == null)
                {
                    return NotFound("La actividad enviada no existe");
                }

                return Ok(editActivity);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        /// DELETE: api/Activity
        /// <summary>
        /// Elimina una actividad con borrado suave.
        /// </summary>
        /// <remarks>
        /// Esta api recibe id de la actividad a borrar, y se actualiza el campo softDelete a true en la tabla
        /// </remarks>
        /// <param name="id"> Id (int) de la actividad.</param>
        /// <response code="400">BadRequest. Un error al borrar los datos solicitados.</response>   
        /// <response code="401">Unauthorized. No se ha indicado, es incorrecto el Token JWT de acceso o no tiene rol de administrador.</response>              
        /// <response code="404">NotFound. No se encontro la actividad con la id enviada para eliminar.</response> 
        /// <response code="200">OK. Devuelve la actividad con el campo softDelete actualizado.</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
