using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Business;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;

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
        [Authorize]
        public ActionResult <IEnumerable<Testimony>> GetAll()
        {

            try
            {
                var newsList = _testimonialsService.GetAll();

                return Ok(newsList);
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
        public ActionResult<TestimonyDTO> Post([FromBody] TestimonyDTO testimony)
        {

            
            try
            {
                var newTestimony = _testimonialsService.Insert(testimony);

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
        //[Authorize(Roles = "Administrador")]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                var deleteTestimony = _testimonialsService.Delete(id).Result;

                if (deleteTestimony)
                    return Ok(true);
                else
                    return BadRequest("No se pudo eliminar");
            }
            catch(NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);  
            }
            
        }
    }
}
