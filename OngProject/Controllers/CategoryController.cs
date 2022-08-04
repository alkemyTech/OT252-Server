using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Business;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }   

        [Route("GetAll")]
        [HttpGet]
        [Authorize]
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

        [HttpPost]
        //[Authorize(Roles = "Administrador")]
        public async Task<ActionResult> Post([FromForm] CreationCategoryDto categorydto)
        {
            try
            {
                if (!Regex.IsMatch(categorydto.Name, "^[a-zA-Z][a-zA-Z0-9 ]*$"))
                {
                    return BadRequest("El nombre debe empezar con una letra, tener caracteres alfanúmericos, y puede tener espacios ");
                }
                var newCategory = await _categoryService.Insert(categorydto);
                ResponseCategory response = new ResponseCategory();
                response.Mensaje = "Se ha guardado el registro";
                response.Category = newCategory;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        public ActionResult<Category> Put(int id,[FromBody] Category category)
        {
            try
            {
                var editCategory = _categoryService.Update(id,category);

                if(editCategory == null)
                    return NotFound($"No se encontro la categoria co el id {id}");

                return Ok(editCategory);
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
                var deleteCategory = await _categoryService.Delete(id);
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

        private class ResponseCategory
        {
            public string Mensaje { get; set; }
            public object Category { get; set; }
        }
    }
}
