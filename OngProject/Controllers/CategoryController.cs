using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Business;
using OngProject.Core.Helper;
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
        public async Task<ActionResult<PageListDto<CategoryDto>>> GetAll(int page = 1)
        {
            try
                
            {
                var CategoryList = await _categoryService.GetAll();
                PageHelper<CategoryDto> pageHelper = PageHelper<CategoryDto>.Create(CategoryList, page, 10);
                PageListDto<CategoryDto> pages = new PageListDto<CategoryDto>(pageHelper, "Category");
                return Ok(pages);
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

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
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
