using Microsoft.AspNetCore.Authorization;
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

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult<Slide> Post([FromBody] Slide slide)
        {
            try
            {
                var newSlide = slideService.Insert(slide);

                return Ok(newSlide);
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
