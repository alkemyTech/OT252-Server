using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Business;
using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private UserMapper _userMapper;
        private GenericResponse _response;

        public UserController(IUserService userService)
        {
            _userService = userService;
            _userMapper = new UserMapper();
            _response = new GenericResponse();
        }

        [Route("GetAll")]
        [HttpGet]

        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
        {
            try
            {
                var userList = await _userService.GetAll();
                if (userList == null)
                {
                    return NotFound();
                }
                return Ok(userList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            try
            {
                var userDto = await _userService.GetById(id);
                if (userDto == null)
                {
                    return NotFound();
                }
                return Ok(userDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]

        public async Task<ActionResult<UserDTO>> Post(UserDTO userDTO)

        {
            try
            {
                await _userService.Insert(userDTO);


                return Ok(userDTO);





            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPatch("{id}")]
        //[Authorize(Roles = "Administrador")]
        public async Task<ActionResult> Patch([Required]int id, [FromForm]CreationUserDto userDto)
        {
            try
            {
                var respuesta = await _userService.CheckUser(userDto.Email, id);
                if(respuesta == 1)
                {
                    return NotFound("El usuario no esta registrado");
                }else if (respuesta == 2)
                {
                    return BadRequest("El email ya esta registrado");
                }
                var respuesta2 = await _userService.CheckRole(userDto.RoleId);
                if(respuesta2 == 1)
                {
                    return NotFound("El rol no esta registrado");
                }
                var userUpdate = await _userService.Update(id, userDto);
                _response.Message = "Se ha modificado la información del usuario";
                _response.User = userUpdate;
                return Ok(_response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)

        {
            try
            {
                var deleteUsers = await _userService.Delete(id);
                if (!deleteUsers)
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

        private async Task<bool> CheckUserId(int id)
        {
            var user = await _userService.GetById(id);
            if (user == null)
            {
                return false;
            }
            return true;
        }
    }
}
