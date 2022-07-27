﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Business;
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

        
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Category> Get(int id)
        {
            try
            {
                var category = _categoryService.GetById(id);

                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
               
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult<Category> Post([FromBody] Category category)
        {
            try
            {
                var newCategory = _categoryService.Insert(category);

                return Ok(newCategory);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

     
        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public ActionResult<Category> Put([FromBody] Category category)
        {
            try
            {
                var editCategory = _categoryService.Update(category);

                return Ok(editCategory);
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
                var deleteCategory = _categoryService.Delete(id);

                return Ok(true);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);  
            }
            
        }
    }
}
