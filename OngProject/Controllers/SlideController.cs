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

        public SlideController(SlideService slideService)
        {
            this.slideService = slideService;
        }

        [Route("GetAll")]
        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public ActionResult<IEnumerable<Slide>> GetAll()
        {
            try
            {
                var slideList = slideService.GetAll();
                return Ok(slideList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Slide> Get(int id)
        {
            try
            {
                var slide = slideService.GetById(id);
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
        [Authorize(Roles = "Administrador")]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                var deleteSlide = slideService.Delete(id);

                return Ok(true);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
