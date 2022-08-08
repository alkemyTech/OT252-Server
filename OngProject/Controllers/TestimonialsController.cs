using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    [Route("api/[controller]")]
    [ApiController]

    public class TestimonialsController : ControllerBase
    {

        private readonly ITestimonialsService _testimonialsService;

        public TestimonialsController(ITestimonialsService testimonialsService)
        {
            _testimonialsService = testimonialsService;
        } 

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
