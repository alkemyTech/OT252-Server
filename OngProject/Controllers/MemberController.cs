using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using OngProject.Core.Business;
using OngProject.Core.Helper;
using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    /// <summary>
    /// Controlador para el mantenimiento de las actividades de la ONG
    /// </summary>
    [SwaggerTag("Member",
                Description = "Web API para miembros de la ONG.")]
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {

        private readonly IMemberService memberService;
        private readonly IUnitOfWork unitOfWork;

        public MemberController(IMemberService memberService, IUnitOfWork unitOfWork)
        {
            this.memberService = memberService;
            this.unitOfWork = unitOfWork;
        }


        /// GET: api/Members/GetAll
        /// <summary>
        /// Obtiene todas los miembros de la ONG.
        /// </summary>
        /// <remarks>
        /// Retorna un listado con todos los miembros de la ONG.
        /// </remarks>
        [Route("/Members")]
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<PageListDto<MemberDto>>> GetAll(int page = 1)
        {
            try
            {
                var memberList = await memberService.GetAll();
                if (memberList == null)
                {
                    return NotFound();
                }
                PageHelper<MemberDto> members = PageHelper<MemberDto>.Create(memberList, page, 10);
                PageListDto<MemberDto> pageList = new PageListDto<MemberDto>(members, "Members"); 
                return Ok(pageList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// GET: api/Members/:id
        /// <summary>
        /// Obtiene un miembro de la ONG con el id pasado por parámetro.
        /// </summary>
        /// <remarks>
        /// Retorna un miembro.
        /// </remarks>
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Member> Get(int id)
        {
            try
            {
                var member = memberService.GetById(id);
                return Ok(member);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// POST: api/members/
        /// <summary>
        /// Agrega un nuevo miembro a la ONG.
        /// </summary>
        /// <remarks>
        /// Retorna el miembro agregado recientemente.
        /// CAMPO REQUERIDO: el campo nombre es necesario completar 
        /// </remarks>
        [HttpPost("/Members")]
        //[Authorize(Roles = "Administrador")]
        public ActionResult<MemberDto> Post([FromBody] MemberDto member)
        {
            try
            {
                var newMember = memberService.Insert(member);

                return Ok(newMember);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }



        /// PUT: api/members/:id
        /// <summary>
        /// Actualiza datos de un miembro de la ONG pasando el id del mismo.
        /// </summary>
        /// <remarks>
        /// Retorna el miembro con los datos modificados.
        /// </remarks>
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        public ActionResult<MemberDto> Put([FromBody] MemberDto member, int id)
        {
            return (member) switch
            {
                (not null) => Ok(memberService.putActionMember(member,id)),
                (null)=> NotFound(),
            };
        }

        /// DELETE: api/members/:id
        /// <summary>
        /// Elimina un miembro de la ONG pasando el id del mismo.
        /// </summary>
        /// <remarks>
        /// Retorna verdadero o falso según se elimina correctamente o no.
        /// </remarks>
        [HttpDelete("/members")]
        //[Authorize(Roles = "Administrador")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                var deleteMember =await memberService.Delete(id);
                if (deleteMember)
                {
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
