using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Business;
using OngProject.Core.Interfaces;

using OngProject.Core.Models;

using OngProject.Core.Models.DTOs;

using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/auth")]  //Aca le cambie el controller por auth para adaptarlo a lo que pedian las OT252-30 y 31
    [ApiController]
    public class LoginController : ControllerBase
    {


        private readonly ILoginService _loginService;

        private readonly IUserService usuarioService;
        private readonly IUnitOfWork unitOfWork;
        public LoginController(ILoginService loginService, IUnitOfWork unitOfWork, IUserService usuarioService)

        
        
        {
            _loginService = loginService;
            this.unitOfWork = unitOfWork;
            this.usuarioService = usuarioService;
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var response = _loginService.Login(email, password);
            if (response is null) return Unauthorized();
            return Ok(response);
        }

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
       [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetAll()
        {
            try
            {     
                if (await usuarioService.GetAll())
                    return NotFound();
                return Ok(await usuarioService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
