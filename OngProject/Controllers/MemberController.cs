﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using OngProject.Core.Business;
using OngProject.Core.Helper;
using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
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
        private readonly GenericResponse _response;
       // private readonly IUnitOfWork unitOfWork;

        public MemberController(IMemberService memberService/* IUnitOfWork unitOfWork*/)
        {
            this.memberService = memberService;
            _response = new GenericResponse();
           // this.unitOfWork = unitOfWork;
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
        public async Task<ActionResult<PageListDto<ViewMemberDto>>> GetAll(int page = 1)
        {
            try
            {
                var memberList = await memberService.GetAll();
                if (memberList == null)
                {
                    _response.IsSucces = false;
                    _response.DisplayMessage = "No hay registros";
                    return NotFound(_response);
                }
                PageHelper<ViewMemberDto> members = PageHelper<ViewMemberDto>.Create(memberList, page, 10);
                PageListDto<ViewMemberDto> pageList = new PageListDto<ViewMemberDto>(members, "Members"); 
                return Ok(pageList);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorMessages = new List<string> { "Ha ocurrido un error", ex.ToString() };
                return BadRequest(_response);
            }
        }

        /*
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
        */

        /// POST: api/members/
        /// <summary>
        /// Agrega un nuevo miembro a la ONG.
        /// </summary>
        /// <remarks>
        /// Retorna el miembro agregado recientemente.
        /// CAMPO REQUERIDO: el campo nombre es necesario completar 
        /// </remarks>
        [HttpPost("/Members")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<GenericResponse>> Post([FromForm] CreationMemberDto member)
        {
            try
            {
                var newMember = await memberService.Insert(member);
                _response.DisplayMessage = "Se ha registrado al miembro";
                _response.Entity = newMember;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorMessages = new List<string> { "Ha ocurrido un error", ex.ToString() };
                return BadRequest(_response);
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
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[Authorize(Roles = "Administrador")]
        public async Task<ActionResult<ViewMemberDto>> Put(int id, [FromForm] CreationMemberDto member)
        {
            return (member) switch
            {
                (not null) => Ok(await memberService.putActionMember(id, member)),
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
        public async Task<ActionResult<GenericResponse>> Delete(int id)
        {
            try
            {
                var deleteMember =await memberService.Delete(id);
                if (deleteMember)
                {
                    _response.DisplayMessage = "Se ha eliminado al miembro";
                    return Ok(_response);
                }
                _response.IsSucces = false;
                _response.DisplayMessage = "Miembro no existe";
                return NotFound(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorMessages = new List<string> { "Ha ocurrido un error", ex.ToString() };
                return BadRequest(_response);
            }

        }
    }
}
