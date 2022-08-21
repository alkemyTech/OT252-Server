using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using OngProject.Core.Business;
using OngProject.Core.Interfaces;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    /// <summary>
    /// Controlador para el mantenimiento de los Slide de la ONG
    /// </summary>
    [SwaggerTag("Slide", Description = "Web API de los Slide de la ONG")]
    [Route("api/[controller]")]
    [ApiController]
    public class SlideController : ControllerBase
    {

        private readonly ISlideService slideService;
        private readonly GenericResponse _response;

        public SlideController(ISlideService slideService)
        {
            this.slideService = slideService;
            _response = new GenericResponse();
        }

        /// <summary>
        /// Obtiene todas los slide de la ONG.
        /// </summary>
        /// <remarks>
        /// Retorna un listado con todo los slide de la ONG.
        /// </remarks>
        /// <response code="401">Unauthorized. El usuario no se ha autentificado o no tiene perfil de administrador.</response>
        /// <response code="200">Ok. Devuelve el listado de los slide registrados.</response>
        /// <response code="400">BadRequest. Devuelve el error ocurrido en caso de que la operación no se realice.</response>
        /// <response code="404">NotFound. Devuelve el mensaje "No hay registros" en caso de que no hayan slides registrados.</response>
        /// <response code="500">InternalServerError. Devuelve el error que impide que la operación se realice.</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("GetAll")]
        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<IEnumerable<Slide>>> GetAll()
        {
            try
            {
                var slideList = await slideService.GetAll();
                if (slideList == null)
                {
                    _response.IsSucces = false;
                    _response.DisplayMessage = "No hay Slides registrados";
                    return NotFound(_response);
                }
                _response.DisplayMessage = "Lista de slides";
                _response.Entity = slideList;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorMessages = new List<string> { "Ha ocurrido un error", ex.ToString() };
                return BadRequest(_response);
            }
        }

        /// <summary>
        /// Obtiene un slide de la ONG con el id pasado por parámetro.
        /// </summary>
        /// <remarks>
        /// Retorna un slide.
        /// </remarks>
        /// <response code="401">Unauthorized. El usuario no se ha autentificado o no tiene perfil de administrador.</response>
        /// <response code="200">Ok. Devuelve la información del slide.</response>
        /// <response code="400">BadRequest. Devuelve el error ocurrido en caso de que la operación no se realice.</response>
        /// <response code="404">NotFound. Devuelve un mensaje de error en caso de que el id no corresponda a un slide registrado.</response>
        /// <response code="500">InternalServerError. Devuelve el error que impide que la operación se realice.</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Slide>> Get(int id)
        {
            try
            {
                var slide = await slideService.GetById(id);
                if (slide == null)
                {
                    _response.IsSucces = false;
                    _response.DisplayMessage = "Slide no existe";
                    return NotFound(_response);
                }
                _response.DisplayMessage = "Información del Slide";
                _response.Entity = slide;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorMessages = new List<string> { "Ha ocurrido un error", ex.ToString() };
                return BadRequest(_response);
            }
        }

        /// <summary>
        /// Registra un slide de la ONG.
        /// </summary>
        /// <remarks>
        /// Para registrar un slide debe ingresar los campos requeridos *.
        /// </remarks>
        /// <response code="401">Unauthorized. El usuario no se ha autentificado o no tiene perfil de administrador.</response>
        /// <response code="200">Ok. Devuelve un mensaje de éxito de la operación y la información del slide registrado.</response>
        /// <response code="400">BadRequest. Devuelve el error ocurrido en caso de que la operación no se realice.</response>
        /// <response code="500">InternalServerError. Devuelve el error que impide que la operación se realice.</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]

        public async Task <ActionResult<Slide>> Post(SlideDto slide)

        {
            try
            {
                if (await slideService.Insert(slide))
                {
                    _response.DisplayMessage = "Se ha registrado el slide";
                    _response.Entity = slide;
                    return Ok(_response);
                }
                _response.IsSucces = false;
                _response.DisplayMessage = "Ya existe un slide con ese orden";
                return BadRequest(_response);                

            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorMessages = new List<string> { "Ha ocurrido un error", ex.ToString() };
                return BadRequest(_response);
            }

        }

        /// <summary>
        /// Actualiza la información del slide de la ONG pasando el id de la mismo.
        /// </summary>
        /// <remarks>
        /// Para actualizar el slide debe ingresar los campos requeridos *.
        /// </remarks>
        /// <response code="401">Unauthorized. El usuario no se ha autentificado o no tiene perfil de administrador.</response>
        /// <response code="200">Ok. Devuelve un mensaje de éxito de la operación y la información de la categoria modificada.</response>
        /// <response code="400">BadRequest. Devuelve el error ocurrido en caso de que la operación no se realice.</response>
        /// <response code="404">NotFound. Devuelve un mensaje de registro no esta registrado si el id del slide no corresponde a un registro.</response>
        /// <response code="500">InternalServerError. Devuelve el error que impide que la operación se realice.</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("/slides/")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<SlideDto>> Put([FromBody] SlideDto slideDto, int id)
        {
            try
            {
                var editSlide = await slideService.Update(id, slideDto);
                if(editSlide == null)
                {
                    _response.IsSucces = false;
                    _response.DisplayMessage = "El slide enviado no existe";
                    return NotFound(_response);
                }
                _response.DisplayMessage = "Se ha actualizado el slide";
                _response.Entity = editSlide;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorMessages = new List<string> { "Ha ocurrido un error", ex.ToString() };
                return BadRequest(_response);
            }

        }

        /// <summary>
        /// Elimina un slide de la ONG pasando el id de la mismo.
        /// </summary>
        /// <remarks>
        /// Se elimina el slide correspondiente al id entregado.
        /// </remarks>
        /// <response code="401">Unauthorized. El usuario no se ha autentificado o no tiene perfil de administrador.</response>
        /// <response code="200">Ok. Retorna un mensaje de "Se ha eliminado el registro" en caso de eliminar la categoría.</response>
        /// <response code="400">BadRequest. Devuelve el error ocurrido en caso de que la operación no se realice.</response>
        /// <response code="404">NotFound. Devuelve el mensaje "El registro no existe" en caso de que el id no corresponda a un slide registrado.</response>
        /// <response code="500">InternalServerError. Devuelve el error que impide que la operación se realice.</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]

        public async Task<ActionResult<bool>> Delete(int id)

        {
            if (await slideService.Delete(id))
            {
                _response.DisplayMessage = "Se ha eliminado el slide";
                return Ok(_response);
            }
            else
            {
                _response.IsSucces = false;
                _response.DisplayMessage = "Slide no existe";
                return NotFound(_response);
            }

        }
    }
}
