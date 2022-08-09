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
    public class SlideController : ControllerBase
    {

        private readonly ISlideService slideService;

        public SlideController(ISlideService slideService)
        {
            this.slideService = slideService;
        }

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
                    return NotFound();
                }
                return Ok(slideList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        //[Authorize]
        /// <summary>
        /// Trae todos los slides
        /// </summary>
        /// <remarks>
        /// Aquí una descripción mas larga si fuera necesario.Trae todos los slides
        /// </remarks>
        /// <param name="pais">Objeto a crear a la BD.</param>
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>              
        /// <response code="201">Created. Slide insertado correctamente creado en la BD.</response>        
        /// <response code="400">BadRequest. No se ha creado el slide en la BD. Formato del objeto incorrecto.</response>
        public async Task<ActionResult<Slide>> Get(int id)
        {
            try
            {
                var slide = await slideService.GetById(id);
                if (slide == null)
                {
                    return BadRequest();
                }
                return Ok(slide);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]

        public async Task <ActionResult<Slide>> Post(SlideDto slide)

        {
            try
            {
                if (await slideService.Insert(slide))
                {
                    return Ok(slide);
                }
                return BadRequest("Ya existe un slide con ese orden");                

                

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPut("/slides/")]
        //[Authorize(Roles = "Administrador")]
        public async Task<ActionResult<SlideDto>> Put([FromBody] SlideDto slideDto, int id)
        {
            try
            {
                var editSlide = await slideService.Update(id, slideDto);
                if(editSlide == null)
                {
                    return NotFound("El slide enviado no existe");
                }
                return Ok(editSlide);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<bool>> Delete(int id)

        {
            if (await slideService.Delete(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
