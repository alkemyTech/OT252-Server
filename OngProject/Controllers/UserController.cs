using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
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
    /// <summary>
    /// Controlador para el mantenimiento de las actividades de la ONG
    /// </summary>
    [SwaggerTag("User",
                Description = "Web API para usuarios de la ONG.")]
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

        /// GET: api/user/getall
        /// <summary>
        /// Obtiene todas los usuarios de la ONG.
        /// </summary>
        /// <remarks>
        /// Retorna un listado con todos los usuarios de la ONG.
        /// </remarks>
        /// <response code="401">Unauthorized. El usuario no se ha autentificado o no tiene perfil de administrador.</response>
        /// <response code="200">Ok. Devuelve el listado de los usuarios registrados.</response>
        /// <response code="400">BadRequest. Devuelve el error ocurrido en caso de que la operación no se realize.</response>
        /// <response code="404">NotFound. Devuelve el mensaje "No hay registros" en caso de que no hayan usuarios registrados.</response>
        /// <response code="500">InternalServerError. Devuelve el error que impide que la operación se realize.</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("GetAll")]
        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
        {
            try
            {
                var userList = await _userService.GetAll();
                if (userList == null)
                {
                    return NotFound("No hay registros");
                }
                return Ok(userList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// GET: api/user/:id
        /// <summary>
        /// Obtiene un usuario de la ONG con el id pasado por parámetro.
        /// </summary>
        /// <remarks>
        /// Retorna un usuario.
        /// </remarks>
        /// <response code="401">Unauthorized. El usuario no se ha autentificado o no tiene perfil de administrador.</response>
        /// <response code="200">Ok. Devuelve la información del usuario.</response>
        /// <response code="400">BadRequest. Devuelve el error ocurrido en caso de que la operación no se realice.</response>
        /// <response code="404">NotFound. Devuelve el mensaje "Usuario no encontrado" en caso de que el id no corresponda a un usuario registrado.</response>
        /// <response code="500">InternalServerError. Devuelve el error que impide que la operación se realize.</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            try
            {
                var userDto = await _userService.GetById(id);
                if (userDto == null)
                {
                    return NotFound("Usuario no encontrado");
                }
                return Ok(userDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //EndPoint no implementado
        /*[HttpPost]

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

        }*/

        /// PATCH: api/user/:id
        /// <summary>
        /// Actualiza datos de un usuario de la ONG pasando el id del mismo.
        /// </summary>
        /// <remarks>
        /// Retorna el usuario con los datos modificados.
        /// </remarks>
        /// <response code="401">Unauthorized. El usuario no se ha autentificado o no tiene perfil de administrador.</response>
        /// <response code="200">Ok. Devuelve un mensaje de éxito de la operación y la información del usuario modificado.</response>
        /// <response code="400">BadRequest. Devuelve el error ocurrido en caso de que la operación no se realice.</response>
        /// <response code="404">NotFound. Devuelve un mensaje de registro no esta registrado si el id del usuario o el id del role entregados no corresponden a un registro.</response>
        /// <response code="500">InternalServerError. Devuelve el error que impide que la operación se realize.</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPatch("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<GenericResponse>> Patch([Required]int id, [FromForm]CreationUserDto userDto)
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

        /// DELETE: api/user/:id
        /// <summary>
        /// Elimina un usuario de la ONG pasando el id del mismo.
        /// </summary>
        /// <remarks>
        /// Retorna un mensaje de "Se ha eliminado el registro" en caso de éxito al eliminar.
        /// </remarks>
        /// <response code="401">Unauthorized. El usuario no se ha autentificado o no tiene perfil de administrador.</response>
        /// <response code="200">Ok. Retorna un mensaje de "Se ha eliminado el registro" en caso de eliminar e usuario.</response>
        /// <response code="400">BadRequest. Devuelve el error ocurrido en caso de que la operación no se realice.</response>
        /// <response code="404">NotFound. Devuelve el mensaje "El usuario no existe" en caso de que el id no corresponda a un usuario registrado.</response>
        /// <response code="500">InternalServerError. Devuelve el error que impide que la operación se realize.</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<string>> Delete(int id)

        {
            try
            {
                var deleteUsers = await _userService.Delete(id);
                if (!deleteUsers)
                {
                    return NotFound("El usuario no existe");
                }
                return Ok("Se ha eliminado el registro");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
