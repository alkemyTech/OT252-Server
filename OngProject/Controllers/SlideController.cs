﻿using Microsoft.AspNetCore.Authorization;
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
    [Route("api/[controller]")]
    [ApiController]
    public class SlideController : ControllerBase
    {

        private readonly ISlideService slideService;

        public SlideController(ISlideService slideService)
        {
            this.slideService = slideService;
        }

        [Route("GetAll")]
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Slide>>> GetAll()
        {
            try
            {
                var slideList = await slideService.GetAll();
                if (slideList == null)
                {
                    return NotFound();
                }
                return Ok(slideList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Slide>> Get(int id)
        {
            try
            {
                var slide = await slideService.GetById(id);
                if (slide == null)
                {
                    return BadRequest();
                }
                return Ok(slide);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("public/{id}")]
        public async Task<ActionResult<Slide>> GetByOrganization(int id)
        {
            try
            {
                var slides = await slideService.GetByOrganization(id);
                if (slides == null)
                {
                    return NotFound();
                }
                return Ok(slides);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]

        public async Task <ActionResult<Slide>> Post(SlideDto slide)

        {
            try
            {
                if (await slideService.Insert(slide))
                {
                    return Ok(slide);
                }
                return BadRequest("Ya existe un slide con ese orden");                

                

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public ActionResult<Slide> Put([FromBody] Slide slide)
        {
            try
            {
                var editSlide = slideService.Update(slide);

                return Ok(editSlide);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<bool>> Delete(int id)

        {
            if (await slideService.Delete(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
