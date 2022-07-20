using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Business;
using OngProject.Core.Interfaces;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(UserService userService)
        {
            //_userService = userService;
        }

        [Route("GetAll")]
        [HttpGet]
        public ActionResult<IEnumerable<Users>> GetAll()
        {

            try
            {
                var usersList = _userService.GetAll();

                return Ok(usersList);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }


        [HttpGet("{id}")]
        public ActionResult<Users> Get(int id)
        {
            try
            {
                var users = _userService.GetById(id);

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost]
        public ActionResult<Users> Post([FromBody] Users user)
        {
            try
            {
                var newUsers = _userService.Insert(user);

                return Ok(newUsers);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


        [HttpPut]
        public ActionResult<Users> Put([FromBody] Users user)
        {
            try
            {
                var editUser = _userService.Update(user);

                return Ok(editUser);
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
                var deleteUser = _userService.Delete(id);

                return Ok(true);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

    }
}
