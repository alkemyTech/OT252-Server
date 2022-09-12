using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using OngProject.Core.Business;
using OngProject.Core.Helper;
using OngProject.Core.Interfaces;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    /// <summary>
    /// Controlador para el mantenimiento de las novedades de la ONG
    /// </summary>
    [OpenApiTag("Novedades",
                Description = "Web API para el mantenimiento de las Novedades de la ONG.")]
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {

        private readonly INewsService _newService;
        private readonly ICategoryService _categoryService;
        private readonly GenericResponse _response;

        /// <summary>
        /// Constructor del controlador recibe INewsService y ICategoryService como dependencia
        /// </summary>
        public NewsController(INewsService newService, ICategoryService categoryService)
        {
            _newService = newService;
            _categoryService = categoryService;
            _response = new GenericResponse();
        }


        /// GET: api/News/GetAll
        /// <summary>
        /// Obtiene todas las novedades de la ONG.
        /// </summary>
        /// <remarks>
        /// Esta api devuelve un List News con todas las actividades registradas por la ONG.
        /// </remarks>           
        /// <response code="200">OK. Devuelve el listado de las novedades.</response>        
        /// <response code="400">BadRequest. Un error al buscar los datos solicitados.</response>
        /// <response code="404">NotFound. No se encontraron novedades.</response> 
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("GetAll")]
        [HttpGet]
        public async Task <ActionResult<PageHelper<ViewNewsDto>>> GetAll(int page = 1)
        {

            try
            {
                var newsList = await _newService.GetAll();

                
                if (newsList == null)
                    return NotFound("No se encontraron novedades.");

                var prueba = PageHelper<ViewNewsDto>.Create(newsList, page, 10);

                NewsPagesDto pages = new NewsPagesDto(prueba);
                return Ok(pages);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorMessages = new List<string> { "Ha ocurrido un error", ex.ToString() };
                return BadRequest(_response);
            }
            
            
        }


        /// GET: api/News/{id}
        /// <summary>
        /// Obtiene la novedad de la ONG con el id enviado.
        /// </summary>
        /// <remarks>
        /// Esta api devuelve una novedad con el id enviado de todas las novedades registradas por la ONG.
        /// </remarks>
        /// <param name="id">Id (int) de la novedad.</param>              
        /// <response code="200">OK. Devuelve la novedad con el id enviado.</response> 
        /// <response code="400">BadRequest. Un error al buscar los datos solicitados.</response>   
        /// <response code="404">NotFound. No se encontro la novedad con la id enviada.</response> 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("/news")]
        public async Task<ActionResult<GenericResponse>> Get(int id)
        {
            try
            {
                var news =await _newService.GetById(id);
                if (news == null)
                {
                    _response.IsSucces = false;
                    _response.DisplayMessage = "Novedad no existe";
                    return NotFound(_response);
                }
                _response.DisplayMessage = "Información de la novedad";
                _response.Entity = news;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorMessages = new List<string> { "Ha ocurrido un error", ex.ToString() };
                return BadRequest(_response);
            }
            
        }

        // POST: api/News
        /// <summary>
        /// Almacena una nueva novedad en la base de datos.
        /// </summary>
        /// <remarks>
        /// Esta api recibe una nueva novedad enviada en el formulario, y la inserta en la base de datos.
        /// </remarks>
        /// <param name="creationNewsDto"> DTO de novedad.</param>
        /// <response code="400">BadRequest. Un error al insertar los datos solicitados.</response>   
        /// <response code="401">Unauthorized. No se ha indicado, es incorrecto el Token JWT de acceso o no tiene rol de administrador.</response>              
        /// <response code="200">OK. Devuelve la novedad registrada.</response> 
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<GenericResponse>> Post([FromForm]CreationNewsDto creationNewsDto)
        {
            try
            {
                if(creationNewsDto.CategoryId <= 0)
                {
                    _response.IsSucces = false;
                    _response.DisplayMessage = "El id de la categoria debe ser mayor a 0";
                    return BadRequest(_response);
                }
                var category = await _categoryService.GetById(creationNewsDto.CategoryId);
                if (category == null)
                {
                    _response.IsSucces = false;
                    _response.DisplayMessage = "El id de categoria ingresado no existe";
                    return NotFound(_response);
                }
                var newNews = await _newService.Insert(creationNewsDto);
                _response.DisplayMessage = "Se ha guardado el registro";
                _response.Entity = newNews;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorMessages = new List<string> { "Ha ocurrido un error", ex.ToString() };
                return BadRequest(_response);
            }
            
        }

        // PUT: api/News
        /// <summary>
        /// Actualiza una novedad registrada en la base de datos.
        /// </summary>
        /// <remarks>
        /// Esta api recibe una novedad enviada en el formulario, ya registrada en la base de datos y la actualiza.
        /// </remarks>
        /// <param name="news"> DTO de novedades.</param>
        /// <param name="id"> id de la novedad.</param>
        /// <response code="400">BadRequest. Un error al actualizar los datos solicitados.</response>   
        /// <response code="401">Unauthorized. No se ha indicado, es incorrecto el Token JWT de acceso o no tiene rol de administrador.</response>              
        /// <response code="404">NotFound. No se encontro la novedad con la id enviada para actualizar.</response> 
        /// <response code="200">OK. Devuelve la novedad actualizada.</response> 
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<GenericResponse>> Put([FromForm] CreationNewsDto news, int id)
        {
            try
            {
                var editNews = await _newService.Update(news, id);
                if (editNews == null)
                {
                    _response.IsSucces = false;
                    _response.DisplayMessage = $"El id de la news no es correcto, news id {id}";
                    return NotFound(_response);
                }
                _response.DisplayMessage = "Se ha actualizado la novedad";
                _response.Entity = editNews;
                return Ok(_response);
            }
            catch (Exception ex)
            {

                _response.IsSucces = false;
                _response.ErrorMessages = new List<string> { "Ha ocurrido un error", ex.ToString() };
                return BadRequest(_response);
            }
            
        }

        // DELETE: api/News
        /// <summary>
        /// Elimina una novedad con borrado suave.
        /// </summary>
        /// <remarks>
        /// Esta api recibe id de la novedad a borrar, y se actualiza el campo softDelete a true en la tabla
        /// </remarks>
        /// <param name="id"> Id (int) de la novedad.</param>
        /// <response code="400">BadRequest. Un error al borrar los datos solicitados.</response>   
        /// <response code="401">Unauthorized. No se ha indicado, es incorrecto el Token JWT de acceso o no tiene rol de administrador.</response>              
        /// <response code="404">NotFound. No se encontro la novedad con la id enviada para eliminar.</response> 
        /// <response code="200">OK. Devuelve la novedad actualizada.</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<GenericResponse>> Delete(int id)
        {
            try
            {
                var deleteCategory = await _newService.Delete(id);
                if (!deleteCategory)
                {
                    _response.IsSucces = false;
                    _response.DisplayMessage = "El registro no existe";
                    return BadRequest(_response);
                }
                _response.DisplayMessage = "Se ha eliminado el registro";
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorMessages = new List<string> { "Ha ocurrido un error", ex.ToString() };
                return BadRequest(_response);
            }

        }


        /// GET: api/{idNews}/comments
        /// <summary>
        /// Obtiene los comentarios de una novedad dada.
        /// </summary>
        /// <remarks>
        /// Esta api busca todos los comentarios de una novedad.
        /// </remarks>
        /// <param name="idNews">Id (int) de la novedad.</param>              
        /// <response code="200">OK. Devuelve los comentarios con el id de la novedad enviado.</response> 
        /// <response code="400">BadRequest. Un error al buscar los datos solicitados.</response>   
        /// <response code="404">NotFound. No se encontraron comentarios con la id enviada.</response> 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{idNews}/comments")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments(int idNews)
        {
            try
            {
                var comments = await _newService.FindComment(c => c.News_Id == idNews);
                if(comments == null)
                {
                    _response.IsSucces = false;
                    _response.DisplayMessage = "No hay comentarios";
                    return NotFound(_response);
                }
                _response.DisplayMessage = "Información del comentario";
                _response.Entity = comments;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorMessages = new List<string> { "Ha ocurrido un error", ex.ToString() };
                return BadRequest(_response);
            }
        }
    }
}
