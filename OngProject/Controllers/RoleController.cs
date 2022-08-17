using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Entities;
using System;
using System.Collections.Generic;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [Authorize(Roles = "Administrador")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [Route("GetAll")]
        [HttpGet]

        public ActionResult<IEnumerable<Role>> GetAll()
        {

            try
            {
                var newsList = roleService.GetAll();

                return Ok(newsList);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }


        [HttpGet("{id}")]
        public ActionResult<Role> Get(int id)
        {
            try
            {
                var news = roleService.GetById(id);

                return Ok(news);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost]
        public ActionResult<Role> Post([FromBody] Role role)
        {
            try
            {
                var newRole = roleService.Insert(role);

                return Ok(newRole);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


        [HttpPut]
        public ActionResult<Role> Put([FromBody] Role role)
        {
            try
            {
                var editRole = roleService.Update(role);

                return Ok(editRole);
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
                var deleteRole = roleService.Delete(id);

                return Ok(true);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}

