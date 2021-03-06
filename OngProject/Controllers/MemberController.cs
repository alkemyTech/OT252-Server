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
    public class MemberController : ControllerBase
    {

        private readonly IMemberService memberService;

        public MemberController(MemberService memberService)
        {
            this.memberService = memberService;
        }

        [Route("GetAll")]
        [HttpGet]

        public ActionResult<IEnumerable<Member>> GetAll()
        {
            try
            {
                var memberList = memberService.GetAll();
                return Ok(memberList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
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

        [HttpPost]
        public ActionResult<Member> Post([FromBody] Member member)
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

        [HttpPut]
        public ActionResult<Member> Put([FromBody] Member member)
        {
            try
            {
                var editMember = memberService.Update(member);

                return Ok(editMember);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                var deleteMember = memberService.Delete(id);

                return Ok(true);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
