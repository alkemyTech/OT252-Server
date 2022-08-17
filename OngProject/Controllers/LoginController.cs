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
    /// Controlador para Logeo de la ONG
    /// </summary>
    [SwaggerTag("Login",
                Description = "Web API para logeo de la ONG.")]
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
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var response = _loginService.Login(email, password);
            if (response is null) return Unauthorized();
            return Ok(response);
        }
        /// <summary>
        /// Endpoind para Registrar
        /// </summary>
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
                _response.Message = "Se ha registrado al usuario";
                _response.Entity = viewRegister;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<ActionResult<UserDTO>> Get()
        {
            var id = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id").Value);

            UserDTO usuario = new UserDTO();
            usuario =await _userService.GetById(id);
            return Ok(usuario);
        }



    }
}
