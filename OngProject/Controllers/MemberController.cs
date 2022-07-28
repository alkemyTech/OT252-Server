﻿using Microsoft.AspNetCore.Authorization;
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

        public MemberController(IMemberService memberService)
        {
            this.memberService = memberService;
        }

        [Route("/Members")]
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Member>>> GetAll()
        {
            try
            {
                var memberList =await memberService.GetAll();
                if(memberList == null)
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

        [HttpPost]
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
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

        [HttpDelete("/members")]
        //[Authorize(Roles = "Administrador")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                var deleteMember =await memberService.Delete(id);
                if (!deleteMember)
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
