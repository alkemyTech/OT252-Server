using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Business;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class LoginController : ControllerBase
    {


        private readonly ILoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("Login")]
        public ActionResult Login()
        {
            return Ok();
        }

        [HttpPost("Register")]
        public async Task<ActionResult> RegisterAsync(RegisterDTO registerDTO)
        {
            try
            {
                var userDto = await _loginService.Register(registerDTO);
                if (userDto == null)
                {
                    return BadRequest("Ya hay un Usuario registrado con el Email ingresado.");
                }
                return Ok(userDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
