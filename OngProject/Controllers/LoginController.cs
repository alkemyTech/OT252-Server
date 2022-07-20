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
    public class LoginController : ControllerBase
    {


        private readonly IUserService usuarioService;

        public LoginController(UserService usuarioService)
        {
            this.usuarioService = usuarioService;
        }
        [HttpPost]
        public ActionResult Login()
        {
            return Ok();
        }

        [HttpPost("Registro")]
        public ActionResult RegistrarUsuario()
        {
            return Ok();
        }


    }
}
