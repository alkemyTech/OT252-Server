using Microsoft.AspNetCore.Authorization;
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
    public class NewsController : ControllerBase
    {

        private readonly INewsService newService;

        public NewsController(NewsService newService)
        {
            this.newService = newService;
        }   

        [Route("GetAll")]
        [HttpGet]
        [Authorize]
        public ActionResult <IEnumerable<News>> GetAll()
        {

            try
            {
                var newsList = newService.GetAll();

                return Ok(newsList);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);  
            }
            
            
        }

        
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<News> Get(int id)
        {
            try
            {
                var news = newService.GetById(id);

                return Ok(news);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

       
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult<News> Post([FromBody] News news)
        {
            try
            {
                var newNews = newService.Insert(news);

                return Ok(newNews);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

     
        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public ActionResult<News> Put([FromBody] News news)
        {
            try
            {
                var editNews = newService.Update(news);

                return Ok(editNews);
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
                var deleteNews = newService.Delete(id);

                return Ok(true);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);  
            }
            
        }
    }
}
