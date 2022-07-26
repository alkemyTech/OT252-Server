using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsService commentService;

        public CommentsController(ICommentsService commentService)
        {
            this.commentService = commentService;
        }


        [Route("/comments")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> Get()
        {
            try
            {
                var commentsList = await commentService.GetAll();
                if (commentsList == null)
                {
                    return NotFound();
                }
                return Ok(commentsList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "";
        }

        [HttpPost]
        public void Post()
        {
        }

        [HttpPut("{id}")]
        public void Put()
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
