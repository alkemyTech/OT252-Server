using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Business;
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

        [Route("/Members")]
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Member>>> GetAll()
        {
            try
            {
                var memberList = await memberService.GetAll();
                if (memberList == null)
                {
                    return NotFound();
                }
                return Ok(memberList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

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
