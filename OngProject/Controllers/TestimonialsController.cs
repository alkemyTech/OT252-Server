using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using OngProject.Core.Business;
using OngProject.Core.Helper;
using OngProject.Core.Interfaces;
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

        public TestimonialsController(ITestimonialsService testimonialsService)
        {
            _testimonialsService = testimonialsService;
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

                PageHelper<TestimonyDTO> pageHelper = PageHelper<TestimonyDTO>.Create(testimonyList, page, 10);

                

                return Ok(pageHelper);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);  
            }
            
            
        }

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

                return Ok(newTestimony);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
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

                return Ok(editTestimony);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
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
                    return Ok(true);
                else
                    return NotFound($"No se pudo eliminar no se encontro testimonio id: {id}");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);  
            }
            
        }
    }
}
