using Microsoft.AspNetCore.Authorization;
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
    /// Controlador para testimonios de la ONG
    /// </summary>
    [SwaggerTag("Testimonials",
                Description = "Web API para los testimonios de la ONG.")]
    [Route("api/[controller]")]
    [ApiController]

    public class TestimonialsController : ControllerBase
    {

        private readonly ITestimonialsService _testimonialsService;
        private readonly GenericResponse _response;

        public TestimonialsController(ITestimonialsService testimonialsService)
        {
            _testimonialsService = testimonialsService;
            _response = new GenericResponse();
        }


        /// GET: api/Tetimonials/GetAll
        /// <summary>
        /// Obtiene todos los testimonios de la ONG.
        /// </summary>
        /// <remarks>
        /// Devuelve todos los testimonios de la ONG.
        /// </remarks>
        [Route("GetAll")]
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<PageHelper<TestimonyDTO>>> GetAll(int page = 1)
        {

            try
            {
                var testimonyList = await _testimonialsService.GetAll();

                var helper = PageHelper<TestimonyDTO>.Create(testimonyList, page, 10);

                PageListDto<TestimonyDTO> pageList = new PageListDto<TestimonyDTO>(helper, "Testimonials");

                return Ok(pageList);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorMessages = new List<string> { "Ha ocurrido un error", ex.ToString() };
                return BadRequest(_response);
            }
            
            
        }

        /*
        /// GET: api/Tetimonials/:id
        /// <summary>
        /// Devuelve un testimonio con el id introducido.
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<Testimony> Get(int id)
        {
            try
            {
                var testimonyDTO = _testimonialsService.GetById(id);

                return Ok(testimonyDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        */

        /// POST: api/Tetimonials/
        /// <summary>
        /// Introduce un nuevo testimonio.
        /// Campo obligatorio de introducir: Nombre
        /// </summary>
        /// <remarks>
        /// Devuelve el testimonio agregado.
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult<TestimonyDTO>> Post([FromForm] CreationTestimonyDTO testimony)
        {
            try
            {
                var newTestimony = await _testimonialsService.Insert(testimony);
                _response.DisplayMessage = "Se ha registrado el testimonio";
                _response.Entity = newTestimony;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorMessages = new List<string> { "Ha ocurrido un error", ex.ToString() };
                return BadRequest(_response);
            }
            
        }

        
        /// PUT: api/Tetimonials/
        /// <summary>
        /// Actualiza el testimonio que se envía.
        /// </summary>
        /// <remarks>
        /// Devuelve el testimonio actualizado.
        /// </remarks>
        [HttpPut]
        public ActionResult<TestimonyDTO> Put([FromBody] TestimonyDTO testimony)
        {
            try
            {
                var editTestimony = _testimonialsService.Update(testimony);
                _response.DisplayMessage = "Se ha actualizado el testimonio";
                _response.Entity = editTestimony;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorMessages = new List<string> { "Ha ocurrido un error", ex.ToString() };
                return BadRequest(_response);
            }
            
        }
        

        /// Delete: api/Tetimonials/id
        /// <summary>
        /// Elimina un testimonio existente por el id.
        /// </summary>
        /// <remarks>
        /// Retorna verdadero o falso si fue eliminado correctamente.
        /// </remarks>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                var deleteTestimony = _testimonialsService.Delete(id);

                if (deleteTestimony.Result)
                {
                    _response.DisplayMessage = "Se ha eliminado el testimonio";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSucces = false;
                    _response.DisplayMessage = $"No se pudo eliminar no se encontro testimonio id: {id}";
                    return NotFound(_response);
                }
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
