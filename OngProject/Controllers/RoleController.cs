using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRoleService roleService;

        public RoleController(IUnitOfWork unitOfWork, IRoleService roleService)
        {
            this.unitOfWork = unitOfWork;
            this.roleService = roleService;
        }
    }
}
