using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using OngProject.Core.Interfaces;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    /// <summary>
    /// Controlador para el mantenimiento de los comentarios de la ONG
    /// </summary>
    [SwaggerTag("Comments", Description = "Web API para los comentarios de la ONG")]
    [Route("api/[controller]")]
    [ApiController]
    
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsService commentService;
        private readonly IUnitOfWork unitOfWork;
        private GenericResponse _response;

        public CommentsController(ICommentsService commentService, IUnitOfWork unitOfWork)
        {
            this.commentService = commentService;
            this.unitOfWork = unitOfWork;
            _response = new GenericResponse();
        }

        /// GET: api/comments/get
        /// <summary>
        /// Obtiene todos los comentarios de la ONG.
        /// </summary>
        /// <remarks>
        /// Retorna un listado con todos los comentarios de la ONG.
        /// </remarks>
        /// <response code="401">Unauthorized. El usuario no se ha autentificado o no tiene perfil de administrador.</response>
        /// <response code="200">Ok. Devuelve el listado de los comentarios registrados.</response>
        /// <response code="400">BadRequest. Devuelve el error ocurrido en caso de que la operación no se realice.</response>
        /// <response code="404">NotFound. Devuelve el mensaje "No hay registros" en caso de que no hayan comentarios registrados.</response>
        /// <response code="500">InternalServerError. Devuelve el error que impide que la operación se realice.</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("/comments")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> Get()
        {
            try
            {
                if (await commentService.GetAll() is null)
                {
                    _response.IsSucces = false;
                    _response.DisplayMessage = "No hay registros";
                    return NotFound(_response);
                }
                _response.DisplayMessage = "Listado de comentarios";
                _response.Entity = await commentService.GetAll();
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorMessages = new List<string> { "Ha ocurrido un error", ex.ToString() };
                return BadRequest(_response);
            }
        }

        /// POST: api/comments/post
        /// <summary>
        /// Registra un comentario de la ONG.
        /// </summary>
        /// <remarks>
        /// Para registrar el comentario debe ingresar los campos requeridos *
        /// </remarks>
        /// <response code="401">Unauthorized. El usuario no se ha autentificado o no tiene perfil de administrador.</response>
        /// <response code="200">Ok. Devuelve un mensaje de éxito de la operación y la información del comentario registrado.</response>
        /// <response code="400">BadRequest. Devuelve el error ocurrido en caso de que la operación no se realice.</response>
        /// <response code="500">InternalServerError. Devuelve el error que impide que la operación se realice.</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult<Comment> Post(Comment comment)
        {
            if (unitOfWork.CommentRepository is null)
            {
                _response.IsSucces = false;
                _response.DisplayMessage = "No se ha podido registrar el comentario";
                return BadRequest(_response);
            }
            unitOfWork.CommentRepository.Insert(comment);
            unitOfWork.Save();
            _response.DisplayMessage = "Se ha registrado el comentario";
            _response.Entity = comment;
            return Ok(_response);
        }

        /// PUT: api/comments/update/:id
        /// <summary>
        /// Actualiza la información de un comentario pasando el id del mismo.
        /// </summary>
        /// <remarks>
        /// Para actualizar el comentario se deben ingresar los campos requeridos*
        /// </remarks>
        /// <response code="401">Unauthorized. El usuario no se ha autentificado o no tiene perfil de administrador.</response>
        /// <response code="200">Ok. Devuelve un mensaje de éxito de la operación y la información del comentario modificado.</response>
        /// <response code="400">BadRequest. Devuelve el error ocurrido en caso de que la operación no se realice.</response>
        /// <response code="404">NotFound. Devuelve un mensaje de registro no esta registrado si el id del comentario no corresponde a un registro.</response>
        /// <response code="500">InternalServerError. Devuelve el error que impide que la operación se realice.</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("/comments/")]
        public async Task<ActionResult<GenericResponse>> Put(int id, CommentDto commentDto)
        {
            try
            {
                var commentUpdated = await commentService.Update(id, commentDto);
                if(commentUpdated == null)
                {
                    _response.IsSucces = false;
                    _response.DisplayMessage = "El comentario no existe";
                    return NotFound(_response);
                }
                _response.DisplayMessage = "Se ha actualizado el comentario";
                _response.Entity = commentUpdated;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorMessages = new List<string> { "Ha ocurrido un error", ex.ToString() };
                return BadRequest(_response);
            }
        }

        /// DELETE: api/comments/delete/:id
        /// <summary>
        /// Elimina un comentario pasando el id del mismo.
        /// </summary>
        /// <remarks>
        /// Se elimina el comentario correspondiente al id entregado.
        /// </remarks>
        /// <response code="401">Unauthorized. El usuario no se ha autentificado o no tiene perfil de administrador.</response>
        /// <response code="200">Ok. Retorna un mensaje de "Se ha eliminado el registro" en caso de eliminar el comentario.</response>
        /// <response code="400">BadRequest. Devuelve el error ocurrido en caso de que la operación no se realice.</response>
        /// <response code="404">NotFound. Devuelve el mensaje "El registro no existe" en caso de que el id no corresponda a un comentario registrado.</response>
        /// <response code="500">InternalServerError. Devuelve el error que impide que la operación se realice.</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (unitOfWork.CommentRepository.GetById(id) is null)
            {
                _response.IsSucces = false;
                _response.DisplayMessage = "Comentario no existe";
                return NotFound(_response); 
            }
           // unitOfWork.CommentRepository.Delete(id);
            unitOfWork.Save();
            _response.DisplayMessage = "Se ha eliminado el comentario";
            return Ok(_response);
        }
    }
}
