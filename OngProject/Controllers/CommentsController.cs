using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
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
        private readonly IUnitOfWork unitOfWork;

       

        public CommentsController(ICommentsService commentService, IUnitOfWork unitOfWork)
        {
            this.commentService = commentService;
            this.unitOfWork = unitOfWork;
        }

        [Route("/comments")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> Get()
        {
            try
            {
                if (await commentService.GetAll() is null)
                    return NotFound();
                return Ok(await commentService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        

        [HttpPost]
        public ActionResult<Comment> Post(Comment comment)
        {
            if (unitOfWork.CommentRepository is null) return BadRequest();
            unitOfWork.CommentRepository.Insert(comment);
            unitOfWork.Save();
            return NoContent();
        }

        [HttpPut("/comments/")]
        public async Task<ActionResult<CommentDto>> Put(int id, CommentDto commentDto)
        {
            try
            {
                var commentUpdated = await commentService.Update(id, commentDto);
                if(commentUpdated == null)
                {
                    return NotFound("El comentario no existe");
                }
                return Ok(commentUpdated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (unitOfWork.CommentRepository.GetById(id) is null) return NotFound();
           // unitOfWork.CommentRepository.Delete(id);
            unitOfWork.Save();
            return NoContent();

        }
    }
}
