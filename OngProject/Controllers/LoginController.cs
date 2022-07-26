using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Business;
using OngProject.Core.Interfaces;
using OngProject.Core.Models;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {


        private readonly IUserService usuarioService;

        public LoginController(UserService usuarioService)
        {
            this.usuarioService = usuarioService;
        }
        [HttpPost]
        public ActionResult Login([FromBody] UserRequest req)
        {
            var response = usuarioService.Login(req.Email, req.Password);
            if (response is null) return Unauthorized();
            var token = usuarioService.GetToken(response);
            return Ok(new
            {
                token = token,
                usuario = response

            });
        }

        [HttpPost("Registro")]
        public ActionResult RegistrarUsuario()
        {
            return Ok();
        }


    }
}
