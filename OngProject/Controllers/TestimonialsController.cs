using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Business;
using OngProject.Core.Interfaces;
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

        public TestimonialsController(TestimonialsService testimonialsService)
        {
            _testimonialsService = testimonialsService;
        } 

        [Route("GetAll")]
        [HttpGet]
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
                var news = _testimonialsService.GetById(id);

                return Ok(news);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

       
        [HttpPost]
        public ActionResult<Testimony> Post([FromBody] Testimony testimony)
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
        public ActionResult<Testimony> Put([FromBody] Testimony testimony)
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
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                var deleteTestimony = _testimonialsService.Delete(id);

                return Ok(true);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);  
            }
            
        }
    }
}
