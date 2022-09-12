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
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    /// <summary>
    /// Controlador para el registro y Logeo de usuarios de la ONG
    /// </summary>
    [SwaggerTag("Login",
                Description = "Web API para Registro y Login de la ONG.")]
    [Route("api/auth")]  //Aca le cambie el controller por auth para adaptarlo a lo que pedian las OT252-30 y 31
    [ApiController]
    public class LoginController : ControllerBase
    {


        private readonly ILoginService _loginService;
        private RegisterMapper _mapper;
        private GenericResponse _response;
        private readonly IUserService _userService;

        public LoginController(ILoginService loginService, IUserService userService)
        {
            _loginService = loginService;
            _mapper = new RegisterMapper();
            _response = new GenericResponse();
            _userService = userService;
        }
        /// <summary>
        /// Endpoind para Logeo
        /// </summary>
        /// Para iniciar sesión debe ingresar su Email y contraseña
        /// <response code="200">Ok. Devuelve un mensaje de éxito de la operación y la información de la categoría registrada.</response>
        /// <response code="400">BadRequest. Devuelve el error ocurrido en caso de que la operación no se realice.</response>
        /// <response code="404">NotFound. Devuelve un mensaje de "Email o contraseña no validos".</response>
        /// <response code="500">InternalServerError. Devuelve el error que impide que la operación se realice.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<GenericResponse>> Login(string email, string password)
        {
            var response = await _loginService.Login(email, password);
            if (response is null)
            {
                _response.IsSucces = false;
                _response.DisplayMessage = "Email o contraseña no validos";
                return NotFound(_response);
            }
            _response.DisplayMessage = "Se ha iniciado la sesión";
            _response.Entity = response;
            return Ok(_response);
        }
        /// <summary>
        /// Endpoind para Registrar
        /// </summary>
        /// <remarks>
        /// /// Para registrar al usuario debe ingresar los campos requeridos*.
        /// </remarks>
        /// <response code="200">Ok. Devuelve un mensaje de éxito de la operación y la información del usuario registrado.</response>
        /// <response code="400">BadRequest. Devuelve el error ocurrido en caso de que la operación no se realice.</response>
        /// <response code="500">InternalServerError. Devuelve el error que impide que la operación se realice.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("Register")]
        public async Task<ActionResult<GenericResponse>> RegisterAsync([FromForm]RegisterDTO registerDTO)
        {
            try
            {
                var user = await _loginService.Register(registerDTO);
                if (user == null)
                {
                    return BadRequest("Ya hay un Usuario registrado con el Email ingresado.");
                }
                var userlogin = _mapper.ConvertToUserLogin(user);
                var token = await _loginService.GetToken(userlogin);
                var viewRegister = _mapper.ConvertViewRegister(user);
                viewRegister.Token = token;
                _response.DisplayMessage = "Se ha registrado al usuario";
                _response.Entity = viewRegister;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorMessages = new List<string> { "Ha ocurrido un error", ex.ToString() };
                return BadRequest(_response);
            }
        }

        /// <summary>
        /// Muestra la información del usuario que ha iniciado sesión.
        /// </summary>
        /// <response code="400">BadRequest. Devuelve el error ocurrido en caso de que la operación no se realice.</response>
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("me")]
        [Authorize]
        public async Task<ActionResult<GenericResponse>> Get()
        {
            var id = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
            UserDTO usuario = new UserDTO();
            usuario =await _userService.GetById(id);
            if(usuario == null)
            {
                _response.IsSucces = false;
                _response.DisplayMessage = "No ha iniciado una sesión";
                return BadRequest(_response);
            }
            _response.DisplayMessage = "Información del usuario";
            _response.Entity = usuario;
            return Ok(_response);
        }



    }
}
