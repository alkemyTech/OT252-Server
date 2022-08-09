using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using OngProject.Core.Business;
using OngProject.Core.Interfaces;

using OngProject.Core.Models;

using OngProject.Core.Models.DTOs;

using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
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
        public async Task<ActionResult> RegisterAsync(RegisterDTO registerDTO)
        {
            try
            {
                var token = await _loginService.Register(registerDTO);
                if (token == null)
                {
                    return BadRequest("Ya hay un Usuario registrado con el Email ingresado.");
                }
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
