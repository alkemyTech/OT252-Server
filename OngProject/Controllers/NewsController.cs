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
    public class NewsController : ControllerBase
    {

        private readonly INewsService _newService;
        private readonly ICategoryService _categoryService;

        public NewsController(INewsService newService, ICategoryService categoryService)
        {
            _newService = newService;
            _categoryService = categoryService;
        }   

        [Route("GetAll")]
        [HttpGet]
        //[Authorize]
        public async Task <ActionResult<PageHelper<NewsDto>>> GetAll(int page = 1)
        {

            try
            {
                var newsList = await _newService.GetAll();
                var prueba = PageHelper<NewsDto>.Create(newsList, page, 2);
                NewsPagesDto pages = new NewsPagesDto(prueba);
                return Ok(pages);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
            
            
        }

        

        [HttpGet("/news")]
        public async Task<ActionResult<NewsDto>> Get(int id)
        {
            try
            {
                var news =await _newService.GetById(id);
                if (news == null)
                {
                    return NotFound();
                }
                

                return Ok(news);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

       
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> Post([FromForm]CreationNewsDto creationNewsDto)
        {
            try
            {
                if(creationNewsDto.CategoryId <= 0)
                {
                    return BadRequest("El id de la categoria debe ser mayor a 0");
                }
                var category = await _categoryService.GetById(creationNewsDto.CategoryId);
                if (category == null)
                {
                    return NotFound("El id de categoria ingresado no existe");
                }
                var newNews = await _newService.Insert(creationNewsDto);
                ResponseNews response = new ResponseNews();
                response.Message = "Se ha guardado el registro";
                response.News = newNews;
                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

     
        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<ViewNewsDto>> Put([FromForm] CreationNewsDto news, int id)
        {
            try
            {
                var editNews = await _newService.Update(news, id);

                if (editNews == null)
                    return NotFound($"El id de la news no es correcto, news id {id}");

                return Ok(editNews);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }


        [HttpDelete("{id}")]
        //[Authorize(Roles = "Administrador")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var deleteCategory = await _newService.Delete(id);
                if (!deleteCategory)
                {
                    return BadRequest("El registro no existe");
                }
                return Ok("Se ha eliminado el registro");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{idNews}/comments")]
        
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments(int idNews)
        {
            try
            {
                var comments = await _newService.FindComment(c => c.News_Id == idNews);
                if(comments == null)
                {
                    return NotFound("No hay comentarios");
                }
                return Ok(comments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private class ResponseNews
        {
            public string Message { get; set; }
            public object News { get; set; }
        }
    }
}
