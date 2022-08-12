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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    /// <summary>
    /// Controlador para el mantenimiento de las categorías de las novedades de la ONG
    /// </summary>
    [SwaggerTag("Category", Description = "Web API para las categorías de las novedades de la ONG")]
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;
        private GenericResponse _response;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _response = new GenericResponse();
        }

        /// GET: api/categories/getall
        /// <summary>
        /// Obtiene todas las categorías de las novedades de la ONG.
        /// </summary>
        /// <remarks>
        /// Retorna un listado con todas las categorías de las novedades de la ONG.
        /// </remarks>
        /// <response code="401">Unauthorized. El usuario no se ha autentificado o no tiene perfil de administrador.</response>
        /// <response code="200">Ok. Devuelve el listado de las categorías registradas.</response>
        /// <response code="400">BadRequest. Devuelve el error ocurrido en caso de que la operación no se realice.</response>
        /// <response code="404">NotFound. Devuelve el mensaje "No hay registros" en caso de que no hayan categorías registradas.</response>
        /// <response code="500">InternalServerError. Devuelve el error que impide que la operación se realice.</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("GetAll")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
        {
            try
            {
                var categoryList = await _categoryService.GetAll();
                if(categoryList == null)
                {
                    return NotFound("No hay registros");
                }
                return Ok(categoryList);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);  
            }
        }


        /// GET: api/categories/:id
        /// <summary>
        /// Obtiene una categoría de novedades de la ONG con el id pasado por parámetro.
        /// </summary>
        /// <remarks>
        /// Retorna una categoría.
        /// </remarks>
        /// <response code="401">Unauthorized. El usuario no se ha autentificado o no tiene perfil de administrador.</response>
        /// <response code="200">Ok. Devuelve la información de la categoría.</response>
        /// <response code="400">BadRequest. Devuelve el error ocurrido en caso de que la operación no se realice.</response>
        /// <response code="404">NotFound. Devuelve el error 404 en caso de que el id no corresponda a una categoría registrada.</response>
        /// <response code="500">InternalServerError. Devuelve el error que impide que la operación se realice.</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("/categories")]
        public async Task<ActionResult<CategoryDto>> Get(int id)
        {
            try
            {
                var category =await _categoryService.GetById(id);
                if (category == null)
                {
                    return NotFound();
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        /// POST: api/categories/:id
        /// <summary>
        /// Registra una categoría de novedades de la ONG.
        /// </summary>
        /// <remarks>
        /// Para registrar la categoría debe ingresar los siguientes campos requeridos *
        /// Nombre, este debe empezar con una letra y puede contener caracteres alfanúmericos y espacios. 
        /// Descripción y su Imagen.
        /// </remarks>
        /// <response code="401">Unauthorized. El usuario no se ha autentificado o no tiene perfil de administrador.</response>
        /// <response code="200">Ok. Devuelve un mensaje de éxito de la operación y la información de la categoría registrada.</response>
        /// <response code="400">BadRequest. Devuelve el error ocurrido en caso de que la operación no se realice.</response>
        /// <response code="500">InternalServerError. Devuelve el error que impide que la operación se realice.</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> Post([FromForm] CreationCategoryDto categorydto)
        {
            try
            {
                if (!Regex.IsMatch(categorydto.Name, "^[a-zA-Z][a-zA-Z0-9 ]*$"))
                {
                    return BadRequest("El nombre debe empezar con una letra, tener caracteres alfanúmericos, y puede tener espacios ");
                }
                var newCategory = await _categoryService.Insert(categorydto);
                _response.Message = "Se ha guardado el registro";
                _response.Entity = newCategory;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// PUT: api/categories/:id
        /// <summary>
        /// Actualiza de la categoría de novedades de la ONG pasando el id de la misma.
        /// </summary>
        /// <remarks>
        /// Para actualizar la categoría se deben ingresar ingresar el id de la categoría y los siguientes datos requeridos *
        /// Nombre, Descripción y su Imagen.
        /// </remarks>
        /// <response code="401">Unauthorized. El usuario no se ha autentificado o no tiene perfil de administrador.</response>
        /// <response code="200">Ok. Devuelve un mensaje de éxito de la operación y la información del usuario modificado.</response>
        /// <response code="400">BadRequest. Devuelve el error ocurrido en caso de que la operación no se realice.</response>
        /// <response code="404">NotFound. Devuelve un mensaje de registro no esta registrado si el id de la categoría corresponden a un registro.</response>
        /// <response code="500">InternalServerError. Devuelve el error que impide que la operación se realice.</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<CategoryDto>> Put([FromForm] CreationCategoryDto category, int id)
        {
            try
            {
                var editCategory = await _categoryService.Update(id,category);

                if(editCategory == null)
                    return NotFound($"No se encontro la categoria con el id {id}");

                return Ok(editCategory);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        /// DELETE: api/categories/:id
        /// <summary>
        /// Elimina una categoría de novedades de la ONG pasando el id de la misma.
        /// </summary>
        /// <remarks>
        /// Se elimina la categoría correspondiente al id entregado.
        /// </remarks>
        /// <response code="401">Unauthorized. El usuario no se ha autentificado o no tiene perfil de administrador.</response>
        /// <response code="200">Ok. Retorna un mensaje de "Se ha eliminado el registro" en caso de eliminar la categoría.</response>
        /// <response code="400">BadRequest. Devuelve el error ocurrido en caso de que la operación no se realice.</response>
        /// <response code="404">NotFound. Devuelve el mensaje "El registro no existe" en caso de que el id no corresponda a una categoría registrada.</response>
        /// <response code="500">InternalServerError. Devuelve el error que impide que la operación se realice.</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var deleteCategory = await _categoryService.Delete(id);
                if (!deleteCategory)
                {
                    return NotFound("El registro no existe");
                }
                return Ok("Se ha eliminado el registro");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
            
        }
    }
}
